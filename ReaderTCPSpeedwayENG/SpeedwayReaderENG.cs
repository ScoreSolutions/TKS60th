using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Threading;
using Impinj.OctaneSdk;




public class SpeedwayReaderENG
    {
        private object MyLock = new object();
        public ImpinjReader Reader = new ImpinjReader();
        public String readerName = "";
        //private Custom.Control.SortListView m_sortListView;

        string _ReaderIP = "";
        string ReaderSerialNo = "";


        public List<string> ReaderNames = new List<string>();
        public List<ImpinjReader> readers = new List<ImpinjReader>();
        public Dictionary<string, List<Tag>> TagTable = new Dictionary<string, List<Tag>>();

        public  SpeedwayReaderENG(string ReaderIP) {
            _ReaderIP = ReaderIP;
        }

        public void Run()
        {
            try
            {
                int i = 10;
                // Change the level of logging detail. The default is Error.
                //Reader.LogLevel = LogLevel.Error;

                // Attach to events
                Reader.TagsReported += OnTagsReported;
                Reader.ReaderStarted += OnReaderStarted;
                Reader.ReaderStopped += OnReaderStopped;

                // Connect to the reader. The name is the host name
                // or IP address.
                Reader.Connect(_ReaderIP);

                // Clear the reader of any RFID operation and configuration.
                Reader.ApplyDefaultSettings();

                // Query the default settings for the reader. Settings
                // include which antennas are enabled, when to report and
                // optional report fields. Typically you will prepare the
                // reader by getting the default settings and adjusting them.
                //
                // This example sets the reader to send a tag report
                // immediately on every tag observation. Message buffering
                // improves overall efficiency but introduces a small
                // delay before the application is notified of a tag.
                // Message buffering is enabled by default.
                Settings settings = Reader.QueryDefaultSettings();
                settings.Report.Mode = ReportMode.Individual;

                settings.ReaderMode = ReaderMode.AutoSetDenseReader; // Adjust ช่องความถี่
                settings.SearchMode = SearchMode.TagFocus; //จับสัญญาน ไวขึ้น
                settings.Session = 1;

                settings.AutoStart.Mode = AutoStartMode.GpiTrigger;
                settings.AutoStart.GpiPortNumber = 1;
                settings.AutoStart.GpiLevel = true;
                settings.AutoStop.Mode = AutoStopMode.GpiTrigger;
                settings.AutoStop.GpiPortNumber = 1;
                settings.AutoStop.GpiLevel = false;
                settings.Report.IncludeAntennaPortNumber = true;
                
                settings.Antennas.GetAntenna(1).IsEnabled = true;
                //settings.Antennas.GetAntenna(2).IsEnabled = true;
                //settings.Antennas.GetAntenna(3).IsEnabled = true;
                //settings.Antennas.GetAntenna(4).IsEnabled = true;

                settings.Antennas.GetAntenna(1).MaxRxSensitivity = true;
                settings.Antennas.GetAntenna(1).TxPowerInDbm = 30;
                //settings.Antennas.GetAntenna(2).MaxRxSensitivity = true;
                //settings.Antennas.GetAntenna(2).TxPowerInDbm = 25;
                //settings.Antennas.GetAntenna(3).MaxRxSensitivity = true;
                //settings.Antennas.GetAntenna(3).TxPowerInDbm = 25;
                //settings.Antennas.GetAntenna(4).MaxRxSensitivity = true;
                //settings.Antennas.GetAntenna(4).TxPowerInDbm = 25;
                //settings.Antennas[1].TxPowerInDbm = 25;
                //settings.Antennas[1].RxSensitivityInDbm = -70;
                //settings.Antennas[0].TxPowerInDbm = 10;//0-32  min 10  Power ของการอ่าน Default 30

                FeatureSet feature = Reader.QueryFeatureSet();
                ReaderSerialNo = feature.SerialNumber;


                // Order the reader to change its settings to these.
                Reader.ApplySettings(settings);

                // Start the reader.
                Reader.Start();

                while (true)
                {
                    Thread.Sleep(i);
                }
                // Pause for 10 seconds
                //System.Threading.Thread.Sleep(1 * 1000);

                // Stop the reader.
                //Reader.Stop();

                ////// Tidy up
                //Reader.ClearSettings();
            }
            catch (OctaneSdkException ex)
            {
                // OctaneSdkExceptions are detected by the Octane SDK
                // library. These exceptions usually indicate either
                // something wrong with the reader or something wrong
                // with the applications request.
                Console.WriteLine("OctaneSdk detected {0}", ex);
            }
            catch (Exception ex)
            {
                // Any other kind of exception deteced by the system.
                Console.WriteLine("Exception {0}", ex);
            }

            // Safely disconnect from the reader.
            try
            {
                //Reader.Disconnect();
            }
            catch (OctaneSdkException ex)
            {
                Console.WriteLine("OctaneSdk detected {0}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception {0}", ex);
            }
        }

        static void OnReaderStarted(ImpinjReader reader, ReaderStartedEvent e)
        {
            Console.WriteLine("Reader started {0}", reader.Address);
        }
        // This event handler gets called when the reader is stopped.
        static void OnReaderStopped(ImpinjReader reader, ReaderStoppedEvent e)
        {
            Console.WriteLine("Reader stopped : {0}", reader.Address);
        }
        public void ConnectAndPrepareAllReaders()
        {
            foreach (string readerName in ReaderNames)
            {
                ImpinjReader reader = new ImpinjReader();

                try
                {
                    // Set the reader identity. It can be any object.
                    // This is passed back with events and tag reports.
                    reader.Name = readerName;
                    //reader.ReaderIdentity = readerName;

                    // Change the level of logging detail. The default is Error.
                    //reader.LogLevel = LogLevel.Error;

                    // Attach to events
                    Reader.TagsReported += OnTagsReported;
                    Reader.ReaderStarted += OnReaderStarted;
                    Reader.ReaderStopped += OnReaderStopped;

                    // Connect to the reader. The name is the host name
                    // or IP address.
                    Reader.Connect(_ReaderIP);

                    // Clear the reader of any RFID operation and configuration.
                    Reader.ApplyDefaultSettings();

                    // Query the default settings for the reader. Settings
                    // include which antennas are enabled, when to report and
                    // optional report fields. Typically you will prepare the
                    // reader by getting the default settings and adjusting them.
                    //
                    // This example sets the reader to send a tag report
                    // immediately on every tag observation. Message buffering
                    // improves overall efficiency but introduces a small
                    // delay before the application is notified of a tag.
                    // Message buffering is enabled by default.
                    Settings settings = Reader.QueryDefaultSettings();
                    settings.Report.Mode = ReportMode.Individual;

                    settings.ReaderMode = ReaderMode.AutoSetDenseReader; // Adjust ช่องความถี่
                    settings.SearchMode = SearchMode.TagFocus; //จับสัญญาน ไวขึ้น
                    settings.Session = 1;

                    settings.AutoStart.Mode = AutoStartMode.GpiTrigger;
                    settings.AutoStart.GpiPortNumber = 1;
                    settings.AutoStart.GpiLevel = true;
                    settings.AutoStop.Mode = AutoStopMode.GpiTrigger;
                    settings.AutoStop.GpiPortNumber = 1;
                    settings.AutoStop.GpiLevel = false;
                    settings.Report.IncludeAntennaPortNumber = true;

                    settings.Antennas.GetAntenna(1).IsEnabled = true;
                    settings.Antennas.GetAntenna(2).IsEnabled = true;
                    settings.Antennas.GetAntenna(3).IsEnabled = true;
                    settings.Antennas.GetAntenna(4).IsEnabled = true;

                    settings.Antennas.GetAntenna(1).MaxRxSensitivity = true;
                    settings.Antennas.GetAntenna(1).TxPowerInDbm = 25;
                    settings.Antennas.GetAntenna(2).MaxRxSensitivity = true;
                    settings.Antennas.GetAntenna(2).TxPowerInDbm = 25;
                    settings.Antennas.GetAntenna(3).MaxRxSensitivity = true;
                    settings.Antennas.GetAntenna(3).TxPowerInDbm = 25;
                    settings.Antennas.GetAntenna(4).MaxRxSensitivity = true;
                    settings.Antennas.GetAntenna(4).TxPowerInDbm = 25;
                    reader.ApplySettings(settings);
                    
                    // Add this reader to the list of readers.
                    readers.Add(reader);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("Exception {0} for reader {1}", ex, readerName);
                    try
                    {
                        reader.Disconnect();
                    }
                    catch (OctaneSdkException octaneSdkException)
                    {
                        //Console.WriteLine("OctaneSdk detected {0}", octaneSdkException);
                    }
                    catch (Exception exception)
                    {
                        //Console.WriteLine("Exception {0}", exception);
                    }
                }
            }
        }

        public void StartAllReaders()
        {
            foreach (ImpinjReader reader in readers)
            {
                try
                {
                    reader.Start();
                }
                catch (OctaneSdkException ex)
                {
                    //Console.WriteLine("Reader {0} start: OctaneSdk detected {1}",
                    //    reader.ReaderIdentity, ex);
                }
                catch (Exception ex)
                {
                    // Any other kind of exception deteced by the system.
                    //Console.WriteLine("Reader {0} start: Exception {1}",
                    //    reader.ReaderIdentity, ex);
                }
            }
        }

        public void StopAllReaders()
        {
            foreach (ImpinjReader reader in readers)
            {
                try
                {
                    reader.Stop();
                }
                catch (OctaneSdkException ex)
                {
                    //Console.WriteLine("Reader {0} stop: OctaneSdk detected {1}",
                    //    reader.ReaderIdentity, ex);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("Reader {0} stop: Exception {1}",
                    //    reader.ReaderIdentity, ex);
                }
            }
        }

        public void ClearAndDisconnectAllReaders()
        {
            foreach (ImpinjReader reader in readers)
            {
                try
                {
                    reader.ApplyDefaultSettings();
                }
                catch (OctaneSdkException ex)
                {
                    //Console.WriteLine("Reader {0} clear: OctaneSdk detected {1}",
                    //    reader.ReaderIdentity, ex);
                }
                catch (Exception ex)
                {
                    // Any other kind of exception deteced by the system.
                    //Console.WriteLine("Reader {0} clear: Exception {1}",
                    //    reader.ReaderIdentity, ex);
                }

                try
                {
                    reader.Disconnect();
                }
                catch (OctaneSdkException ex)
                {
                    Console.WriteLine("OctaneSdk detected {0}", ex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception {0}", ex);
                }
            }
        }
        // The event handler methods below are invoked while running
        // on a callback thread. There is one callback thread per a
        // SpeedwayReader instance.
        //
        // Be sure to use thread safe techniques.

        /// <summary>
        /// Called each time the reader connects.
        /// </summary>
        /// <param name="sender">The reader that sent the event.</param>
        /// <param name="args">Contains information about the event; the reader, timestamp and new
        /// reader state are properties of this object.</param>
        /// 
        public void writeLog(String str)
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(Application.StartupPath + "\\Log_File.txt");
                //Read the first line of text
                line = sr.ReadToEnd();

                //Continue to read until you reach end of file
                //while (line != null)
                //{
                //    //Read the next line
                //    line += sr.ReadLine();
                //}

                //close the file
                sr.Close();
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\Log_File.txt");
                line += str;
                sw.WriteLine(line);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }



        /// <summary>
        /// Called each time the reader disconnects.
        /// </summary>
        /// <param name="sender">The reader that sent the event.</param>
        /// <param name="args">Contains information about the event; the reader, timestamp and new
        /// reader state are properties of this object.</param>
       
        /// <summary>
        /// Called each time the reader starts.
        /// </summary>
        /// <param name="sender">The reader that sent the event.</param>
        /// <param name="args">Contains information about the event; the reader, timestamp and new
        /// operational state are properties of this object.</param>
        //public void StartedHandler(object sender, StartedEventArgs args)
        //{
        //    writeLog("Reader started as of {0} " + args.Timestamp);
        //}

        /// <summary>
        /// Called each time the reader stops.
        /// </summary>
        /// <param name="sender">The reader that sent the event.</param>
        /// <param name="args">Contains information about the event; the reader, timestamp and news
        /// operational state are properties of this object.</param>
        //public void StoppedHandler(object sender, StoppedEventArgs args)
        //{
        //    writeLog("Reader stopped as of {0} " + args.Timestamp);
        //}

        /// <summary>
        /// Called each time the reader singulates a tag, or a batch of tags.
        /// </summary>
        /// <param name="sender">The reader that sent the event.</param>
        /// <param name="args">Contains information about the event; the reader, timestamp and
        /// tag reports are properties of this object.</param>
        public void OnTagsReported(ImpinjReader sender, TagReport report)
        {
            ////panel1.Controls.Clear();
            //double RSSI = Convert.ToDouble(ini.IniReadValue("setting", "RSSI"));
            //double RSSI2 = Convert.ToDouble(ini.IniReadValue("setting", "RSSI2"));
            //int portNumber = Convert.ToInt16(ini.IniReadValue("setting", "Port"));
            foreach (Tag tag in report.Tags)
            {

            //    writeLog("Reader saw {0} on ant#{1} " +
            //        tag.Epc + " " + tag.AntennaPortNumber + " " + tag.PeakRssiInDbm);

            //    //TagAll += tag.Epc + '\n';
                try
                {
                    string strData = tag.Epc.ToString().Replace(" ","") + "##" + tag.AntennaPortNumber.ToString() + "##" + tag.PeakRssiInDbm.ToString() + "##" + ReaderSerialNo;
                    if (VariablesENG.list.Contains(tag.Epc.ToString().Replace(" ", "")))
                    {

                    }
                    else
                    {
                        VariablesENG.list.RemoveAll(x => x.Contains(tag.Epc.ToString().Replace(" ", "")));
                        VariablesENG.list.Add(strData);
                    }
                    //VariablesENG.list.RemoveAll(x => x.Contains(tag.Epc.ToString().Replace(" ", "")));
                    
                    

            //        string strData2 = "";
            //        string strData3 = "";
            //        string strData4 = "";
            //        //CA.GetData(tag.Epc);
            //        //var va = list.Find(x => x.Split('|')[1] == tag.Epc);
            //        bool blnStatus = false;
            //        if (tag.AntennaPortNumber == 1)
            //        {
            //            if (tag.PeakRssiInDbm >= RSSI)
            //            {
            //                strData = CA.GetData(tag.Epc);

            //                Variables.list.RemoveAll(x => x.Contains(tag.Epc));
            //                Variables.list.Add(strData);
            //                //Variables.list2.RemoveAll(x => x.Contains(tag.Epc));
            //                //Variables.list2.Add(strData);
            //            }
            //        }
            //        if (tag.AntennaPortNumber == 2)
            //        {
            //            if (tag.PeakRssiInDbm >= RSSI2)
            //            {
            //                strData = CA.GetData(tag.Epc);

            //                Variables.list.RemoveAll(x => x.Contains(tag.Epc));
            //                Variables.list.Add(strData);
            //                //strData = CA.GetData(tag.Epc.Substring(0, 8));

            //                //Variables.list2.RemoveAll(x => x.Contains(tag.Epc.Substring(0,8)));
            //                //Variables.list2.Add(strData);
            //            }
            //        }
            //        if (tag.AntennaPortNumber == 3)
            //        {
            //            strData3 = CA.GetData(tag.Epc);
            //            Variables.list3.RemoveAll(x => x.Contains(tag.Epc.Substring(0, 7)));
            //            Variables.list3.Add(strData);
            //        }
            //        if (tag.AntennaPortNumber == 4)
            //        {
            //            strData4 = CA.GetData(tag.Epc);
            //            Variables.list4.RemoveAll(x => x.Contains(tag.Epc.Substring(0, 7)));
            //            Variables.list4.Add(strData);
            //        }

                }
                catch (Exception ex)
                {
                }
            }
        }

        //public void Gpi1ChangedHandler(object sender, GpiChangedEventArgs args)
        //{
        //    writeLog("GPI1 now {0} " + args.State);
        //}

        /// <summary>
        /// Called each time the library creates a log entry.
        /// </summary>
        /// <param name="sender">The object that originated the log entry.</param>
        /// <param name="args">Contains information about the event; has the log entry as a property.</param>
        //public void LoggingHandler(object sender, LoggingEventArgs args)
        //{
        //    LogEntry entry = args.Entry;
        //    //writeLog("Log level={0} {1} " + entry.Level + entry.Message);
        //}
    }

