Imports System.Text.RegularExpressions

Public Class VGSystem
    Private _Name As String
    Private _ShortName As String
    Private _Index As Integer
    Private _Extensionlist As String()
    Private _Gamelist As New List(Of Game)

    Public GamesWithCheevos As New List(Of String)
    Public GamesWithoutCheevos As New List(Of String)

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

    Public Function hasMetadata(metaDir As String) As Boolean
        log("Checking metadata files for " & Me.Name & "...")

        If (My.Computer.FileSystem.FileExists(metaDir & "\" & Me.ShortName & ".json") AndAlso My.Computer.FileSystem.FileExists(metaDir & "\" & Me.ShortName & ".txt")) Then
            log(vbTab & "OK, metadata files found")

            Return True
        End If

        log(vbTab & "ERROR, metadata file(s) missing")
        Return False
    End Function

    Public Function clearMetadata(metaDir As String) As Integer
        log("Clearing old metadata files for " & Me.Name & "...")

        Try
            If (My.Computer.FileSystem.FileExists(metaDir & "\" & Me.ShortName & ".json")) Then
                My.Computer.FileSystem.DeleteFile(metaDir & "\" & Me.ShortName & ".json")
            End If

            If (My.Computer.FileSystem.FileExists(metaDir & "\" & Me.ShortName & ".txt")) Then
                My.Computer.FileSystem.DeleteFile(metaDir & "\" & Me.ShortName & ".txt")
            End If

            log(vbTab & "OK, cleared metadata files")

            Return 0
        Catch ex As Exception
            log(vbTab & "ERROR, could not clear old metadata files")

            Return -1
        End Try
    End Function

    Public Function getMetadata(siteURL As String, githubURL As String, metaDir As String) As Integer
        log("Getting metadata files for " & Me.Name & "...")

        log(vbTab & "getting hashfile...")
        If (download(siteURL & "/dorequest.php?r=hashlibrary&c=" & Me.Index, metaDir & "\" & Me.ShortName & ".json") = 0) Then
            log(vbTab & vbTab & "OK, got hashfile")
        Else
            log(vbTab & vbTab & "ERROR while getting hashfile")

            Return -1
        End If

        log(vbTab & "getting gamelist...")
        If (download(githubURL & "/" & Me.ShortName & "_hascheevos.txt", metaDir & "\" & Me.ShortName & ".txt") = 0) Then
            log(vbTab & vbTab & "OK, got gamelist")
        Else
            log(vbTab & vbTab & "ERROR while getting gamelist")

            Return -2
        End If

        Return 0
    End Function

    Public Sub readMetadata(metaDir As String)
        Dim reader As Global.System.IO.StreamReader
        Dim split As String()

        log("Reading metadata files for " & Me.Name & "...")

        ' read hashlist file into hashes
        log(vbTab & "reading hashlist...")

        ' read whole file
        reader = My.Computer.FileSystem.OpenTextFileReader(metaDir & "\" & Me.ShortName & ".json", Text.Encoding.UTF8)
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

        log(vbTab & vbTab & "OK, got " & hashes.Count() & " hashes")


        ' read gamelist file into Gamelist
        log(vbTab & "reading gamelist...")

        Dim line As String
        Dim game As Game
        Dim gameHashes

        reader = My.Computer.FileSystem.OpenTextFileReader(metaDir & "\" & Me.ShortName & ".txt", Text.Encoding.UTF8)

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

        log(vbTab & vbTab & "OK, got " & Me.Gamelist.Count() & " games")
    End Sub

    Public Sub checkFilesForCheevos(path As String, tempDir As String)
        Dim allFiles As Integer = 0
        Dim scannedFiles As Integer = 0
        Dim ROMsWithCheevos As Integer = 0

        log("Checking ROMs in " & path)
        setStatus("Scanning...")

        Dim fileExt As String
        Dim fileMD5 As String
        ' TODO add 7z
        Dim archiveExt As String() = {"*.zip"}

        ' list all files with SYSTEM and ARCHIVE extensions
        Dim files = My.Computer.FileSystem.GetFiles(path, FileIO.SearchOption.SearchAllSubDirectories, Me.Extensionlist.Concat(archiveExt).ToArray)
        ' TODO sort files alphabetically
        files.ToList.Sort()
        allFiles = files.Count()

        setScannedFiles(scannedFiles & " / " & allFiles)

        For Each file In files
            fileExt = System.IO.Path.GetExtension(file).Replace(".", "*.")

            If (archiveExt.Contains(fileExt)) Then
                ' for each ARCHIVE in files...
                log(vbTab & "found ARCHIVE """ & file & """")

                log(vbTab & vbTab & "extracting archive...")
                extractArchive(file, tempDir)

                For Each extractedFile In My.Computer.FileSystem.GetFiles(tempDir, FileIO.SearchOption.SearchAllSubDirectories, Me.Extensionlist)
                    log(vbTab & vbTab & "found ROM """ & extractedFile & """")

                    fileMD5 = getMD5(extractedFile).ToLower
                    log(vbTab & vbTab & vbTab & "MD5 Hash: " & fileMD5)

                    Dim query = From game As Game In Gamelist Where game.Hashes.Contains(fileMD5) Select game
                    If query.Count = 1 Then
                        log(vbTab & vbTab & vbTab & "found entry: " & query(0).Name)

                        Me.GamesWithCheevos.Add(file & "#" & System.IO.Path.GetFileName(extractedFile))
                        ROMsWithCheevos += 1
                        setROMsWithCheevos(ROMsWithCheevos)
                    Else
                        log(vbTab & vbTab & vbTab & "no entry found")
                        Me.GamesWithoutCheevos.Add(file)
                    End If
                Next

                tidyUp(tempDir)
            Else
                ' for each ROM in files...
                log(vbTab & "found ROM """ & file & """")

                fileMD5 = getMD5(file).ToLower
                log(vbTab & vbTab & "MD5 Hash: " & fileMD5)

                Dim query = From game As Game In Gamelist Where game.Hashes.Contains(fileMD5) Select game
                If query.Count = 1 Then
                    log(vbTab & vbTab & "found entry: " & query(0).Name)

                    Me.GamesWithCheevos.Add(file)
                    ROMsWithCheevos += 1
                    setROMsWithCheevos(ROMsWithCheevos)
                Else
                    log(vbTab & vbTab & "no entry found")
                    Me.GamesWithoutCheevos.Add(file)
                End If
            End If

            scannedFiles += 1
            setScannedFiles(scannedFiles & " / " & allFiles)

            Application.DoEvents()
        Next

        setStatus("Finished")
    End Sub

    Public Function checkFileForCheevos(file As String, tempDir As String, archiveExt As String()) As List(Of ScanResult)
        Dim retList As New List(Of ScanResult)

        Dim fileExt As String
        ' TODO add 7z
        'Dim archiveExt As String() = {"*.zip"}

        fileExt = System.IO.Path.GetExtension(file).Replace(".", "*.")

        If (archiveExt.Contains(fileExt)) Then
            ' for each ARCHIVE in files...

            extractArchive(file, tempDir)

            For Each extractedFile In My.Computer.FileSystem.GetFiles(tempDir, FileIO.SearchOption.SearchAllSubDirectories, Me.Extensionlist)
                Dim retVal As New ScanResult(file, System.IO.Path.GetFileName(extractedFile))

                retVal.MD5 = getMD5(extractedFile).ToLower

                Dim query = From game As Game In Gamelist Where game.Hashes.Contains(retVal.MD5) Select game
                If query.Count = 1 Then
                    retVal.Name = query(0).Name
                    retVal.HasCheevos = True
                End If

                retList.Add(retVal)
            Next

            tidyUp(tempDir)
        Else
            Dim retVal As New ScanResult(file)
            retVal.MD5 = getMD5(file).ToLower

            Dim query = From game As Game In Gamelist Where game.Hashes.Contains(retVal.MD5) Select game
            If query.Count = 1 Then
                retVal.Name = query(0).Name
                retVal.HasCheevos = True
            End If

            retList.Add(retVal)
        End If

        Return retList
    End Function
End Class