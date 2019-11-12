Public Class ScanResult
    Private _file As String
    Private _innerFile As String
    Private _Name As String
    Private _MD5 As String
    Private _hasCheevos As Boolean

    Public Property File As String
        Get
            Return _file
        End Get
        Set(value As String)
            _file = value
        End Set
    End Property
    Public Property InnerFile As String
        Get
            Return _innerFile
        End Get
        Set(value As String)
            _innerFile = value
        End Set
    End Property
    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
        End Set
    End Property
    Public Property MD5 As String
        Get
            Return _MD5
        End Get
        Set(value As String)
            _MD5 = value
        End Set
    End Property
    Public Property HasCheevos As Boolean
        Get
            Return _hasCheevos
        End Get
        Set(value As Boolean)
            _hasCheevos = value
        End Set
    End Property

    Public Sub New()
        Me.HasCheevos = False
    End Sub

    Public Sub New(INfile As String)
        Me.File = INfile

        Me.HasCheevos = False
    End Sub

    Public Sub New(INfile As String, INinnerFile As String)
        Me.File = INfile
        Me.InnerFile = INinnerFile

        Me.HasCheevos = False
    End Sub
End Class
