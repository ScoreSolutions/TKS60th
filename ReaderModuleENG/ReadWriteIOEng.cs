using System;
using System.IO.Ports;              //端口操作
using System.Text;

namespace ReaderModule
{
    public class ReadWriteIOEng
    {
        public ReadWriteIOEng()
        {
            InvTimeOut = 50;

        }

        public static SerialPort comm = new SerialPort();        //定义一个串口事件
        //public static int baud = 115200;                  //波特率固定为115200
        public static UInt16 InvTimeOut;
        public static byte[] SendBuf = new byte[100];        //发送缓冲

        /*********************************************************************
        *函数名称：sendFrameBuild()
        *函数功能：发送组帧函数
        *参    数：byte[] buf--数据；byte cmd--帧类型；UInt16 len--帧长度
        *返 回 值：无  
        *创 建 者：雷    彪 
        *创建日期：2011-04-26
        *修改记录：无  
        **********************************************************************/
        public static void sendFrameBuild(byte[] buf, byte cmd, UInt16 len)
        {
            SendBuf[0] = CMDEng.FRAME_HEAD_FIRST;
            SendBuf[1] = CMDEng.FRAME_HEAD_SECOND;
            SendBuf[2] = (byte)(((len + CMDEng.FRAME_HEADEND_LEN) >> 8) & 0xff);
            SendBuf[3] = (byte)((len + CMDEng.FRAME_HEADEND_LEN) & 0xff);
            SendBuf[4] = cmd;
            System.Array.Copy(buf, 0, SendBuf, 5, len);
            SendBuf[len + CMDEng.FRAME_HEADEND_LEN - 3] = ProductCRC(SendBuf, (UInt16)(len + 5)); //CRC
            SendBuf[len + CMDEng.FRAME_HEADEND_LEN - 2] = CMDEng.FRAME_END_MRK_FIRST; //帧尾
            SendBuf[len + CMDEng.FRAME_HEADEND_LEN - 1] = CMDEng.FRAME_END_MRK_SECOND; //帧尾
        }
        /*********************************************************************
        *函数名称：ProductCRC()
        *函数功能：生成校验字节
        *参    数：byte[] p，帧数据；UInt16 len--长度
        *返 回 值：byte--CRC的值
        *创 建 者：雷    彪 
        *创建日期：2011-05-03
        *修改记录：无  
        **********************************************************************/
        public static byte ProductCRC(byte[] p, UInt16 len)
        {
            UInt16 i;
            byte crc = 0;

            for (i = 2; i < len; i++)         //计算校验时，帧头和帧尾不计算
            {
                crc ^= p[i];
            }

            return crc;
        }


        public static string ReadTag(int WordStartAddr,int WordLength) {
            string ret = "";
            _err = "";
            try {
                UInt16 len = 0;
                UInt16 cur = 0;
                UInt16 tmp;
                byte[] buf = new byte[500];
                int recount = 200000;     //重试次数
                int revlen = 0;         //接收数据长度
                Byte[] revbuf = new Byte[500];           //接收缓冲
                string str;
                byte[] bytetmp = new byte[500];
                byte[] bytetmp_t = new byte[500];
                int i;

                string lb_ReadWriteResult = "";
                //string textBox_data = "";
                string lB_NumOfData = "0";

                /* 获取AccPwd值 */
                str = "00000000";  //Access Password
                if (str.Length != 8)
                {
                    _err = "access password length error";
                    ret= "";
                }

                bytetmp = Encoding.Default.GetBytes(str);
                ReaderParamsEng.ByteArrayToUInt8Array(bytetmp, bytetmp_t, 8);
                for (i = 0; i < 4; i++)
                {
                    buf[cur++] = (byte)((bytetmp_t[2 * i] << 4) + bytetmp_t[2 * i + 1]);
                }


                //Start Filter  Off
                for (i = 4; i < 9; i++)
                {
                    buf[cur++] = 0x00;
                }
                tmp = 0;

                cur = (UInt16)(9 + (tmp / 8));
                if ((tmp % 8) != 0)
                {
                    cur++;
                }
                /* Memory Bank */
                buf[cur++] = (byte)1;
                /* 起始地址 */
                str = WordStartAddr.ToString();
                tmp = UInt16.Parse(str);
                buf[cur++] = (byte)(tmp >> 8);
                buf[cur++] = (byte)(tmp & 0xFF);
                /* 长度 */
                str = WordLength.ToString();
                UInt16 datalength = UInt16.Parse(str);
                buf[cur++] = (byte)(datalength >> 8);
                buf[cur++] = (byte)(datalength & 0xFF);

                len = cur;
                ReadWriteIOEng.sendFrameBuild(buf, CMDEng.FRAME_CMD_READ_DATA, len);
                if (ReadWriteIOEng.comm.IsOpen)
                {
                    ReadWriteIOEng.comm.DiscardInBuffer();
                    ReadWriteIOEng.comm.DiscardOutBuffer();
                    revlen = 0;
                    ReadWriteIOEng.comm.Write(ReadWriteIOEng.SendBuf, 0, (len + CMDEng.FRAME_HEADEND_LEN));
                }
                else
                {
                    _err = "Do not open the port Read Failed";
                    ret = "";
                }

                while ((revlen == 0) && (recount != 0))
                {
                    recount--;
                    revlen = ReadWriteIOEng.comm.BytesToRead;
                }

                if (recount == 0)       //未收到数据
                {
                    _err = "Read Failed";
                    ret = "";
                }
                else
                {
                    System.Threading.Thread.Sleep(300);
                    revlen = ReadWriteIOEng.comm.BytesToRead;
                    ReadWriteIOEng.comm.Read(revbuf, 0, revlen);
                }


                //判断是否成功
                if (!((revbuf[0] == CMDEng.FRAME_HEAD_FIRST)
                    && (revbuf[1] == CMDEng.FRAME_HEAD_SECOND)
                    && (revbuf[2] == 0x00)
                    && (revbuf[4] == CMDEng.FRAME_CMD_READ_DATA_RSP)
                    && (revbuf[5] == 0x01)))
                {
                    _err = "Read Failed";
                    return "";
                }

                for (i = 0; i < datalength * 2; i++)
                {
                    ret += revbuf[9 + i].ToString("X2");
                    if (i < datalength * 2 - 1)
                    {
                        ret += "-";
                    }
                }

                _err = "";
                lB_NumOfData = (datalength * 2).ToString();
            }
            catch (Exception ex) {
                _err = ex.Message + "\n" + ex.StackTrace;
            }
            return ret;
        }

        static string _err = "";
        public static string ErrorMessage {
            get {
                return _err;
            }
            set { 
                _err = value;
            }
        }

        public static bool WriteTag(string TagNo, int WordStartAddr, int WordLenth) {
            bool ret = false;
            _err = "";
            try {
                UInt16 len = 0;
                UInt16 cur = 0;
                UInt16 tmp;
                byte[] buf = new byte[500];
                int recount = 500000;     //重试次数
                int revlen = 0;         //接收数据长度
                Byte[] revbuf = new Byte[500];           //接收缓冲
                string str;
                byte[] bytetmp = new byte[500];
                byte[] bytetmp_t = new byte[500];
                int i;

                str = "00000000";
                if (str.Length != 8)
                {
                    _err = "access password length error";
                    return false;
                }

                bytetmp = Encoding.Default.GetBytes(str);
                ReaderParamsEng.ByteArrayToUInt8Array(bytetmp, bytetmp_t, 8);
                for (i = 0; i < 4; i++)
                {
                    buf[cur++] = (byte)((bytetmp_t[2 * i] << 4) + bytetmp_t[2 * i + 1]);
                }


                for (i = 4; i < 9; i++)
                {
                    buf[cur++] = 0x00;
                }
                tmp = 0;


                cur = (UInt16)(9 + (tmp / 8));
                if ((tmp % 8) != 0)
                {
                    cur++;
                }
                /* Memory Bank */
                buf[cur++] = (byte)1;
                str = WordStartAddr.ToString();
                UInt16 startaddr = UInt16.Parse(str);
                buf[cur++] = (byte)(startaddr >> 8);
                buf[cur++] = (byte)(startaddr & 0xFF);
                /* 长度 */
                str = WordLenth.ToString();
                UInt16 datalength = UInt16.Parse(str);
                buf[cur++] = (byte)(datalength >> 8);
                buf[cur++] = (byte)(datalength & 0xFF);
                /* 数据 */
                str = TagNo;
                if ((datalength * 2 * 3 - 1) > str.Length)
                {
                    //MessageBox.Show("data length error", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _err = "data length error";
                    return false;
                }


                bytetmp = Encoding.Default.GetBytes(str);
                for (i = 0; i < str.Length; i++)
                {
                    if ((bytetmp[i] >= '0') && (bytetmp[i] <= '9'))
                    {
                    }
                    else if ((bytetmp[i] >= 'A') && (bytetmp[i] <= 'F'))
                    {
                    }
                    else if (bytetmp[i] == '-')
                    {
                    }
                    else
                    {
                        _err = "Write error";
                        return false;
                    }
                }


                ReaderParamsEng.ByteArrayToUInt8Array(bytetmp, bytetmp_t, (datalength * 2 * 3 - 1));
                for (i = 0; i < datalength * 2; i++)
                {
                    buf[cur++] = (byte)((bytetmp_t[3 * i] << 4) + bytetmp_t[3 * i + 1]);
                }

                len = cur;
                ReadWriteIOEng.sendFrameBuild(buf, CMDEng.FRAME_CMD_WRITE_DATA, len);

                if (ReadWriteIOEng.comm.IsOpen)
                {
                    ReadWriteIOEng.comm.DiscardInBuffer();
                    ReadWriteIOEng.comm.DiscardOutBuffer();
                    revlen = 0;
                    ReadWriteIOEng.comm.Write(ReadWriteIOEng.SendBuf, 0, (len + CMDEng.FRAME_HEADEND_LEN));
                }
                else
                {
                    _err = "Do not open the port : Write Failed";
                    return false;
                }

                while ((revlen == 0) && (recount != 0))
                {
                    recount--;
                    revlen = ReadWriteIOEng.comm.BytesToRead;
                }

                if (recount == 0)      
                {
                    _err = "Write Failed";
                    return false;
                }
                else
                {
                    System.Threading.Thread.Sleep(300);
                    revlen = ReadWriteIOEng.comm.BytesToRead;
                    ReadWriteIOEng.comm.Read(revbuf, 0, revlen);
                }


                if (!((revbuf[0] == CMDEng.FRAME_HEAD_FIRST)
                && (revbuf[1] == CMDEng.FRAME_HEAD_SECOND)
                && (revbuf[2] == 0x00)
                && (revbuf[4] == CMDEng.FARAM_CMD_WRITE_DATA_RSP)
                && (revbuf[5] == 0x01)))
                {
                    _err = "Write Failed";
                    return false;
                }

                //_err = "Write OK";
                ret = true;
            }
            catch (Exception ex) {
                ret = false;
                _err = ex.Message + "\n" + ex.StackTrace;
            }

            return ret;

        }


        #region //Beef
        public static void BeefON()
        {
            byte mask = 0;
            byte data = 0;
            int result = 0;

            mask = 0x02;
            data = 0x02;

            result = SendSetGPIOStatus(mask, data);

            if (0 == result)
            {
                //lB_GetGpioDisp.Text = "Set OK";
            }
            else
            {

            }
        }

        public static void BeefOFF()
        {
            byte mask = 0;
            byte data = 0;
            int result = 0;

            mask = 0x02;
            data = 0x00;

            result = SendSetGPIOStatus(mask, data);

            if (0 == result)
            {
                //lB_GetGpioDisp.Text = "Set OK";
            }
            else
            {

            }
        }

        private static int SendSetGPIOStatus(byte mask, byte data)
        {
            UInt16 len = 2;
            Byte[] WriteBuf = new Byte[100];
            int recount = 80000;     //重试次数
            int revlen = 0;         //接收数据长度
            Byte[] revbuf = new Byte[500];           //接收缓冲

            WriteBuf[0] = mask;
            WriteBuf[1] = data;

            ReadWriteIOEng.sendFrameBuild(WriteBuf, CMDEng.FRAME_CMD_SET_GPIO, len);
            if (ReadWriteIOEng.comm.IsOpen)
            {
                ReadWriteIOEng.comm.DiscardInBuffer();
                ReadWriteIOEng.comm.DiscardOutBuffer();
                revlen = 0;
                ReadWriteIOEng.comm.Write(ReadWriteIOEng.SendBuf, 0, (len + CMDEng.FRAME_HEADEND_LEN));
            }
            else
            {
                if (0 == ReaderParamsEng.LanguageFlag)
                {
                    //MessageBox.Show("端口未打开，操作失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    //MessageBox.Show("Do not open the port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                return -3;
            }

            while ((revlen < 0x09) && (recount != 0))
            {
                recount--;
                revlen = ReadWriteIOEng.comm.BytesToRead;
            }

            if (recount == 0)       //未收到数据
            {
                return -1;
            }
            else
            {
                revlen = ReadWriteIOEng.comm.BytesToRead;
                ReadWriteIOEng.comm.Read(revbuf, 0, revlen);
            }

            //判断是否设置成功
            if (!((revbuf[0] == CMDEng.FRAME_HEAD_FIRST)
                && (revbuf[1] == CMDEng.FRAME_HEAD_SECOND)
                && (revbuf[2] == 0x00) && (revbuf[3] == 0x09)
                && (revbuf[4] == CMDEng.FRAME_CMD_SET_GPIO_RSP)
                && (revbuf[5] == 0x01)))
            {
                return -2;
            }
            return 0;
        }
        #endregion
    }
}