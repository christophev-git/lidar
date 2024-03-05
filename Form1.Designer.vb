<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Button1 = New Button()
        DataGridView1 = New DataGridView()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        OpenFileDialog1 = New OpenFileDialog()
        ProgressBar1 = New ProgressBar()
        ListBox1 = New ListBox()
        Button2 = New Button()
        TBtaille = New TextBox()
        Label1 = New Label()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(12, 12)
        Button1.Name = "Button1"
        Button1.Size = New Size(162, 31)
        Button1.TabIndex = 0
        Button1.Text = "Téléchargement"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(12, 109)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(655, 163)
        DataGridView1.TabIndex = 1
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Location = New Point(12, 67)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(655, 36)
        ProgressBar1.TabIndex = 2
        ' 
        ' ListBox1
        ' 
        ListBox1.FormattingEnabled = True
        ListBox1.ItemHeight = 15
        ListBox1.Location = New Point(12, 318)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(217, 94)
        ListBox1.TabIndex = 3
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(253, 318)
        Button2.Name = "Button2"
        Button2.Size = New Size(208, 29)
        Button2.TabIndex = 4
        Button2.Text = "Create JSON pipeline"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' TBtaille
        ' 
        TBtaille.Location = New Point(398, 287)
        TBtaille.Name = "TBtaille"
        TBtaille.Size = New Size(63, 23)
        TBtaille.TabIndex = 5
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(253, 295)
        Label1.Name = "Label1"
        Label1.Size = New Size(124, 15)
        Label1.TabIndex = 6
        Label1.Text = "Taille cellule raster (m)"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label1)
        Controls.Add(TBtaille)
        Controls.Add(Button2)
        Controls.Add(ListBox1)
        Controls.Add(ProgressBar1)
        Controls.Add(DataGridView1)
        Controls.Add(Button1)
        Name = "Form1"
        Text = "Form1"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Button2 As Button
    Friend WithEvents TBtaille As TextBox
    Friend WithEvents Label1 As Label

End Class
