Public Class dalle_lidar
    Private m_Url As String
    Public Property Url() As String
        Get
            Return m_Url
        End Get
        Set(ByVal value As String)
            m_Url = value
        End Set
    End Property

    Private m_WorkPath As String
    Public Property WorkPath() As String
        Get
            Return m_WorkPath
        End Get
        Set(ByVal value As String)
            m_WorkPath = value
        End Set
    End Property
    Private m_NameFile As String
    Public Property NameFile() As String
        Get
            Return m_NameFile
        End Get
        Set(ByVal value As String)
            m_NameFile = value
        End Set
    End Property
    Private m_JsonName As String
    Public Property JsonName() As String
        Get
            Return m_JsonName
        End Get
        Set(ByVal value As String)
            m_JsonName = value
        End Set
    End Property

    Private m_radicale As String
    Public ReadOnly Property Radicale() As String
        Get
            Return m_radicale
        End Get

    End Property
    Public Sub New(wpath As String, myUrl As String)
        m_Url = myUrl
        m_WorkPath = wpath
        Dim s() As String = myUrl.Split("/")
        m_NameFile = s(UBound(s, 1))
        m_JsonName = m_WorkPath.Replace("\", "\\") & "\\" & m_NameFile
        m_radicale = m_NameFile.Split(".")(0)
    End Sub

    Public Function Existe() As Boolean
        If System.IO.File.Exists(m_WorkPath & "\" & m_NameFile) Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
