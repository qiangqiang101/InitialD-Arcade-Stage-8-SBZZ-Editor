Imports System.ComponentModel

Public Class PropertiesClass

    Public Sub New(file As String)
        _file = file
    End Sub

    Private _file As String
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public ReadOnly Property File() As String
        Get
            Return _file
        End Get
    End Property

    Private _freePlay, _freePlay2 As Boolean
    <Category("Behavior")>
    <Description("First value to enable free play or credit play in the game.")>
    Public Property FreePlayValue1() As Boolean
        Get
            Return _freePlay 'GetIsTrue(GetHex(File, &H606608, 1))
        End Get
        Set(value As Boolean)
            _freePlay = value 'SetHex(File, &H606608, SetIsTrue(value))
        End Set
    End Property

    <Category("Behavior")>
    <Description("Second value to enable free play or credit play in the game.")>
    Public Property FreePlayValue2() As Boolean
        Get
            Return FreePlayValue2 'GetIsTrue(GetHex(File, &H6069CE, 1))
        End Get
        Set(value As Boolean)
            _freePlay2 = value 'SetHex(File, &H6069CE, SetIsTrue(value))
        End Set
    End Property

    Private _storeName As String
    <Category("Name")>
    <Description("Store name that shows under player avatar. Visible to Rivals.")>
    Public Property StoreName() As String
        Get
            Return _storeName 'GetName(GetHex(File, &HB7D580, 14))
        End Get
        Set(value As String)
            _storeName = value
        End Set
    End Property

    Private _storeRegion As String
    <Category("Name")>
    <Description("Region that shows under player avatar, Not visible to Rivals.")>
    Public Property StoreRegion() As String
        Get
            Return _storeRegion 'GetName(GetHex(File, &HBF01EC, 6))
        End Get
        Set(value As String)
            _storeRegion = value
        End Set
    End Property

    Private _bgm1 As BGMClass
    <Category("BGM")>
    <Description("Song name displayed in game.")>
    Public Property BGM01() As BGMClass
        Get
            Return _bgm1
        End Get
        Set(value As BGMClass)
            _bgm1 = value
        End Set
    End Property

    Private _bgm2 As BGMClass
    <Category("BGM")>
    <Description("Song name displayed in game.")>
    Public Property BGM02() As BGMClass
        Get
            Return _bgm2
        End Get
        Set(value As BGMClass)
            _bgm2 = value
        End Set
    End Property

    Private _bgm3 As BGMClass
    <Category("BGM")>
    <Description("Song name displayed in game.")>
    Public Property BGM03() As BGMClass
        Get
            Return _bgm3
        End Get
        Set(value As BGMClass)
            _bgm3 = value
        End Set
    End Property

    Private _bgm4 As BGMClass
    <Category("BGM")>
    <Description("Song name displayed in game.")>
    Public Property BGM04() As BGMClass
        Get
            Return _bgm4
        End Get
        Set(value As BGMClass)
            _bgm4 = value
        End Set
    End Property

    Private _bgm5 As BGMClass
    <Category("BGM")>
    <Description("Song name displayed in game.")>
    Public Property BGM05() As BGMClass
        Get
            Return _bgm5
        End Get
        Set(value As BGMClass)
            _bgm5 = value
        End Set
    End Property

    Private _bgm6 As BGMClass
    <Category("BGM")>
    <Description("Song name displayed in game.")>
    Public Property BGM06() As BGMClass
        Get
            Return _bgm6
        End Get
        Set(value As BGMClass)
            _bgm6 = value
        End Set
    End Property

    Private _bgm7 As BGMClass
    <Category("BGM")>
    <Description("Song name displayed in game.")>
    Public Property BGM07() As BGMClass
        Get
            Return _bgm7
        End Get
        Set(value As BGMClass)
            _bgm7 = value
        End Set
    End Property

    Private _bgm8 As BGMClass
    <Category("BGM")>
    <Description("Song name displayed in game.")>
    Public Property BGM08() As BGMClass
        Get
            Return _bgm8
        End Get
        Set(value As BGMClass)
            _bgm8 = value
        End Set
    End Property

    Private _bgm9 As BGMClass
    <Category("BGM")>
    <Description("Song name displayed in game.")>
    Public Property BGM09() As BGMClass
        Get
            Return _bgm9
        End Get
        Set(value As BGMClass)
            _bgm9 = value
        End Set
    End Property

    Private _bgm10 As BGMClass
    <Category("BGM")>
    <Description("Song name displayed in game.")>
    Public Property BGM10() As BGMClass
        Get
            Return _bgm10
        End Get
        Set(value As BGMClass)
            _bgm10 = value
        End Set
    End Property

    Private _bgm11 As BGMClass
    <Category("BGM")>
    <Description("Song name displayed in game.")>
    Public Property BGM11() As BGMClass
        Get
            Return _bgm11
        End Get
        Set(value As BGMClass)
            _bgm11 = value
        End Set
    End Property

    Private _bgm12 As BGMClass
    <Category("BGM")>
    <Description("Song name displayed in game.")>
    Public Property BGM12() As BGMClass
        Get
            Return _bgm12
        End Get
        Set(value As BGMClass)
            _bgm12 = value
        End Set
    End Property

    Private _bgm13 As BGMClass
    <Category("BGM")>
    <Description("Song name displayed in game.")>
    Public Property BGM13() As BGMClass
        Get
            Return _bgm13
        End Get
        Set(value As BGMClass)
            _bgm13 = value
        End Set
    End Property

    Private _bgm14 As BGMClass
    <Category("BGM")>
    <Description("Song name displayed in game.")>
    Public Property BGM14() As BGMClass
        Get
            Return _bgm14
        End Get
        Set(value As BGMClass)
            _bgm14 = value
        End Set
    End Property

    Private _bgm15 As BGMClass
    <Category("BGM")>
    <Description("Song name displayed in game.")>
    Public Property BGM15() As BGMClass
        Get
            Return _bgm15
        End Get
        Set(value As BGMClass)
            _bgm15 = value
        End Set
    End Property

    Private _bgm16 As BGMClass
    <Category("BGM")>
    <Description("Song name displayed in game.")>
    Public Property BGM16() As BGMClass
        Get
            Return _bgm16
        End Get
        Set(value As BGMClass)
            _bgm16 = value
        End Set
    End Property

    Private _bgm17 As BGMClass
    <Category("BGM")>
    <Description("Song name displayed in game.")>
    Public Property BGM17() As BGMClass
        Get
            Return _bgm17
        End Get
        Set(value As BGMClass)
            _bgm17 = value
        End Set
    End Property

    Private _bgm18 As BGMClass
    <Category("BGM")>
    <Description("Song name displayed in game.")>
    Public Property BGM18() As BGMClass
        Get
            Return _bgm18
        End Get
        Set(value As BGMClass)
            _bgm18 = value
        End Set
    End Property

    Private _bgm19 As BGMClass
    <Category("BGM")>
    <Description("Song name displayed in game.")>
    Public Property BGM19() As BGMClass
        Get
            Return _bgm19
        End Get
        Set(value As BGMClass)
            _bgm19 = value
        End Set
    End Property

End Class

<TypeConverter(GetType(BGMClassConverter))>
Public Structure BGMClass

    Private _songName As String
    Public Property SongName As String
        Get
            Return _songName
        End Get
        Set(value As String)
            _songName = value
        End Set
    End Property

    Private _artist As String
    Public Property Artists As String
        Get
            Return _artist
        End Get
        Set(value As String)
            _artist = value
        End Set
    End Property

    Public Sub New(sn As String, a As String)
        SongName = sn
        Artists = a
    End Sub

    Public Overrides Function ToString() As String
        Return SongName & ", " & Artists
    End Function
End Structure

Public Class BGMClassConverter
    Inherits ExpandableObjectConverter

    Public Overrides Function CanConvertFrom(context As System.ComponentModel.ITypeDescriptorContext, sourceType As System.Type) As Boolean
        If sourceType Is GetType(String) Then
            Return True
        End If
        Return MyBase.CanConvertFrom(context, sourceType)
    End Function

    Public Overloads Overrides Function CanConvertTo(context As System.ComponentModel.ITypeDescriptorContext, destinationType As System.Type) As Boolean
        If destinationType Is GetType(BGMClass) Then
            Return True
        End If
        Return MyBase.CanConvertTo(context, destinationType)
    End Function

    Public Overloads Overrides Function ConvertTo(context As System.ComponentModel.ITypeDescriptorContext, culture As System.Globalization.CultureInfo, value As Object, destinationType As System.Type) As Object
        If destinationType = GetType(String) AndAlso TypeOf value Is BGMClass Then
            DirectCast(value, BGMClass).ToString()
        End If
        Return MyBase.ConvertTo(context, culture, value, destinationType)
    End Function

    Public Overloads Overrides Function ConvertFrom(context As System.ComponentModel.ITypeDescriptorContext, culture As System.Globalization.CultureInfo, value As Object) As Object
        On Error Resume Next
        If TypeOf value Is String Then
            Dim bgmString = TryCast(value, String)
            Dim bgmStrArray = bgmString.Split({", "}, StringSplitOptions.RemoveEmptyEntries)
            If bgmStrArray.Count = 2 Then
                Dim sn As String = bgmStrArray(0)
                Dim a As String = bgmStrArray(1)
                Return New BGMClass(sn, a)
            End If
        End If
        Return MyBase.ConvertFrom(context, culture, value)
    End Function
End Class