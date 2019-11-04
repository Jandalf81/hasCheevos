Public Class Hash
    Private _MD5 As String
    Private _GameID As Integer

    Public Property MD5 As String
        Get
            Return _MD5
        End Get
        Set(value As String)
            _MD5 = value
        End Set
    End Property
    Public Property GameID As Integer
        Get
            Return _GameID
        End Get
        Set(value As Integer)
            _GameID = value
        End Set
    End Property

    Public Sub New(_MD5 As String, _GameID As Integer)
        Me._MD5 = _MD5
        Me._GameID = _GameID
    End Sub
End Class
