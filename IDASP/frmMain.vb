Imports System.IO

Public Class frmMain

    Private _filename As String = Nothing
    Dim myProperties As PropertiesClass

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox(BitConverter.ToString(SetName("群馬県")).Replace("-", ""))
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "EXE files (*.exe)|*.exe"
        ofd.FilterIndex = 1
        ofd.RestoreDirectory = True
        ofd.InitialDirectory = My.Application.Info.DirectoryPath
        If ofd.ShowDialog() = DialogResult.OK Then
            Dim newFileName As String = String.Format("{0}\{1}.bak", Path.GetDirectoryName(ofd.FileName), Path.GetFileName(ofd.FileName))
            File.Copy(ofd.FileName, newFileName, True)
            _filename = ofd.FileName
            tsslFileName.Text = Path.GetFileName(_filename)
            myProperties = New PropertiesClass(_filename)
            PropertyGrid1.SelectedObject = myProperties
            btnPatch.Enabled = True

            myProperties.FreePlayValue1 = GetIsTrue(GetHex(_filename, &H606608, 1))
            myProperties.FreePlayValue2 = GetIsTrue(GetHex(_filename, &H6069CE, 1))
            myProperties.StoreName = GetName(GetHex(_filename, &HB7D580, 14))
            myProperties.StoreRegion = PropertiesClass.Region.群馬県
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub btnPatch_Click(sender As Object, e As EventArgs) Handles btnPatch.Click
        Try
            Dim charInt As Integer = 0
            For Each c As Char In myProperties.StoreName
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 13 Then
                Dim amount As Integer = 14 - charInt
                Dim newName As Char = Nothing
                Select Case amount
                    Case 1
                        newName = Chr(0)
                    Case 2
                        newName = Chr(0) & Chr(0)
                    Case 3
                        newName = Chr(0) & Chr(0) & Chr(0)
                    Case 4
                        newName = Chr(0) & Chr(0) & Chr(0) & Chr(0)
                    Case 5
                        newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                    Case 6
                        newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                    Case 7
                        newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                    Case 8
                        newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                    Case 9
                        newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                    Case 10
                        newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                    Case 11
                        newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                    Case 12
                        newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                    Case 13
                        newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                    Case 14
                        newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                End Select
                SetHex(_filename, &HB7D580, SetName(myProperties.StoreName & newName))
            Else
                SetHex(_filename, &HB7D580, SetName(myProperties.StoreName))
            End If

            SetHex(_filename, &H606608, SetIsTrue(myProperties.FreePlayValue1))
            SetHex(_filename, &H6069CE, SetIsTrue(myProperties.FreePlayValue2))

            MsgBox("Save Successful.", MsgBoxStyle.Information, "OK")
        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
            Exit Sub
        End Try
    End Sub

    'Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
    '    Dim sfd As New SaveFileDialog()
    '    sfd.Filter = "EXE files (*.exe)|*.exe"
    '    sfd.FilterIndex = 1
    '    sfd.RestoreDirectory = True
    '    sfd.InitialDirectory = My.Application.Info.DirectoryPath
    '    If sfd.ShowDialog() = DialogResult.OK Then
    '        If Not File.Exists(sfd.FileName) Then File.Create(sfd.FileName).Close()

    '    End If
    'End Sub
End Class
