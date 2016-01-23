Imports Newtonsoft.Json
Imports Engine
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ret As Boolean = False
        Try
            Dim Create As String = Request("Create")
            Dim TagNo As String = Request("TagNo")
            If TagNo <> "" Then
                If TagNo.Length > 16 Then
                    TagNo = TagNo.Substring(0, 16)
                End If
            End If

            Dim SpeedWaySerialNo As String = Request("SN")
            Dim SpeedwayAntNo As String = Request("SpeedwayAntNo")
            Dim Rssi As String = Request("Rssi")
            Dim StationNo As String = TagMovementENG.GetSpeedwayStationNo(SpeedWaySerialNo)

            ret = TagMovementENG.InsertTagMovement(TagNo, SpeedWaySerialNo, SpeedwayAntNo, Rssi, StationNo)
            If ret = True Then
                If StationNo = "1" Then   'เมื่อเดินผ่านประตู รปภ.
                    ret = Register.UpdateRegisterTime(TagNo)
                ElseIf StationNo = "3" Then  'เมื่อเข้ามายังจุดถ่ายรูป
                    ret = MapTagPhotoENG.InsertTakePhotoJob(TagNo, StationNo, Create)
                ElseIf StationNo = "3.2" Then 'จุดถ่ายรูปหมู่
                    ret = MapTagPhotoENG.InsertJobMultiple(TagNo, StationNo, Create)
                    If ret = True Then
                        MapTagPhotoENG.UpdateLastCurrentJob()
                    End If

                ElseIf StationNo = "5" Then 'เข้าเยี่ยมชมโรงงาน

                End If
            End If
        Catch ex As Exception
            ret = False
        End Try

        Response.Write(JsonConvert.SerializeObject(ret, Formatting.Indented))
    End Sub
End Class
