Public Class Settings
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim validInput As Boolean = True

        Dim maxgenerations As Integer
        Dim pop As Integer
        Dim cross As Double
        Dim reemp As Double
        Dim mutate As Double

        Try
            maxgenerations = Integer.Parse(GenerationsInput.Text)
            pop = Integer.Parse(PopulationSizeInput.Text)
            cross = Double.Parse(CrossoverRateInput.Text)
            reemp = Double.Parse(ReplacementInput.Text)
            mutate = Double.Parse(MutationFactorInput.Text)
        Catch ex As Exception
            MsgBox("Input error")
            validInput = False
        End Try

        If validInput Then
            Form1.maxgenerations = maxgenerations
            Form1.pop = pop
            Form1.cross = cross
            Form1.reemp = reemp
            Form1.mutate = mutate

            Form1.Enabled = True
            Form1.th.Start()
            Me.Close()
        End If

    End Sub
End Class