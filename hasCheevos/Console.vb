Imports HasCheevos

Public Class Console
    Private _Name As String
    Private _ShortName As String
    Private _Index As Integer
    Private _Extensionlist As String()
    Private _Gamelist As New List(Of Game)

    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
        End Set
    End Property
    Public Property ShortName As String
        Get
            Return _ShortName
        End Get
        Set(value As String)
            _ShortName = value
        End Set
    End Property
    Public Property Index As Integer
        Get
            Return _Index
        End Get
        Set(value As Integer)
            _Index = value
        End Set
    End Property
    Public Property Extensionlist As String()
        Get
            Return _Extensionlist
        End Get
        Set(value As String())
            _Extensionlist = value
        End Set
    End Property
    Public Property Gamelist As List(Of Game)
        Get
            Return _Gamelist
        End Get
        Set(value As List(Of Game))
            _Gamelist = value
        End Set
    End Property

    Public Sub New(name As String, shortName As String, index As Integer, extensionList As String())
        Me.Name = name
        Me.ShortName = shortName
        Me.Index = index
        Me.Extensionlist = extensionList
    End Sub

    Public Sub readGamelist(tempDir As String)
        Dim reader As System.IO.StreamReader
        Dim split As String()

        ' read hashlist file into hashes

        ' read whole file
        reader = My.Computer.FileSystem.OpenTextFileReader(tempDir & "\" & Me.ShortName & ".json", System.Text.Encoding.UTF8)
        Dim jsonString As String = reader.ReadToEnd()

        ' clean variable
        jsonString = jsonString.Replace("{""Success"":true,""MD5List"":{", "")
        jsonString = jsonString.Replace("}}", "")

        ' split file by comma-separated entries
        Dim entries As String() = jsonString.Split(",")
        Dim hashes As New List(Of Hash)

        For Each entry In entries
            split = entry.Split(":")

            hashes.Add(New Hash(split(0).Replace("""", ""), split(1)))
        Next


        ' read gamelist file into Gamelist
        Dim line As String
        Dim game As Game
        Dim gameHashes

        reader = My.Computer.FileSystem.OpenTextFileReader(tempDir & "\" & Me.ShortName & ".txt", System.Text.Encoding.UTF8)

        Do
            line = reader.ReadLine()

            If line Is Nothing Then Exit Do

            split = line.Split(":")
            game = New Game(split(2).Replace("""", ""), split(0), split(1))

            ' get hashes from list hashes()
            gameHashes = From hash In hashes Where hash.GameID = split(0)

            ' save found hashes in game
            For Each gameHash In gameHashes
                game.Hashes.Add(gameHash.MD5)
            Next

            Me.Gamelist.Add(game)
        Loop

        reader.Close()
    End Sub
End Class
