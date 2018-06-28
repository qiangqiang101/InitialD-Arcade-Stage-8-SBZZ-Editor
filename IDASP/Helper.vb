Imports System.IO
Imports System.Text

Module Helper

    Function GetHex(filename As String, offset As Integer, requiredBytes As Integer) As Byte()
        Dim value(0 To requiredBytes - 1) As Byte
        Using reader As New BinaryReader(File.Open(filename, FileMode.Open))
            ' Loop through length of file.
            Dim fileLength As Long = reader.BaseStream.Length
            Dim byteCount As Integer = 0
            reader.BaseStream.Seek(offset, SeekOrigin.Begin)
            While offset < fileLength And byteCount < requiredBytes
                value(byteCount) = reader.ReadByte()
                offset += 1
                byteCount += 1
            End While
        End Using

        Return value
    End Function

    Sub SetHex(filename As String, offset As Long, value As Byte())
        Try
            Dim fs As New FileStream(filename, FileMode.Open)
            Dim reader As New BinaryReader(fs)
            fs.Position = offset
            For Each num As Byte In value
                If num.ToString() = String.Empty Then
                    Exit For
                End If
                reader.BaseStream.WriteByte(num)
            Next
            reader.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Function GetName(hex As Byte()) As String
        Dim enc = Encoding.GetEncoding("shift-jis")
        Dim value = enc.GetString(hex)
        Return value
    End Function

    Function SetName(val As String) As Byte()
        Dim enc = Encoding.GetEncoding("shift-jis")
        Return enc.GetBytes(val)
    End Function

    Function GetHexStringFromBinary(hex As Byte()) As String
        Return BitConverter.ToString(hex).Replace("-", "")
    End Function

    Function HexStringToBinary(ByVal hexString As String) As Byte()
        Return Enumerable.Range(0, hexString.Length).Where(Function(x) x Mod 2 = 0).[Select](Function(x) Convert.ToByte(hexString.Substring(x, 2), 16)).ToArray()
    End Function

    Function GetIsTrue(hex As Byte()) As Boolean
        Dim result As String = BitConverter.ToString(hex).Replace("-", "")
        Dim result2 As Boolean = False
        If result = "01" Then result2 = True
        Return result2
    End Function

    Function SetIsTrue(ByVal bool As Boolean) As Byte()
        Dim result As Byte() = HexStringToBinary("01")
        If bool Then result = HexStringToBinary("01") Else result = HexStringToBinary("00")
        Return result
    End Function

    Sub wait(ByVal interval As Integer)
        Dim stopW As New Stopwatch
        stopW.Start()
        Do While stopW.ElapsedMilliseconds < interval
            ' Allows your UI to remain responsive
            Application.DoEvents()
        Loop
        stopW.Stop()
    End Sub

    Private sjis As System.Text.Encoding = System.Text.Encoding.GetEncoding("shift_JIS")
    <System.Runtime.CompilerServices.Extension>
    Public Function IsWideEastAsianWidth_SJIS(ByVal c As Char) As Boolean
        Dim byteCount As Integer = sjis.GetByteCount(c.ToString())
        Return byteCount = 2
    End Function

End Module
