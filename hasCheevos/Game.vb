Public Class Game
    Private _Name As String
    Private _ID As Integer
    Private _HasCheevos As Boolean ' doesn't seem to be correct... GB ID 537 has TRUE, but there's no hash value attached
    Private _Hashes As New List(Of String)

    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
        End Set
    End Property
    Public Property ID As Integer
        Get
            Return _ID
        End Get
        Set(value As Integer)
            _ID = value
        End Set
    End Property
    Public Property HasCheevos As Boolean
        Get
            Return _HasCheevos
        End Get
        Set(value As Boolean)
            _HasCheevos = value
        End Set
    End Property
    Public Property Hashes As List(Of String)
        Get
            Return _Hashes
        End Get
        Set(value As List(Of String))
            _Hashes = value
        End Set
    End Property

    Public Sub New(_Name As String, _ID As Integer, _HasCheevos As Boolean)
        Me._Name = _Name
        Me._ID = _ID
        Me._HasCheevos = _HasCheevos
    End Sub
End Class
