Public Class Indiv

    'carac specifies the size of each bar
    'genome specifies where that bar is cut
    'values inside genome go from 0 to carac.Length-1 for bars that will be cut

    Public genome As Integer()  'this indiv config
    Public carac As Integer()   'bar list
    Public mut As Double        'chance of mutation
    Public duty As Integer      'nº of obligatory bars
    Public fit As Long          'this indivs fitness
    Public relative As Double   'relative measure of fitness

    'random initial individuals
    Public Sub New(ByVal _carac As Integer(), ByVal _duty As Integer, ByVal mutate As Double)

        Dim max As Integer = 2 * _duty - 1

        'copy stuff
        carac = _carac.Clone
        duty = _duty
        mut = mutate

        'size genome
        ReDim genome(carac.Count - 1)

        'randomize values BARS WILL BE CUT
        For i = 0 To (duty - 1)
            genome(i) = Math.Round(Rnd() * (duty - 1))
        Next

        'randomize values BARS MIGHT NOT BE CUT
        For i = duty To genome.Length - 1
            genome(i) = Math.Round(Rnd() * (2 * duty - 1))
        Next

        'get fitness
        Fitness()

    End Sub

    'with known genome
    Public Sub New(ByVal _carac As Integer(), ByVal _duty As Integer, ByVal mutate As Double, ByVal genes As Integer())

        'copy stuff
        carac = _carac.Clone
        duty = _duty
        mut = mutate

        'copy genome
        genome = genes.Clone

        'get fitness
        Fitness()

    End Sub

    Public Overrides Function ToString() As String

        Dim txt As String = "["

        For Each gene As Integer In genome
            txt += gene.ToString + ", "
        Next

        txt = txt.Substring(0, txt.Length - 2) + "]"

        Return txt

    End Function

    Public Function Fitness()

        Dim barr(2 * duty - 1) As Integer

        For i = 0 To genome.Length - 1

            barr(genome(i)) += carac(i) 'add bar to where it is cut

        Next

        fit = 0

        For i = 0 To duty - 1

            Dim bar As Integer = barr(i)

            If bar <= 1200 Then

                If Not bar = 0 Then

                    fit += 1200 - bar

                End If

            Else

                If bar <= 1400 Then

                    fit += 1400 - bar

                Else

                    fit += (bar - 1400) * 9999

                End If

            End If

        Next

        'despunte proporcional
        Dim temptot As Integer = 0
        For i = 0 To genome.Length - 1
            If genome(i) < 90 Then
                temptot += carac(i)
            End If
        Next

        relative = fit / temptot * 100

        Return fit

    End Function

    Public Shared Operator *(ByVal I1 As Indiv, ByVal I2 As Indiv)

        Dim g1 As Integer() = I1.genome
        Dim g2 As Integer() = I1.genome
        Dim genes(g1.Length - 1) As Integer

        For i = 0 To g1.Length - 1

            If Rnd() > 0.5 Then

                genes(i) = g1(i)

            Else

                genes(i) = g2(i)

            End If

            If Rnd() <= I1.mut Then

                genes(i) = Math.Round(Rnd() * (2 * I1.duty - 1))

                If i <= I1.duty - 1 Then

                    genes(i) = Math.Round(Rnd() * (I1.duty - 1))

                End If

            End If

        Next

        Return New Indiv(I1.carac, I1.duty, I1.mut, genes)

    End Operator

    Public Function StringifyGenome() As String

        Dim log As String = "["
        For Each el As Integer In genome
            log += el.ToString + ", "
        Next
        log = log.Substring(0, log.Length - 2)
        log += "]"

        Return log

    End Function

    Public Function StringifyCarac() As String

        Dim log As String = "["
        For Each el As Integer In carac
            log += el.ToString + ", "
        Next
        log = log.Substring(0, log.Length - 2)
        log += "]"

        Return log

    End Function

End Class
