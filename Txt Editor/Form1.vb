Public Class Form1
    Dim drag As Boolean
    Dim mouseX As Integer
    Dim mouseY As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = "Untitled"
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        drag = True
        mouseX = Cursor.Position.X - Me.Left
        mouseY = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - mouseY
            Me.Left = Cursor.Position.X - mouseX
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        drag = False
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint
        MyBase.OnPaint(e)
        Dim borderWidth As Integer = 1
        Dim theColor As Color = Color.Blue
        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, theColor, borderWidth, ButtonBorderStyle.Solid, theColor, borderWidth, ButtonBorderStyle.Solid, theColor, borderWidth, ButtonBorderStyle.Solid, theColor, borderWidth, ButtonBorderStyle.Solid)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        MyBase.OnPaint(e)
        Dim borderWidth As Integer = 1
        Dim theColor As Color = Color.Blue
        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, theColor, borderWidth, ButtonBorderStyle.Solid, theColor, borderWidth, ButtonBorderStyle.Solid, theColor, borderWidth, ButtonBorderStyle.Solid, theColor, borderWidth, ButtonBorderStyle.Solid)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Button1.Image = My.Resources.minimize__1_
    End Sub

    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Button2.Image = My.Resources.error__1_
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.Image = My.Resources.minimize
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.Image = My.Resources._error
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
            Button2.Location = New Point(1320, 0)
            Button3.Location = New Point(1280, 0)
            Button1.Location = New Point(1240, 0)
        Else
            Me.WindowState = FormWindowState.Normal
            Button2.Location = New Point(734, 0)
            Button3.Location = New Point(696, 0)
            Button1.Location = New Point(658, 0)
        End If
    End Sub

    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        Button3.Image = My.Resources.full_screen
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Button3.Image = My.Resources.full_screen__1_
    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles Panel1.DoubleClick
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
            Button2.Location = New Point(1320, 0)
            Button3.Location = New Point(1280, 0)
            Button1.Location = New Point(1240, 0)
        Else
            Me.WindowState = FormWindowState.Normal
            Button2.Location = New Point(734, 0)
            Button3.Location = New Point(696, 0)
            Button1.Location = New Point(658, 0)
        End If
    End Sub

    Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs)

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If RichTextBox1.Text.Length > 0 Then
            SaveFileDialog1.Title = "Save Text File"
            SaveFileDialog1.Filter = "Rich Text File (*.rtf)|*.rtf|Plain Text File (*.txt)|*.txt"
            SaveFileDialog1.ShowDialog()
            Dim location As String
            location = SaveFileDialog1.FileName
            My.Computer.FileSystem.WriteAllText(location & ".txt", "" & TextBox1.Text, True)
            TextBox1.Text = SaveFileDialog1.FileName
            MessageBox.Show("File Saved Successfuly")
        Else
            MessageBox.Show("Nothing to save")
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim Str As String
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            TextBox1.Text = OpenFileDialog1.FileName
            Str = OpenFileDialog1.FileName
            RichTextBox1.Text = My.Computer.FileSystem.ReadAllText(Str)
        Else
            MessageBox.Show("Error Occured while opening file. Please retry")
        End If
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        FontDialog1.ShowDialog()
        RichTextBox1.Font = FontDialog1.Font
    End Sub

    Private Sub ColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        RichTextBox1.ForeColor = ColorDialog1.Color
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        RichTextBox1.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        RichTextBox1.Paste()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        RichTextBox1.Cut()
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        RichTextBox1.Undo()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
        RichTextBox1.Redo()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        RichTextBox1.SelectAll()
    End Sub
End Class