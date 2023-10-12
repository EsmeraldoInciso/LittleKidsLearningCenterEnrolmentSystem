Public Class levelPage
    Private temporaryLevelName As String = ""
    Private temporaryLevelStatus As String = ""
    Private Sub levelPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        reset()
        RefreshDatagrid()
    End Sub

    Public Sub reset()
        txtLevelID.Text = ""
        txtLevelDesc.Text = ""
        cmbStatus.Text = "Yes"
        txtSearch.Text = ""

        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnAdd.Enabled = True
    End Sub

    Private Sub isViewing()
        btnDelete.Enabled = True
        btnUpdate.Enabled = True
        btnAdd.Enabled = False
    End Sub

    Private Sub RefreshDatagrid()
        Try
            reloadLevelDatagrid("SELECT * FROM tbl_level", dgvLevel)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvLevel_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLevel.CellClick
        txtLevelID.Text = dgvLevel.CurrentRow.Cells(0).Value
        txtLevelDesc.Text = dgvLevel.CurrentRow.Cells(1).Value
        temporaryLevelName = dgvLevel.CurrentRow.Cells(1).Value
        cmbStatus.Text = dgvLevel.CurrentRow.Cells(2).Value
        temporaryLevelStatus = dgvLevel.CurrentRow.Cells(2).Value

        isViewing()
    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If txtLevelDesc.Text = "" Then
                MessageBox.Show("LEVEL DESCRIPTION IS REQUIRED. PLEASE ENSURE TO ADD LEVEL DESCRIPTION.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                createLevel("INSERT INTO tbl_level (LevelDesc, IsActive) VALUES ('" & txtLevelDesc.Text & "', '" & cmbStatus.SelectedItem & "')", txtLevelDesc.Text)
                reset()
                RefreshDatagrid()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If txtLevelDesc.Text <> temporaryLevelName Or cmbStatus.SelectedItem <> temporaryLevelStatus Then
                updateLevel("UPDATE tbl_level SET LevelDesc = '" & txtLevelDesc.Text & "', IsActive = '" & cmbStatus.SelectedItem & "' WHERE LevelID = '" & txtLevelID.Text & "'", txtLevelDesc.Text)
            Else
                MessageBox.Show("SAME VALUE. NO CHANGES IN DATABASE", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        reset()
        RefreshDatagrid()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            deleteLevel("DELETE FROM tbl_level WHERE LevelID = '" & txtLevelID.Text & "'")
            reset()
            RefreshDatagrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        reset()
    End Sub


    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            reloadLevelDatagrid("SELECT * FROM tbl_level WHERE LevelID LIKE'%" & txtSearch.Text & "%' OR LevelDesc LIKE '%" & txtSearch.Text & "%' OR IsActive LIKE '%" & txtSearch.Text & "%'", dgvLevel)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class