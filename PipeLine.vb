Imports System.ComponentModel

Public Class PipeLine
    Private m_DalleLidar As dalle_lidar
    Public ReadOnly Property DalleLidar() As dalle_lidar
        Get
            Return m_DalleLidar
        End Get

    End Property


    Private m_OutNameFile As String
    Public Property OutNameFile() As String
        Get
            Return m_OutNameFile
        End Get
        Set(ByVal value As String)
            m_OutNameFile = value
        End Set
    End Property

    Private m_taillegrille As Double
    Public Property TailleGrille() As Double
        Get
            Return m_taillegrille
        End Get
        Set(ByVal value As Double)
            m_taillegrille = value
        End Set
    End Property
    Private m_classification As Integer
    Public Property Classification() As Integer
        Get
            Return m_classification
        End Get
        Set(ByVal value As Integer)
            m_classification = value
        End Set
    End Property

    Private m_prefixe As String
    Public ReadOnly Property Prefixe() As String
        Get
            Return m_prefixe
        End Get

    End Property
    Public Sub CreatePipeLine()
        Using F As New System.IO.StreamWriter(m_DalleLidar.WorkPath & "\" & m_prefixe & "_" & m_DalleLidar.Radicale & ".json")
            F.WriteLine("{")
            F.WriteLine(Chr(34) & "pipeline" & Chr(34) & ": [")
            F.WriteLine(Chr(34) & m_DalleLidar.JsonName & Chr(34) & ",")
            F.WriteLine("{")
            F.WriteLine(Chr(34) & "type" & Chr(34) & ": " & Chr(34) & "filters.range" & Chr(34) & ",")
            F.WriteLine(Chr(34) & "limits" & Chr(34) & ": " & Chr(34) & "Classification[" & m_classification & ":" & m_classification & "]" & Chr(34))
            F.WriteLine("},")
            F.WriteLine("{")
            F.WriteLine(Chr(34) & "filename" & Chr(34) & ": " & Chr(34) & m_OutNameFile & Chr(34) & ",")
            F.WriteLine(Chr(34) & "gdaldriver" & Chr(34) & ": " & Chr(34) & "GTiff" & Chr(34) & ",")
            F.WriteLine(Chr(34) & "output_type" & Chr(34) & ": " & Chr(34) & "all" & Chr(34) & ",")
            F.WriteLine(Chr(34) & "resolution" & Chr(34) & ": " & Chr(34) & m_taillegrille & Chr(34) & ",")
            F.WriteLine(Chr(34) & "type" & Chr(34) & ": " & Chr(34) & "writers.gdal" & Chr(34))
            F.WriteLine("}")
            F.WriteLine("]")
            F.WriteLine("}")

        End Using
    End Sub

    Public Sub New(dalle_lid As dalle_lidar, prefixe As String, taille As Double, classif As Integer)
        m_DalleLidar = dalle_lid
        m_taillegrille = taille
        m_classification = classif
        m_OutNameFile = Get_JsonFilename(dalle_lid.WorkPath) & "\\" & prefixe & "_" & dalle_lid.Radicale & ".tif"
        m_prefixe = prefixe
    End Sub
End Class
