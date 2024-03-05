Option Explicit On
Imports System.Security.Policy
Imports Girtec.Geo

Module VariableGlobale


    Private Structure STARTUPINFO
        Dim cb As Long
        Dim lpReserved As String
        Dim lpDesktop As String
        Dim lpTitle As String
        Dim dwX As Long
        Dim dwY As Long
        Dim dwXSize As Long
        Dim dwYSize As Long
        Dim dwXCountChars As Long
        Dim dwYCountChars As Long
        Dim dwFillAttribute As Long
        Dim dwFlags As Long
        Dim wShowWindow As Integer
        Dim cbReserved2 As Integer
        Dim lpReserved2 As Long
        Dim hStdInput As Long
        Dim hStdOutput As Long
        Dim hStdError As Long
    End Structure

    Private Structure PROCESS_INFORMATION
        Dim hProcess As Long
        Dim hThread As Long
        Dim dwProcessID As Long
        Dim dwThreadID As Long
    End Structure

    Private Declare Function WaitForSingleObject Lib "kernel32" (ByVal _
hHandle As Long, ByVal dwMilliseconds As Long) As Long

    Private Declare Function CreateProcessA Lib "kernel32" (ByVal _
lpApplicationName As Long, ByVal lpCommandLine As String, ByVal _
lpProcessAttributes As Long, ByVal lpThreadAttributes As Long,
ByVal bInheritHandles As Long, ByVal dwCreationFlags As Long,
ByVal lpEnvironment As Long, ByVal lpCurrentDirectory As Long,
lpStartupInfo As STARTUPINFO, lpProcessInformation As _
PROCESS_INFORMATION) As Long

    Private Declare Function CloseHandle Lib "kernel32" (ByVal _
hObject As Long) As Long

    Private Const NORMAL_PRIORITY_CLASS = &H20&
    Private Const INFINITE = -1&
    ' Public mFint As FormIntegration
    Public typeintegration As Integer = -1
    Public verrou_candidat As New Object
    Public verrou_tampon As New Object
    Public verrou_parcelle As New Object
    Public arret_recherche As Boolean = False
    Public finedigeo As Boolean = False


    Public SRID As Integer = 2154
    Public UserSchemaName As String

    Public RayonSelection As Double = 2
    Public cheminhypo As String = "\\Serveur-ad\ftp\BIA\"
    Public SchemaNameA2iA As String = "a2ia"
    Public millesime As String = "2023"



    Public TopoName As String = "topo2023"
    Public TopoGenName As String = "topogen2023"
    Public TopoComName As String = "topocommune2023"

    Public ListeDalle As System.Collections.Generic.List(Of dalle_lidar)




    Public Function Get_JsonFilename(pathAndnamefile As String) As String

        Return pathAndnamefile.Replace("\", "\\")

    End Function




    Public Function ColorTranslation(ByVal coloint As Integer) As Color
        If Math.Sign(coloint) = -1 Then
            Return Color.FromArgb(coloint)
        Else
            Dim A, R, G, B As Integer
            Dim stcolor As String = System.Convert.ToString(coloint, 16)
            stcolor = stcolor.PadLeft(6, "0"c)
            A = 255
            B = System.Convert.ToInt32(stcolor.Substring(0, 2), 16)
            G = System.Convert.ToInt32(stcolor.Substring(2, 2), 16)
            R = System.Convert.ToInt32(stcolor.Substring(4, 2), 16)
            Return System.Drawing.Color.FromArgb(A, R, G, B)
        End If
    End Function








    Function GetUserName() As String
        If TypeOf My.User.CurrentPrincipal Is
        Security.Principal.WindowsPrincipal Then
            ' The application is using Windows authentication.
            ' The name format is DOMAIN\USERNAME.
            Dim parts() As String = Split(My.User.Name, "\")
            Dim username As String = parts(1).ToLower()
            Return username
        Else
            ' The application is using custom authentication.
            Return My.User.Name
        End If
    End Function








    Private _debugsw As New IO.StreamWriter(Date.Now().ToShortDateString().Replace("/", "-") & "_" & Date.Now().ToShortTimeString().Replace(":", "-") & ".log") With {
            .AutoFlush = True
        }
    Private _debuglock As New Object()
    Friend Sub Debug(v As String)
        SyncLock _debuglock
            _debugsw.WriteLine(v)
        End SyncLock
    End Sub


    Public Sub ExecCmd(cmdline As String)
        Dim proc As PROCESS_INFORMATION
        Dim start As STARTUPINFO
        Dim ReturnValue As Integer

        ' Initialize the STARTUPINFO structure: 
        start.cb = Len(start)

        ' Start the shelled application: 
        ReturnValue = CreateProcessA(0&, cmdline$, 0&, 0&, 1&,
NORMAL_PRIORITY_CLASS, 0&, 0&, start, proc)

        ' Wait for the shelled application to finish: 
        Do
            ReturnValue = WaitForSingleObject(proc.hProcess, 0)
            My.Application.DoEvents()
        Loop Until ReturnValue <> 258

        ReturnValue = CloseHandle(proc.hProcess)
    End Sub

    Public Enum Classification_LIDAR
        Non_Classe = 1
        Sol = 2
        Veg_b = 3
        Veg_m = 4
        Veg_h = 5
        Bati = 6
        Eau = 9
        Pont = 17
        Sursol = 64
        Artefact = 65
        Pv = 66
        Divers = 67
    End Enum


End Module
