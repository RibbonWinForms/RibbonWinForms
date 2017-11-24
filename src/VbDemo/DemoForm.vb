Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class DemoForm
    Private Function GetRandomColor(ByVal r As Random) As Color
        If r Is Nothing Then
            r = New Random(DateTime.Now.Millisecond)
        End If
        Return Color.FromKnownColor(CType(r.[Next](1, 150), KnownColor))
    End Function

    Private Sub InitLists()
        Dim images(255) As Image
        Me.BackColor = Me.ribbon1.Theme.RendererColorTable.RibbonBackground
        Dim r As Random = New Random()
        Using path As GraphicsPath = RibbonProfessionalRenderer.RoundRectangle(New Rectangle(3, 3, 26, 26), 4)
            Using RibbonProfessionalRenderer.RoundRectangle(New Rectangle(0, 0, 32, 32), 4)
                For i As Integer = 0 To images.Length - 1
                    Dim b As Bitmap = New Bitmap(32, 32)
                    Using g As Graphics = Graphics.FromImage(b)
                        g.SmoothingMode = SmoothingMode.AntiAlias
                        Using br As SolidBrush = New SolidBrush(Color.FromArgb(255, i * CInt(255 / images.Length), 0))
                            g.FillPath(br, path)
                        End Using
                        Using p As Pen = New Pen(Color.White, 3.0F)
                            g.DrawPath(p, path)
                        End Using
                        g.DrawPath(Pens.Wheat, path)
                        g.DrawString(Convert.ToString(i + 1), Me.Font, Brushes.White, New Point(10, 10))
                    End Using
                    images(i) = b
                    Dim btn As RibbonButton = New RibbonButton()
                    btn.Image = b
                    Me.lst.Buttons.Add(btn)
                Next
            End Using
        End Using
        Dim lst2 As RibbonButtonList = New RibbonButtonList()
        For i As Integer = 0 To images.Length - 1
            Dim btn As RibbonButton = New RibbonButton()
            btn.Image = images(i)
            lst2.Buttons.Add(btn)
        Next
        Me.lst.DropDownItems.Add(lst2)
        Me.lst.DropDownItems.Add(New RibbonButton("Save selection as a new quick style..."))
        Me.lst.DropDownItems.Add(New RibbonButton("Erase Format"))
        Me.lst.DropDownItems.Add(New RibbonButton("Apply style..."))
        Dim buttons(30) As RibbonButton
        Dim square As Integer = 16
        Dim squares As Integer = 4
        Dim sqspace As Integer = 2
        For i As Integer = 0 To buttons.Length - 1
            Dim colors As Bitmap = New Bitmap((square + sqspace) * squares, square + 1)
            Dim colorss(squares) As String
            Using g As Graphics = Graphics.FromImage(colors)
                For j As Integer = 0 To 3
                    Dim sqcolor As Color = Me.GetRandomColor(r)
                    colorss(j) = sqcolor.Name
                    Using b2 As SolidBrush = New SolidBrush(sqcolor)
                        g.FillRectangle(b2, New Rectangle(j * (square + sqspace), 0, square, square))
                    End Using
                    g.DrawRectangle(Pens.Gray, New Rectangle(j * (square + sqspace), 0, square, square))
                Next
            End Using
            buttons(i) = New RibbonButton(colors)
            buttons(i).Text = String.Join(", ", colorss)
            buttons(i).MaxSizeMode = RibbonElementSizeMode.Medium
            buttons(i).MinSizeMode = RibbonElementSizeMode.Medium
        Next
        Dim blst As RibbonButtonList = New RibbonButtonList(buttons)
        blst.FlowToBottom = False
        blst.ItemsSizeInDropwDownMode = New Size(1, 10)
        Me.itemColors.DropDownItems.Insert(0, blst)
        Me.itemColors.DropDownResizable = True
    End Sub

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub ribbonOrbOptionButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ribbonOrbOptionButton1.Click
        MyBase.Close()
    End Sub

    Private Sub ribbonButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ribbonButton2.Click
        Dim t As Form = New Form()
        t.ShowDialog(Me)
    End Sub

    Private Sub ribbonButton5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ribbonButton5.Click
        Dim t As Form = New Form()
        t.Show(Me)
    End Sub

    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.ribbon1.Minimized = True
    End Sub
End Class