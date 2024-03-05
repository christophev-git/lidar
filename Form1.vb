Public Class Form1
    Private m_classif As Integer = -1
    Private m_nomclassif As String = ""
    Public ListeDalle As System.Collections.Generic.List(Of dalle_lidar)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim workpath As String = ""
        FolderBrowserDialog1.Description = "Répertoire de travail"
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            workpath = FolderBrowserDialog1.SelectedPath
        Else
            Exit Sub

        End If
        Dim fichdalle As String = ""
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            fichdalle = OpenFileDialog1.FileName
        Else
            Exit Sub
        End If

        Dim dalle() As String

        Dim i As Integer = -1
        Using sr As New System.IO.StreamReader(fichdalle)
            Do While Not sr.EndOfStream
                i = i + 1
                ReDim Preserve dalle(i)
                dalle(i) = sr.ReadLine
            Loop
        End Using

        ListeDalle = New System.Collections.Generic.List(Of dalle_lidar)




        For i = 0 To UBound(dalle, 1)
            Dim madalle As New dalle_lidar(workpath, dalle(i))
            ListeDalle.Add(madalle)
            'My.Computer.Network.DownloadFile(dalle(i), workpath & "\dalle_" & i)
        Next
        DataGridView1.DataSource = ListeDalle
        ProgressBar1.Minimum = 1
        ProgressBar1.Maximum = ListeDalle.Count
        ProgressBar1.Step = 1
        Dim b As Boolean = False
        For Each d As dalle_lidar In ListeDalle
            b = d.Existe

            If Not b Then

                My.Computer.Network.DownloadFile(d.Url, d.WorkPath & "\" & d.NameFile)

            Else


            End If
            ProgressBar1.PerformStep()
        Next

        MsgBox("Téléchargement terminé", vbApplicationModal, vbInformation)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each s As String In [Enum].GetNames(GetType(Classification_LIDAR))
            ListBox1.Items.Add(s)
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TBtaille.Text = "" Then Exit Sub
        If ListBox1.SelectedIndex < 0 Then Exit Sub
        If ListeDalle Is Nothing Then Exit Sub
        If ListeDalle.Count = 0 Then Exit Sub

        m_nomclassif = ListBox1.SelectedItem
        m_classif = ListBox1.SelectedIndex
        m_classif = [Enum].GetValues(GetType(Classification_LIDAR))(ListBox1.SelectedIndex)
        For Each d As dalle_lidar In ListeDalle

            Dim p1 As New PipeLine(d, m_nomclassif, TBtaille.Text, m_classif)
            p1.CreatePipeLine()

        Next

        MsgBox("Traitement JSON terminé", vbExclamation)
    End Sub
End Class
