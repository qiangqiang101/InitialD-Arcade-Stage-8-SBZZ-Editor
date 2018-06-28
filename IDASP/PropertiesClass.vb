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
    <Description("Store name that shows under player avatar and in-store battle.")>
    Public Property StoreName() As String
        Get
            Return _storeName 'GetName(GetHex(File, &HB7D580, 14))
        End Get
        Set(value As String)
            _storeName = value
        End Set
    End Property

    Public Enum Region
        北海道
        青森県
        岩手県
        宮城県
        福島県
        山形県
        秋田県
        茨城県
        栃木県
        群馬県
        千葉県
        埼玉県
        東京都
        神奈川県
        山梨県
        新潟県
        長野県
        富山県
        石川県
        愛知県
        静岡県
        岐阜県
        三重県
        福井県
        大阪府
        京都府
        奈良県
        滋賀県
        和歌山県
        兵庫県
        広島県
        鳥取県
        島根県
        岡山県
        山口県
        徳島県
        香川県
        愛媛県
        高知県
        福岡県
        佐賀県
        長崎県
        熊本県
        大分県
        宮崎県
        鹿児島県
        沖縄県
        中國CHN
        香港HKG
        韓國SKR
        馬來西亞MYS
        新加坡SGP
        台灣TWN
        印度尼西亞IDN
        菲律賓PHL
        泰國THAI
        美國USA
    End Enum

    Private _storeRegion As Region
    <Category("Name")>
    <Description("Region that shows under player avatar, in-store battle and also affect when buying new cars.")>
    Public Property StoreRegion() As Region
        Get
            Return _storeRegion 'GetName(GetHex(File, &HBF01EC, 6))
        End Get
        Set(value As Region)
            _storeRegion = value
        End Set
    End Property

End Class
