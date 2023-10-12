Public Class studentPage
    Private temporaryStudentNumber As String = ""
    Private temporaryStudentFirstname As String = ""
    Private temporaryStudentLastname As String = ""
    Private temporaryStudentMiddlename As String = ""
    Private temporaryStudentBirthdate As String = ""
    Private temporaryStudentGender As String = ""
    Private temporaryStudentContactNumber As String = ""

    Private temporaryStudentAddress As String = ""
    Private temporaryStudentCity As String = ""
    Private temporaryStudentZip As String = ""
    Private temporaryStudentParentName As String = ""
    Private temporaryStudentParentRelationship As String = ""
    Private temporaryStudentParentContactNumber As String = ""
    Private temporaryLevelID As String = ""
    Private temporaryIsActive As String = ""

    Private Sub studentPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        reset()
        RefreshDatagrid()
        RefreshCombobox()
    End Sub

    Private Sub reset()
        txtStudentID.Text = ""
        txtSearch.Text = ""
        txtStudentAddress.Text = ""
        txtStudentCity.Text = ""
        txtStudentContactNumber.Text = ""
        txtStudentFirstname.Text = ""
        txtStudentLastname.Text = ""
        txtStudentMiddlename.Text = ""
        txtStudentNumber.Text = ""
        txtStudentParentContactNumber.Text = ""
        txtStudentParentName.Text = ""
        txtStudentParentRelationship.Text = ""
        txtStudentZip.Text = ""
        dtpStudentBirthdate.Text = "January 1, 1990"
        cmbLevelID.Text = ""
        cmbStatus.Text = "Yes"
        cmbStudentGender.Text = "Male"

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
            reloadStudentDatagrid("SELECT * FROM tbl_student", dgvStudent)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        homePage.RefreshDatagrid()
    End Sub

    Private Sub RefreshCombobox()
        Try
            reloadStudentCombobox("SELECT * FROM tbl_level", cmbLevelID)
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message)
        End Try
    End Sub


    Private Sub dgvStudent_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStudent.CellClick
        txtStudentID.Text = dgvStudent.CurrentRow.Cells(0).Value
        txtStudentAddress.Text = dgvStudent.CurrentRow.Cells(8).Value
        temporaryStudentAddress = dgvStudent.CurrentRow.Cells(8).Value

        txtStudentCity.Text = dgvStudent.CurrentRow.Cells(9).Value
        temporaryStudentCity = dgvStudent.CurrentRow.Cells(9).Value

        txtStudentContactNumber.Text = dgvStudent.CurrentRow.Cells(7).Value
        temporaryStudentContactNumber = dgvStudent.CurrentRow.Cells(7).Value

        txtStudentFirstname.Text = dgvStudent.CurrentRow.Cells(2).Value
        temporaryStudentFirstname = dgvStudent.CurrentRow.Cells(2).Value

        txtStudentLastname.Text = dgvStudent.CurrentRow.Cells(3).Value
        temporaryStudentLastname = dgvStudent.CurrentRow.Cells(3).Value

        txtStudentMiddlename.Text = dgvStudent.CurrentRow.Cells(4).Value
        temporaryStudentMiddlename = dgvStudent.CurrentRow.Cells(4).Value

        txtStudentNumber.Text = dgvStudent.CurrentRow.Cells(1).Value
        temporaryStudentNumber = dgvStudent.CurrentRow.Cells(1).Value

        txtStudentParentContactNumber.Text = dgvStudent.CurrentRow.Cells(13).Value
        temporaryStudentParentContactNumber = dgvStudent.CurrentRow.Cells(13).Value

        txtStudentParentName.Text = dgvStudent.CurrentRow.Cells(11).Value
        temporaryStudentParentName = dgvStudent.CurrentRow.Cells(11).Value

        txtStudentParentRelationship.Text = dgvStudent.CurrentRow.Cells(12).Value
        temporaryStudentParentRelationship = dgvStudent.CurrentRow.Cells(12).Value

        txtStudentZip.Text = dgvStudent.CurrentRow.Cells(10).Value
        temporaryStudentZip = dgvStudent.CurrentRow.Cells(10).Value

        dtpStudentBirthdate.Text = dgvStudent.CurrentRow.Cells(5).Value
        temporaryStudentBirthdate = dgvStudent.CurrentRow.Cells(5).Value

        cmbLevelID.SelectedValue = dgvStudent.CurrentRow.Cells(14).Value
        temporaryLevelID = dgvStudent.CurrentRow.Cells(14).Value

        cmbStatus.SelectedItem = dgvStudent.CurrentRow.Cells(15).Value
        temporaryIsActive = dgvStudent.CurrentRow.Cells(15).Value

        cmbStudentGender.SelectedItem = dgvStudent.CurrentRow.Cells(6).Value
        temporaryStudentGender = dgvStudent.CurrentRow.Cells(6).Value

        isViewing()
    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If txtStudentAddress.Text = "" And txtStudentCity.Text = "" And txtStudentFirstname.Text = "" And txtStudentLastname.Text = "" And txtStudentNumber.Text = "" And txtStudentParentContactNumber.Text = "" And txtStudentParentName.Text = "" And txtStudentParentRelationship.Text = "" And txtStudentZip.Text = "" Then
                MessageBox.Show("ALL FIELDS OTHER THAN STUDENT MIDDLENAME AND STUDENT CONTACT ARE REQUIRED.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                createStudent("INSERT INTO tbl_student (StudentNumber, StudentFirstname, StudentLastname, StudentStudentMiddlename, StudentBirthdate, StudentGender, StudentContactNumber, StudentAddress, StudentCity, StudentZip, StudentParentName, StudentParentRelationship, StudentParentContactNumber, LevelID, IsActive) VALUES ('" & txtStudentNumber.Text & "', '" & txtStudentFirstname.Text & "', '" & txtStudentLastname.Text & "', '" & txtStudentMiddlename.Text & "', '" & dtpStudentBirthdate.Text & "', '" & cmbStudentGender.SelectedItem & "', '" & txtStudentContactNumber.Text & "', '" & txtStudentAddress.Text & "', '" & txtStudentCity.Text & "', '" & txtStudentZip.Text & "', '" & txtStudentParentName.Text & "', '" & txtStudentParentRelationship.Text & "', '" & txtStudentParentContactNumber.Text & "', '" & cmbLevelID.SelectedValue & "', '" & cmbStatus.SelectedItem & "')", txtStudentNumber.Text)
                reset()
                RefreshDatagrid()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If txtStudentAddress.Text <> temporaryStudentAddress Or txtStudentCity.Text <> temporaryStudentCity Or txtStudentFirstname.Text <> temporaryStudentFirstname Or txtStudentLastname.Text <> temporaryStudentLastname Or txtStudentNumber.Text <> temporaryStudentNumber Or txtStudentParentContactNumber.Text <> temporaryStudentParentContactNumber Or txtStudentParentName.Text <> temporaryStudentParentName Or txtStudentParentRelationship.Text <> temporaryStudentParentRelationship Or txtStudentZip.Text <> temporaryStudentZip Or dtpStudentBirthdate.Text <> temporaryStudentBirthdate Or cmbLevelID.SelectedValue <> temporaryLevelID Or cmbStatus.SelectedItem <> temporaryIsActive Or cmbStudentGender.SelectedItem <> temporaryStudentGender Then
                updateStudent("UPDATE tbl_student SET StudentNumber = '" & txtStudentNumber.Text & "', StudentFirstname = '" & txtStudentFirstname.Text & "', StudentLastname = '" & txtStudentLastname.Text & "', StudentStudentMiddlename = '" & txtStudentMiddlename.Text & "', StudentBirthdate = '" & dtpStudentBirthdate.Text & "', StudentGender = '" & cmbStudentGender.SelectedItem & "', StudentContactNumber = '" & txtStudentContactNumber.Text & "', StudentAddress = '" & txtStudentAddress.Text & "', StudentCity = '" & txtStudentCity.Text & "', StudentZip = '" & txtStudentZip.Text & "', StudentParentName = '" & txtStudentParentName.Text & "', StudentParentRelationship = '" & txtStudentParentRelationship.Text & "', StudentParentContactNumber = '" & txtStudentParentContactNumber.Text & "', LevelID = '" & cmbLevelID.SelectedValue & "', IsActive = '" & cmbStatus.SelectedItem & "' WHERE StudentID = '" & txtStudentID.Text & "'", txtStudentNumber.Text)
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
            deleteStudent("DELETE FROM tbl_student WHERE StudentID = '" & txtStudentID.Text & "'")
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
            reloadStudentDatagrid("SELECT * FROM tbl_student WHERE StudentID LIKE'%" & txtSearch.Text & "%' OR StudentNumber LIKE '%" & txtSearch.Text & "%' OR StudentFirstname LIKE '%" & txtSearch.Text & "%' OR StudentLastname LIKE '%" & txtSearch.Text & "%' OR StudentStudentMiddlename LIKE '%" & txtSearch.Text & "%' OR StudentBirthdate LIKE '%" & txtSearch.Text & "%' OR StudentGender LIKE '%" & txtSearch.Text & "%' OR StudentContactNumber LIKE '%" & txtSearch.Text & "%' OR StudentAddress LIKE '%" & txtSearch.Text & "%' OR StudentCity LIKE '%" & txtSearch.Text & "%' OR StudentZip LIKE '%" & txtSearch.Text & "%' OR StudentParentName LIKE '%" & txtSearch.Text & "%' OR StudentParentRelationship LIKE '%" & txtSearch.Text & "%' OR StudentParentContactNumber LIKE '%" & txtSearch.Text & "%' OR LevelID LIKE '%" & txtSearch.Text & "%' OR IsActive LIKE '%" & txtSearch.Text & "%'", dgvStudent)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class