Imports System.IO
Imports System.Linq

Public Class Form1

    Dim numbers As List(Of Integer)
    Dim filePath As String = "Sample.txt"

    Private Sub ButtonWrite_Click(sender As Object, e As EventArgs) Handles ButtonWrite.Click
        Try
            Using writer As New StreamWriter(filePath, True)
                writer.WriteLine(NumericUpDown1.Value)
            End Using

            MessageBox.Show("Data Written Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


    Private Sub ButtonRead_Click(sender As Object, e As EventArgs) Handles ButtonRead.Click
        Try
            If Not File.Exists(filePath) Then
                MessageBox.Show("File not found!")
                Return
            End If

            Using reader As New StreamReader(filePath)
                Dim content As String = reader.ReadToEnd()

                Dim lines = content.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

                numbers = lines.Select(Function(line) Integer.Parse(line)).ToList()

                ListBox1.Items.Clear()
                ListBox1.Items.Add("File Content:")
                For Each n In numbers
                    ListBox1.Items.Add(n)
                Next
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    'private sub buttonread_click(sender as object, e as eventargs) handles buttonread.click
    '    using reader as new streamreader(filepath)
    '        dim content as string = reader.readtoend()
    '        listbox1.items.add("file content: ")

    '        for each item in content
    '            console.write(listbox1.items.add(item))
    '        next
    '    end using
    'end sub

    Private Sub ButtonSort_Click(sender As Object, e As EventArgs) Handles ButtonSort.Click
        Try
            If numbers Is Nothing OrElse numbers.Count = 0 Then
                MessageBox.Show("No data to sort. Please read data first.")
                Return
            End If

            Dim sortedNumbers = numbers.OrderBy(Function(n) n).ToList()

            ListBox1.Items.Clear()
            For Each n In sortedNumbers
                ListBox1.Items.Add(n)
            Next

            File.WriteAllLines(filePath, sortedNumbers.Select(Function(n) n.ToString()))

            MessageBox.Show("Data sorted and file updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
