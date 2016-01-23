Imports LinqDB.TABLE
Imports LinqDB.ConnectDB
Public Class TagMovementENG
    Public Shared Function InsertTagMovement(TagNo As String, SpeedWaySerialNo As String, SpeedwayAntNo As String, Rssi As String, StationNo As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim lnq As New TksTagMovementLinqDB
            If StationNo = "5" Then
                lnq.ChkDataByWhere("tag_no='" & TagNo & "' and station_no='" & StationNo & "'", Nothing)
            End If

            Dim trans As New TransactionDB
            lnq.LOG_DATE = SqlDB.GetDateNowFromDB(trans.Trans)
            lnq.TAG_NO = TagNo
            lnq.SPEEDWAY_SERIAL_NO = SpeedWaySerialNo
            lnq.SPEEDWAY_ANT_NO = SpeedwayAntNo
            lnq.RSSI = Rssi
            lnq.STATION_NO = StationNo

            If lnq.ID = 0 Then
                ret = lnq.InsertData("TagMovementENG.InsertTagMovement", trans.Trans)

                If ret = True Then
                    trans.CommitTransaction()

                    trans = New TransactionDB
                    Dim rLnq As New TksRegisterLinqDB
                    rLnq.ChkDataByTAG_NO(TagNo, trans.Trans)
                    If rLnq.ID > 0 Then
                        rLnq.CURRENT_STATION_NO = StationNo

                        ret = rLnq.UpdateByPK("TagMovementENG.InsertTagMovement", trans.Trans)
                        If ret = True Then
                            trans.CommitTransaction()
                        Else
                            trans.RollbackTransaction()
                        End If
                    Else
                        ret = False
                        trans.RollbackTransaction()
                    End If
                    rLnq = Nothing
                Else
                    ret = False
                    trans.RollbackTransaction()
                End If
            Else
                ret = True
                trans.CommitTransaction()
            End If
            lnq = Nothing
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

    Public Shared Function GetSpeedwayStationNo(SerialNo As String) As String
        Dim ret As String = ""
        Try
            Dim lnq As New TksMsSpeedwayLinqDB
            lnq.ChkDataBySERIAL_NO(SerialNo, Nothing)

            If lnq.ID > 0 Then
                ret = lnq.STATION_NO
            End If
            lnq = Nothing
        Catch ex As Exception
            ret = ""
        End Try
        Return ret
    End Function
End Class
