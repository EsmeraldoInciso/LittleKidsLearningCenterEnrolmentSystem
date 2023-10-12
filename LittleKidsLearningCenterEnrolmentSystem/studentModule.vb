Imports MySql.Data.MySqlClient
Module studentModule

    Public Sub createStudent(ByVal sql As String, ByVal stringToCheck As String)
        Try
            strcon.Open()
            With cmd
                .Connection = strcon
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MessageBox.Show("STUDENT ALREADY EXISTS IN DATABASE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("STUDENT HAS BEEN ADDED", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End With
        Catch ex As Exception
            If ex.Message.ToLower = "duplicate entry '" & stringToCheck.ToLower & "' for key 'BrandName'" Then
                MessageBox.Show("STUDENT ALREADY EXISTS IN DATABASE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Finally
            strcon.Close()
        End Try
    End Sub

    Public Sub reloadStudentDatagrid(ByVal sql As String, ByVal dtv As Object)
        Try
            dt = New DataTable
            strcon.Open()
            With cmd
                .Connection = strcon
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            dtv.datasource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            strcon.Close()
            da.Dispose()
        End Try
    End Sub

    Public Sub reloadStudentCombobox(ByVal sql As String, ByVal cmbo As ComboBox)
        Try
            dt = New DataTable
            strcon.Open()
            With cmd
                .Connection = strcon
                .CommandText = sql
            End With
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(dt)
            cmbo.DataSource = dt
            cmbo.DisplayMember = "LevelDesc"
            cmbo.ValueMember = "LevelID"
        Catch ex As Exception
            MessageBox.Show("Error   :" + ex.Message)
        Finally
            strcon.Close()
            da.Dispose()
        End Try
    End Sub

    Public Sub updateStudent(ByVal sql As String, ByVal stringToCheck As String)
        Try
            strcon.Open()
            With cmd
                .Connection = strcon
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MessageBox.Show("STUDENT ALREADY EXISTS IN DATABASE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("STUDENT HAS BEEN UPDATED", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End With
        Catch ex As Exception

            If ex.Message.ToLower = "duplicate entry '" & stringToCheck.ToLower & "' for key 'Level'" Then
                MessageBox.Show("STUDENT EXISTS IN DATABASE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Finally
            strcon.Close()
        End Try
    End Sub

    Public Sub deleteStudent(ByVal sql As String)
        Try
            strcon.Open()
            With cmd
                .Connection = strcon
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MessageBox.Show("Student cannot be deleted. This item is referred to by another object.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("STUDENT HAS BEEN DELETED", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            strcon.Close()
        End Try
    End Sub

End Module
