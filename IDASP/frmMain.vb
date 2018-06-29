Imports System.IO

Public Class frmMain

    Private _filename As String = Nothing
    Dim myProperties As PropertiesClass

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "EXE files (*.exe)|*.exe"
        ofd.FilterIndex = 1
        ofd.RestoreDirectory = True
        ofd.InitialDirectory = My.Application.Info.DirectoryPath
        If ofd.ShowDialog() = DialogResult.OK Then
            _filename = ofd.FileName
            tsslFileName.Text = Path.GetFileName(_filename)
            myProperties = New PropertiesClass(_filename)
            PropertyGrid1.SelectedObject = myProperties
            SaveToolStripMenuItem.Enabled = True

            myProperties.FreePlayValue1 = GetIsTrue(GetHex(_filename, &H606608, 1))
            myProperties.FreePlayValue2 = GetIsTrue(GetHex(_filename, &H6069CE, 1))
            myProperties.StoreName = GetName(GetHex(_filename, &HB7D580, 14))
            myProperties.StoreRegion = GetName(GetHex(_filename, &HBF01EC, 6))

            Dim bgm1 As New BGMClass(GetName(GetHex(_filename, &HB2AA58, 12)), GetName(GetHex(_filename, &HB2AA68, 3)))
            myProperties.BGM01 = bgm1
            Dim bgm2 As New BGMClass(GetName(GetHex(_filename, &HB2AA6C, 31)), GetName(GetHex(_filename, &HB2AA8C, 8)))
            myProperties.BGM02 = bgm2
            Dim bgm3 As New BGMClass(GetName(GetHex(_filename, &HB2AA98, 12)), GetName(GetHex(_filename, &HB2AAA8, 7)))
            myProperties.BGM03 = bgm3
            Dim bgm4 As New BGMClass(GetName(GetHex(_filename, &HB2AAB4, 8)), GetName(GetHex(_filename, &HB2AAC0, 5)))
            myProperties.BGM04 = bgm4
            Dim bgm5 As New BGMClass(GetName(GetHex(_filename, &HB2AAC8, 6)), GetName(GetHex(_filename, &HB2AAD0, 10)))
            myProperties.BGM05 = bgm5
            Dim bgm6 As New BGMClass(GetName(GetHex(_filename, &HB2AADC, 28)), GetName(GetHex(_filename, &HB2AAFC, 12)))
            myProperties.BGM06 = bgm6
            Dim bgm7 As New BGMClass(GetName(GetHex(_filename, &HB2AB0C, 22)), GetName(GetHex(_filename, &HB2AB24, 9)))
            myProperties.BGM07 = bgm7
            Dim bgm8 As New BGMClass(GetName(GetHex(_filename, &HB2AB30, 12)), GetName(GetHex(_filename, &HB2AB40, 6)))
            myProperties.BGM08 = bgm8
            Dim bgm9 As New BGMClass(GetName(GetHex(_filename, &HB2AB48, 4)), GetName(GetHex(_filename, &HB2AB50, 12)))
            myProperties.BGM09 = bgm9
            Dim bgm10 As New BGMClass(GetName(GetHex(_filename, &HB2AB60, 18)), GetName(GetHex(_filename, &HB2AB74, 9)))
            myProperties.BGM10 = bgm10
            Dim bgm11 As New BGMClass(GetName(GetHex(_filename, &HB2AB80, 21)), GetName(GetHex(_filename, &HB2AB98, 12)))
            myProperties.BGM11 = bgm11
            Dim bgm12 As New BGMClass(GetName(GetHex(_filename, &HB2ABA8, 18)), GetName(GetHex(_filename, &HB2ABBC, 11)))
            myProperties.BGM12 = bgm12
            Dim bgm13 As New BGMClass(GetName(GetHex(_filename, &HB2ABCC, 15)), GetName(GetHex(_filename, &HB2ABDC, 10)))
            myProperties.BGM13 = bgm13
            Dim bgm14 As New BGMClass(GetName(GetHex(_filename, &HB2ABE8, 10)), GetName(GetHex(_filename, &HB2ABF4, 3)))
            myProperties.BGM14 = bgm14
            Dim bgm15 As New BGMClass(GetName(GetHex(_filename, &HB2ABF8, 15)), GetName(GetHex(_filename, &HB2AC08, 6)))
            myProperties.BGM15 = bgm15
            Dim bgm16 As New BGMClass(GetName(GetHex(_filename, &HB2AC10, 26)), GetName(GetHex(_filename, &HB2AC2C, 14)))
            myProperties.BGM16 = bgm16
            Dim bgm17 As New BGMClass(GetName(GetHex(_filename, &HB2AC3C, 11)), GetName(GetHex(_filename, &HB2AC48, 25)))
            myProperties.BGM17 = bgm17
            Dim bgm18 As New BGMClass(GetName(GetHex(_filename, &HB2AC64, 19)), GetName(GetHex(_filename, &HB2AC78, 8)))
            myProperties.BGM18 = bgm18
            Dim bgm19 As New BGMClass(GetName(GetHex(_filename, &HB2AC84, 8)), GetName(GetHex(_filename, &HB2AC90, 8)))
            myProperties.BGM19 = bgm19
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Try
#Region "StoreName"
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
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                    Case 11
                        newName = b & b & b & b & b & b & b & b & b & b & b
                    Case 12
                        newName = b & b & b & b & b & b & b & b & b & b & b & b
                    Case 13
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 14
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB7D580, SetName(myProperties.StoreName & newName))
            Else
                SetHex(_filename, &HB7D580, SetName(myProperties.StoreName))
            End If

            charInt = 0
            For Each c As Char In myProperties.StoreRegion
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 5 Then
                Dim amount As Integer = 6 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                End Select
                SetHex(_filename, &HBF01EC, SetName(myProperties.StoreRegion & newName))
            Else
                SetHex(_filename, &HBF01EC, SetName(myProperties.StoreRegion))
            End If
#End Region

            SetHex(_filename, &H606608, SetIsTrue(myProperties.FreePlayValue1))
            SetHex(_filename, &H6069CE, SetIsTrue(myProperties.FreePlayValue2))

#Region "BGM 11-19"

            'BGM19
            charInt = 0
            For Each c As Char In myProperties.BGM19.SongName
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 7 Then
                Dim amount As Integer = 8 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AC84, SetName(myProperties.BGM19.SongName & newName))
            Else
                SetHex(_filename, &HB2AC84, SetName(myProperties.BGM19.SongName))
            End If

            charInt = 0
            For Each c As Char In myProperties.BGM19.Artists
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 7 Then
                Dim amount As Integer = 8 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AC90, SetName(myProperties.BGM19.Artists & newName))
            Else
                SetHex(_filename, &HB2AC90, SetName(myProperties.BGM19.Artists))
            End If

            'BGM18
            charInt = 0
            For Each c As Char In myProperties.BGM18.SongName
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 18 Then
                Dim amount As Integer = 19 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                    Case 11
                        newName = b & b & b & b & b & b & b & b & b & b & b
                    Case 12
                        newName = b & b & b & b & b & b & b & b & b & b & b & b
                    Case 13
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 14
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 15
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 16
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 17
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 18
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 19
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AC64, SetName(myProperties.BGM18.SongName & newName))
            Else
                SetHex(_filename, &HB2AC64, SetName(myProperties.BGM18.SongName))
            End If

            charInt = 0
            For Each c As Char In myProperties.BGM18.Artists
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 7 Then
                Dim amount As Integer = 8 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AC78, SetName(myProperties.BGM18.Artists & newName))
            Else
                SetHex(_filename, &HB2AC78, SetName(myProperties.BGM18.Artists))
            End If

            'BGM17
            charInt = 0
            For Each c As Char In myProperties.BGM17.SongName
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 10 Then
                Dim amount As Integer = 11 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                    Case 11
                        newName = b & b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AC3C, SetName(myProperties.BGM17.SongName & newName))
            Else
                SetHex(_filename, &HB2AC3C, SetName(myProperties.BGM17.SongName))
            End If

            charInt = 0
            For Each c As Char In myProperties.BGM17.Artists
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 24 Then
                Dim amount As Integer = 25 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                    Case 11
                        newName = b & b & b & b & b & b & b & b & b & b & b
                    Case 12
                        newName = b & b & b & b & b & b & b & b & b & b & b & b
                    Case 13
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 14
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 15
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 16
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 17
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 18
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 19
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 20
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 21
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 22
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 23
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 24
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 25
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AC48, SetName(myProperties.BGM17.Artists & newName))
            Else
                SetHex(_filename, &HB2AC48, SetName(myProperties.BGM17.Artists))
            End If

            'BGM16
            charInt = 0
            For Each c As Char In myProperties.BGM16.SongName
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 25 Then
                Dim amount As Integer = 26 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                    Case 11
                        newName = b & b & b & b & b & b & b & b & b & b & b
                    Case 12
                        newName = b & b & b & b & b & b & b & b & b & b & b & b
                    Case 13
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 14
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 15
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 16
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 17
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 18
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 19
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 20
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 21
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 22
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 23
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 24
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 25
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 26
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AC10, SetName(myProperties.BGM16.SongName & newName))
            Else
                SetHex(_filename, &HB2AC10, SetName(myProperties.BGM16.SongName))
            End If

            charInt = 0
            For Each c As Char In myProperties.BGM16.Artists
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 13 Then
                Dim amount As Integer = 14 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                    Case 11
                        newName = b & b & b & b & b & b & b & b & b & b & b
                    Case 12
                        newName = b & b & b & b & b & b & b & b & b & b & b & b
                    Case 13
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 14
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AC2C, SetName(myProperties.BGM16.Artists & newName))
            Else
                SetHex(_filename, &HB2AC2C, SetName(myProperties.BGM16.Artists))
            End If

            'BGM15
            charInt = 0
            For Each c As Char In myProperties.BGM15.SongName
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 14 Then
                Dim amount As Integer = 15 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                    Case 11
                        newName = b & b & b & b & b & b & b & b & b & b & b
                    Case 12
                        newName = b & b & b & b & b & b & b & b & b & b & b & b
                    Case 13
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 14
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 15
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2ABF8, SetName(myProperties.BGM15.SongName & newName))
            Else
                SetHex(_filename, &HB2ABF8, SetName(myProperties.BGM15.SongName))
            End If

            charInt = 0
            For Each c As Char In myProperties.BGM15.Artists
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 5 Then
                Dim amount As Integer = 6 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AC08, SetName(myProperties.BGM15.Artists & newName))
            Else
                SetHex(_filename, &HB2AC08, SetName(myProperties.BGM15.Artists))
            End If

            'BGM14
            charInt = 0
            For Each c As Char In myProperties.BGM14.SongName
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 9 Then
                Dim amount As Integer = 10 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2ABE8, SetName(myProperties.BGM14.SongName & newName))
            Else
                SetHex(_filename, &HB2ABE8, SetName(myProperties.BGM14.SongName))
            End If

            charInt = 0
            For Each c As Char In myProperties.BGM14.Artists
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 2 Then
                Dim amount As Integer = 3 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                End Select
                SetHex(_filename, &HB2ABF4, SetName(myProperties.BGM14.Artists & newName))
            Else
                SetHex(_filename, &HB2ABF4, SetName(myProperties.BGM14.Artists))
            End If

            'BGM13
            charInt = 0
            For Each c As Char In myProperties.BGM13.SongName
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 14 Then
                Dim amount As Integer = 15 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                    Case 11
                        newName = b & b & b & b & b & b & b & b & b & b & b
                    Case 12
                        newName = b & b & b & b & b & b & b & b & b & b & b & b
                    Case 13
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 14
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 15
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2ABCC, SetName(myProperties.BGM13.SongName & newName))
            Else
                SetHex(_filename, &HB2ABCC, SetName(myProperties.BGM13.SongName))
            End If

            charInt = 0
            For Each c As Char In myProperties.BGM13.Artists
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 9 Then
                Dim amount As Integer = 10 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2ABDC, SetName(myProperties.BGM13.Artists & newName))
            Else
                SetHex(_filename, &HB2ABDC, SetName(myProperties.BGM13.Artists))
            End If

            'BGM12
            charInt = 0
            For Each c As Char In myProperties.BGM12.SongName
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 17 Then
                Dim amount As Integer = 18 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                    Case 11
                        newName = b & b & b & b & b & b & b & b & b & b & b
                    Case 12
                        newName = b & b & b & b & b & b & b & b & b & b & b & b
                    Case 13
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 14
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 15
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 16
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 17
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 18
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2ABA8, SetName(myProperties.BGM12.SongName & newName))
            Else
                SetHex(_filename, &HB2ABA8, SetName(myProperties.BGM12.SongName))
            End If

            charInt = 0
            For Each c As Char In myProperties.BGM12.Artists
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 10 Then
                Dim amount As Integer = 11 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                    Case 11
                        newName = b & b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2ABBC, SetName(myProperties.BGM12.Artists & newName))
            Else
                SetHex(_filename, &HB2ABBC, SetName(myProperties.BGM12.Artists))
            End If

            'BGM11
            charInt = 0
            For Each c As Char In myProperties.BGM11.SongName
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 20 Then
                Dim amount As Integer = 21 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                    Case 11
                        newName = b & b & b & b & b & b & b & b & b & b & b
                    Case 12
                        newName = b & b & b & b & b & b & b & b & b & b & b & b
                    Case 13
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 14
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 15
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 16
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 17
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 18
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 19
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 20
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 21
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AB80, SetName(myProperties.BGM11.SongName & newName))
            Else
                SetHex(_filename, &HB2AB80, SetName(myProperties.BGM11.SongName))
            End If

            charInt = 0
            For Each c As Char In myProperties.BGM11.Artists
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 11 Then
                Dim amount As Integer = 12 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                    Case 11
                        newName = b & b & b & b & b & b & b & b & b & b & b
                    Case 12
                        newName = b & b & b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AB98, SetName(myProperties.BGM11.Artists & newName))
            Else
                SetHex(_filename, &HB2AB98, SetName(myProperties.BGM11.Artists))
            End If

#End Region
#Region "BGM 1-10"

            'BGM10
            charInt = 0
            For Each c As Char In myProperties.BGM10.SongName
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 17 Then
                Dim amount As Integer = 18 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                    Case 11
                        newName = b & b & b & b & b & b & b & b & b & b & b
                    Case 12
                        newName = b & b & b & b & b & b & b & b & b & b & b & b
                    Case 13
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 14
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 15
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 16
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 17
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 18
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AB60, SetName(myProperties.BGM10.SongName & newName))
            Else
                SetHex(_filename, &HB2AB60, SetName(myProperties.BGM10.SongName))
            End If

            charInt = 0
            For Each c As Char In myProperties.BGM10.Artists
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 8 Then
                Dim amount As Integer = 9 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AB74, SetName(myProperties.BGM10.Artists & newName))
            Else
                SetHex(_filename, &HB2AB74, SetName(myProperties.BGM10.Artists))
            End If

            'BGM09
            charInt = 0
            For Each c As Char In myProperties.BGM09.SongName
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 3 Then
                Dim amount As Integer = 4 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                End Select
                SetHex(_filename, &HB2AB48, SetName(myProperties.BGM09.SongName & newName))
            Else
                SetHex(_filename, &HB2AB48, SetName(myProperties.BGM09.SongName))
            End If

            charInt = 0
            For Each c As Char In myProperties.BGM09.Artists
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 11 Then
                Dim amount As Integer = 12 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                    Case 11
                        newName = b & b & b & b & b & b & b & b & b & b & b
                    Case 12
                        newName = b & b & b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AB50, SetName(myProperties.BGM09.Artists & newName))
            Else
                SetHex(_filename, &HB2AB50, SetName(myProperties.BGM09.Artists))
            End If

            'BGM08
            charInt = 0
            For Each c As Char In myProperties.BGM08.SongName
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 11 Then
                Dim amount As Integer = 12 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                    Case 11
                        newName = b & b & b & b & b & b & b & b & b & b & b
                    Case 12
                        newName = b & b & b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AB30, SetName(myProperties.BGM08.SongName & newName))
            Else
                SetHex(_filename, &HB2AB30, SetName(myProperties.BGM08.SongName))
            End If

            charInt = 0
            For Each c As Char In myProperties.BGM08.Artists
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 5 Then
                Dim amount As Integer = 6 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AB40, SetName(myProperties.BGM08.Artists & newName))
            Else
                SetHex(_filename, &HB2AB40, SetName(myProperties.BGM08.Artists))
            End If

            'BGM07
            charInt = 0
            For Each c As Char In myProperties.BGM07.SongName
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 21 Then
                Dim amount As Integer = 22 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                    Case 11
                        newName = b & b & b & b & b & b & b & b & b & b & b
                    Case 12
                        newName = b & b & b & b & b & b & b & b & b & b & b & b
                    Case 13
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 14
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 15
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 16
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 17
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 18
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 19
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 20
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 21
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 22
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AB0C, SetName(myProperties.BGM07.SongName & newName))
            Else
                SetHex(_filename, &HB2AB0C, SetName(myProperties.BGM07.SongName))
            End If

            charInt = 0
            For Each c As Char In myProperties.BGM07.Artists
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 8 Then
                Dim amount As Integer = 9 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AB24, SetName(myProperties.BGM07.Artists & newName))
            Else
                SetHex(_filename, &HB2AB24, SetName(myProperties.BGM07.Artists))
            End If

            'BGM06
            charInt = 0
            For Each c As Char In myProperties.BGM06.SongName
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 27 Then
                Dim amount As Integer = 28 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                    Case 11
                        newName = b & b & b & b & b & b & b & b & b & b & b
                    Case 12
                        newName = b & b & b & b & b & b & b & b & b & b & b & b
                    Case 13
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 14
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 15
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 16
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 17
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 18
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 19
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 20
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 21
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 22
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 23
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 24
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 25
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 26
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 27
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 28
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AADC, SetName(myProperties.BGM06.SongName & newName))
            Else
                SetHex(_filename, &HB2AADC, SetName(myProperties.BGM06.SongName))
            End If

            charInt = 0
            For Each c As Char In myProperties.BGM06.Artists
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 11 Then
                Dim amount As Integer = 12 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                    Case 11
                        newName = b & b & b & b & b & b & b & b & b & b & b
                    Case 12
                        newName = b & b & b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AAFC, SetName(myProperties.BGM06.Artists & newName))
            Else
                SetHex(_filename, &HB2AAFC, SetName(myProperties.BGM06.Artists))
            End If

            'BGM05
            charInt = 0
            For Each c As Char In myProperties.BGM05.SongName
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 5 Then
                Dim amount As Integer = 6 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AAC8, SetName(myProperties.BGM05.SongName & newName))
            Else
                SetHex(_filename, &HB2AAC8, SetName(myProperties.BGM05.SongName))
            End If

            charInt = 0
            For Each c As Char In myProperties.BGM05.Artists
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 9 Then
                Dim amount As Integer = 10 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AAD0, SetName(myProperties.BGM05.Artists & newName))
            Else
                SetHex(_filename, &HB2AAD0, SetName(myProperties.BGM05.Artists))
            End If

            'BGM04
            charInt = 0
            For Each c As Char In myProperties.BGM04.SongName
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 7 Then
                Dim amount As Integer = 8 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AAB4, SetName(myProperties.BGM04.SongName & newName))
            Else
                SetHex(_filename, &HB2AAB4, SetName(myProperties.BGM04.SongName))
            End If

            charInt = 0
            For Each c As Char In myProperties.BGM04.Artists
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 4 Then
                Dim amount As Integer = 5 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AAC0, SetName(myProperties.BGM04.Artists & newName))
            Else
                SetHex(_filename, &HB2AAC0, SetName(myProperties.BGM04.Artists))
            End If

            'BGM03
            charInt = 0
            For Each c As Char In myProperties.BGM03.SongName
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 11 Then
                Dim amount As Integer = 12 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                    Case 11
                        newName = b & b & b & b & b & b & b & b & b & b & b
                    Case 12
                        newName = b & b & b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AA98, SetName(myProperties.BGM03.SongName & newName))
            Else
                SetHex(_filename, &HB2AA98, SetName(myProperties.BGM03.SongName))
            End If

            charInt = 0
            For Each c As Char In myProperties.BGM03.Artists
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 6 Then
                Dim amount As Integer = 7 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AAA8, SetName(myProperties.BGM03.Artists & newName))
            Else
                SetHex(_filename, &HB2AAA8, SetName(myProperties.BGM03.Artists))
            End If

            'BGM02
            charInt = 0
            For Each c As Char In myProperties.BGM02.SongName
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 30 Then
                Dim amount As Integer = 31 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                    Case 11
                        newName = b & b & b & b & b & b & b & b & b & b & b
                    Case 12
                        newName = b & b & b & b & b & b & b & b & b & b & b & b
                    Case 13
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 14
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 15
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 16
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 17
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 18
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 19
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 20
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 21
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 22
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 23
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 24
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 25
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 26
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 27
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 28
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 29
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 30
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                    Case 31
                        newName = b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AA6C, SetName(myProperties.BGM02.SongName & newName))
            Else
                SetHex(_filename, &HB2AA6C, SetName(myProperties.BGM02.SongName))
            End If

            charInt = 0
            For Each c As Char In myProperties.BGM02.Artists
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 7 Then
                Dim amount As Integer = 8 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AA8C, SetName(myProperties.BGM02.Artists & newName))
            Else
                SetHex(_filename, &HB2AA8C, SetName(myProperties.BGM02.Artists))
            End If

            'BGM01
            charInt = 0
            For Each c As Char In myProperties.BGM01.SongName
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 11 Then
                Dim amount As Integer = 12 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                    Case 4
                        newName = b & b & b & b
                    Case 5
                        newName = b & b & b & b & b
                    Case 6
                        newName = b & b & b & b & b & b
                    Case 7
                        newName = b & b & b & b & b & b & b
                    Case 8
                        newName = b & b & b & b & b & b & b & b
                    Case 9
                        newName = b & b & b & b & b & b & b & b & b
                    Case 10
                        newName = b & b & b & b & b & b & b & b & b & b
                    Case 11
                        newName = b & b & b & b & b & b & b & b & b & b & b
                    Case 12
                        newName = b & b & b & b & b & b & b & b & b & b & b & b
                End Select
                SetHex(_filename, &HB2AA58, SetName(myProperties.BGM01.SongName & newName))
            Else
                SetHex(_filename, &HB2AA58, SetName(myProperties.BGM01.SongName))
            End If

            charInt = 0
            For Each c As Char In myProperties.BGM01.Artists
                If c.IsWideEastAsianWidth_SJIS Then
                    charInt += 2
                Else
                    charInt += 1
                End If
            Next
            If charInt <= 2 Then
                Dim amount As Integer = 3 - charInt
                Dim newName As Char = Nothing
                Dim b As Char = Chr(0)
                Select Case amount
                    Case 1
                        newName = b
                    Case 2
                        newName = b & b
                    Case 3
                        newName = b & b & b
                End Select
                SetHex(_filename, &HB2AA68, SetName(myProperties.BGM01.Artists & newName))
            Else
                SetHex(_filename, &HB2AA68, SetName(myProperties.BGM01.Artists))
            End If

#End Region

            SetHex(_filename, &HB2B7C0, HexStringToBinary("68747470733A2F2F74656B6E6F706172726F742E636F6D2F00")) 'teknoparrot

            MsgBox("Save Successful.", MsgBoxStyle.Information, "OK")
        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
            Exit Sub
        End Try
    End Sub

    Private Sub ImNotMentaLWebsiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImNotMentaLWebsiteToolStripMenuItem.Click
        Process.Start("https://www.imnotmental.com/")
    End Sub

    Private Sub ZettabyteTechnologyWebsiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZettabyteTechnologyWebsiteToolStripMenuItem.Click
        Process.Start("http://www.zettabytetek.com/")
    End Sub

    Private Sub TeknoParrotOfficialWebsiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TeknoParrotOfficialWebsiteToolStripMenuItem.Click
        Process.Start("https://teknoparrot.com/")
    End Sub

    Private Sub TeknoGodsOfficialWebsiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TeknoGodsOfficialWebsiteToolStripMenuItem.Click
        Process.Start("https://teknogods.com/")
    End Sub

    Private Sub WereNotMentaL20ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WereNotMentaL20ToolStripMenuItem.Click
        Process.Start("https://discord.gg/ECu6Amf")
    End Sub

    Private Sub IDPLAYERSEYNAASIAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IDPLAYERSEYNAASIAToolStripMenuItem.Click
        Process.Start("https://discord.gg/gRdeTy7")
    End Sub

    Private Sub 頭文字D中文討論區ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 頭文字D中文討論區ToolStripMenuItem.Click
        Process.Start("https://discord.gg/BBdqUYq")
    End Sub

    Private Sub 頭文字DnetEmulationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 頭文字DnetEmulationToolStripMenuItem.Click
        Process.Start("https://discord.gg/4by99Dj")
    End Sub

    Private Sub TeknoGodsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TeknoGodsToolStripMenuItem.Click
        Process.Start("https://discord.gg/bntkyXZ")
    End Sub

    Private Sub TextToHexToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TextToHexToolStripMenuItem.Click
        Dim answer As String
        Dim prompt As String = "Please enter text you would like to convert."
        Dim title As String = "Getting user input"
        answer = InputBox(prompt, title, Nothing)
        Dim converted As String = BitConverter.ToString(SetName(answer)).Replace("-", "")
        If Not answer = Nothing Then
            MsgBox(converted, MsgBoxStyle.Information, Me.Text)
            Clipboard.SetText(converted)
        End If
    End Sub
End Class
