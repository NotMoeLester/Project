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

            MessageBox.Show("Data Written SuccessFully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub


    Private Sub ButtonRead_Click(sender As Object, e As EventArgs) Handles ButtonRead.Click

        Using reader As New StreamReader(filePath)
            Dim content As String = reader.ReadToEnd()
            MessageBox.Show("File Content: " + content + vbCrLf)
        End Using

    End Sub


    Private Sub ButtonSort_Click(sender As Object, e As EventArgs) Handles ButtonSort.Click

    End Sub



End Class
