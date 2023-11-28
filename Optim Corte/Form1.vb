Imports System.Threading
Imports System.Array
Imports System.IO

Public Class Form1
    'settings
    Public useDefaults As Boolean = False

    'genetic params
    Public maxgenerations As Integer = 600
    Public pop As Integer = 200
    Public cross As Double = 0.25
    Public reemp As Double = 0.25
    Public mutate As Double = 0.01

    'problem params
    Public carac(100) As Integer    'The list of desired rebar lengths
    Public duty As Integer = 90     'Bars that must be cut (the rest are optional) 

    'threading init
    Public th As New Thread(AddressOf RunOptim)

    'runtime variables
    Public viejaInd As Indiv
    Public population(pop - 1) As Indiv
    Public text2print As String = ""
    Public prog As Double = 0.0

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ''load data
        LoadData()

        ''perform cuenta de la vieja
        Dim sort_result = InitSort()
        carac = sort_result(0)
        Dim genome As Integer() = sort_result(1)
        viejaInd = New Indiv(carac, 90, mutate, genome)
        MsgBox("Total excess: " + viejaInd.fit.ToString() + vbNewLine + "Relative excess: " + viejaInd.relative.ToString() + "%" + vbNewLine + "(Values preoptimization)")

        If useDefaults Then
            ''run optimization thread
            th.Start()
        Else
            Me.Enabled = False
            Settings.Show()
        End If

    End Sub


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        th.Abort()
    End Sub

    Public Sub LoadData()
        Dim reader As StreamReader = My.Computer.FileSystem.OpenTextFileReader("data.in")
        Dim txt As String = reader.ReadLine
        duty = Integer.Parse(reader.ReadLine)
        Dim ped = Split(txt, ", ")

        ReDim carac(ped.Length - 1)

        For i = 0 To carac.Length - 1
            carac(i) = Integer.Parse(ped(i))
        Next
    End Sub

    Private Function InitSort()
        'sort carac
        Dim cduty(duty - 1) As Integer                  'array with the bar lenghts that must be cut
        Dim copt(carac.Length - 1 - duty) As Integer    'array with the optional bars

        For i = 0 To duty - 1
            cduty(i) = carac(i)
        Next
        For i = 0 To carac.Length - 1 - duty
            copt(i) = carac(i + duty)
        Next

        Array.Sort(cduty)
        Array.Reverse(cduty)
        Array.Sort(copt)
        Array.Reverse(copt)

        Dim tmpcarac(carac.Length - 1) As Integer   'array with the complete list of bars sorted
        Dim tmpgenome(carac.Length - 1) As Integer  'array representing when each one is cut
        cduty.CopyTo(tmpcarac, 0)
        copt.CopyTo(tmpcarac, cduty.Length)

        Dim n As Integer = 1        'index representing the source bar from which a bar is cut
        While True
            'fill next source bar
            Dim curLen As Integer = 0
            For i = 0 To tmpcarac.Length - 1
                If tmpgenome(i) = 0 Then
                    If curLen + tmpcarac(i) < 1200 Then
                        curLen += tmpcarac(i)
                        tmpgenome(i) = n
                    ElseIf (curLen + tmpcarac(i) < 1400) And (1400 - curLen + tmpcarac(i) < 1200 - curLen) Then
                        curLen += tmpcarac(i)
                        tmpgenome(i) = n
                    End If
                End If
            Next
            n += 1

            'check if done
            Dim done As Boolean = True
            For i = 0 To duty - 1
                If tmpgenome(i) = 0 Then
                    done = False
                    Exit For
                End If
            Next

            'exit if done
            If done Then
                Exit While
            End If
        End While

        'send uncut bars to random unused source bars
        For i = 0 To tmpgenome.Length - 1
            If tmpgenome(i) = 0 Then
                tmpgenome(i) = duty + Math.Floor((duty - 1) * Rnd())
            End If
        Next
        Return {tmpcarac, tmpgenome}
    End Function

    Public Sub RunOptim()

        'randomize
        'Dim uTime As Double
        'uTime = (DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds
        'Randomize((uTime / 100 - Math.Floor(uTime / 100)) * 100)

        'generate population
        Dim currfit(pop - 1) As Integer
        population(0) = viejaInd
        For i = 1 To pop - 1

            population(i) = New Indiv(carac, duty, mutate)
            currfit(i) = population(i).fit

        Next

        Dim currworse As Integer
        Dim tempind As Indiv

        'git gud
        For i = 0 To 300 * pop

            currworse = Array.IndexOf(currfit, currfit.Max())
            tempind = New Indiv(carac, duty, mutate)

            If currfit.Max() > tempind.fit Then

                population(currworse) = tempind
                currfit(currworse) = tempind.fit

            End If

        Next

        'Sort(currfit)
        'For i = 0 To 99
        '    text2print += currfit(i).ToString + vbNewLine
        'Next

        'start mating
        Dim orderdList As System.Collections.Generic.IEnumerable(Of Indiv)
        For j = 1 To maxgenerations

            'order population by fitness
            orderdList = population.Cast(Of Indiv)().OrderBy(Function(i As Indiv) Convert.ToInt32(i.fit))

            'copy order
            For i = 0 To pop - 1
                population(i) = orderdList(i)
            Next

            'start mating
            Dim r1 As Integer
            Dim r2 As Integer

            'inbred
            For i = Math.Floor((1 - reemp) * pop) To Math.Floor((1 - reemp / 2) * pop)
                r1 = Math.Floor(cross * (pop - 1) * Rnd())
                r2 = Math.Floor(Math.Min(2 * cross, 0.5) * (pop - 1) * Rnd())
                population(i) = population(r1) * population(r2)
            Next

            'outbred
            For i = Math.Floor(0.87 * pop) + 1 To pop - 1
                r1 = Math.Floor(cross * (pop - 1) * Rnd())
                r2 = Math.Floor(pop * Rnd())
                population(i) = population(r1) * population(r2)
            Next

            text2print += "Generation: " + (j - 1).ToString + ", Bestfit=" + population(0).fit.ToString + vbNewLine
            prog = 100 * j / maxgenerations

        Next

        text2print += "------------------------------------------------------" + vbNewLine + "LAST GENERATION ELEMENTS' FITNESS" + vbNewLine
        For i = 0 To pop - 1
            text2print += orderdList(i).fit.ToString + ", "
        Next
        text2print += vbNewLine

        text2print += "------------------------------------------------------" + vbNewLine + "BEST INDIVIDUAL GENOME" + vbNewLine

        Dim genome_string = population(0).StringifyGenome()
        text2print += genome_string + vbNewLine

        text2print += "------------------------------------------------------" + vbNewLine + "PROPORTIONAL EXCEDENT" + vbNewLine
        text2print += (population(0).relative).ToString

        'save to file
        If Not System.IO.File.Exists("data.out") = True Then
            Dim file As System.IO.FileStream
            file = System.IO.File.Create("data.out")
            file.Close()
        End If
        My.Computer.FileSystem.WriteAllText("data.out", genome_string + vbNewLine + population(0).StringifyCarac, False)

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

        If Not text2print = "" Then

            TextBox1.Text += text2print
            text2print = ""

            TextBox1.SelectionStart = TextBox1.Text.Length
            TextBox1.ScrollToCaret()

        End If

        ProgressBar1.Value = prog

    End Sub

End Class
