Public Class homePage

    Private Sub btnLevelModule_Click(sender As Object, e As EventArgs) Handles btnLevelModule.Click
        levelPage.ShowDialog()
    End Sub

    Private Sub btnStudentModule_Click(sender As Object, e As EventArgs) Handles btnStudentModule.Click
        studentPage.ShowDialog()
    End Sub

    Public Sub RefreshDatagrid()
        Try
            reloadStudentDatagrid("SELECT * FROM tbl_student", dgvHome)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub homePage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshDatagrid()
    End Sub
End Class
