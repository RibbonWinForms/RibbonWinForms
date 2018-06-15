Imports System.Drawing.Drawing2D

Public Class DemoForm
    Private Function GetRandomColor(r As Random) As Color
        If r Is Nothing Then
            r = New Random(DateTime.Now.Millisecond)
        End If
        Return Color.FromKnownColor(CType(r.[Next](1, 150), KnownColor))
    End Function

    Private Sub InitLists()
        Dim images(255) As Image
        BackColor = ribbon1.Theme.RendererColorTable.RibbonBackground
        Dim r = New Random()
        Using path As GraphicsPath = RibbonProfessionalRenderer.RoundRectangle(New Rectangle(3, 3, 26, 26), 4)
            Using RibbonProfessionalRenderer.RoundRectangle(New Rectangle(0, 0, 32, 32), 4)
                For i = 0 To images.Length - 1
                    Dim b = New Bitmap(32, 32)
                    Using g As Graphics = Graphics.FromImage(b)
                        g.SmoothingMode = SmoothingMode.AntiAlias
                        Using br = New SolidBrush(Color.FromArgb(255, i * CInt(255 / images.Length), 0))
                            g.FillPath(br, path)
                        End Using
                        Using p = New Pen(Color.White, 3.0F)
                            g.DrawPath(p, path)
                        End Using
                        g.DrawPath(Pens.Wheat, path)
                        g.DrawString(Convert.ToString(i + 1), Font, Brushes.White, New Point(10, 10))
                    End Using
                    images(i) = b
                    Dim btn = New RibbonButton With {
                            .Image = b
                            }
                    lst.Buttons.Add(btn)
                Next
            End Using
        End Using
        Dim lst2 = New RibbonButtonList()
        For i = 0 To images.Length - 1
            Dim btn = New RibbonButton With {
                    .Image = images(i)
                    }
            lst2.Buttons.Add(btn)
        Next
        lst.DropDownItems.Add(lst2)
        lst.DropDownItems.Add(New RibbonButton("Save selection as a new quick style..."))
        lst.DropDownItems.Add(New RibbonButton("Erase Format"))
        lst.DropDownItems.Add(New RibbonButton("Apply style..."))
        Dim buttons(30) As RibbonButton
        Dim square = 16
        Dim squares = 4
        Dim sqspace = 2
        For i = 0 To buttons.Length - 1
            Dim colors = New Bitmap((square + sqspace) * squares, square + 1)
            Dim colorss(squares) As String
            Using g As Graphics = Graphics.FromImage(colors)
                For j = 0 To 3
                    Dim sqcolor As Color = GetRandomColor(r)
                    colorss(j) = sqcolor.Name
                    Using b2 = New SolidBrush(sqcolor)
                        g.FillRectangle(b2, New Rectangle(j * (square + sqspace), 0, square, square))
                    End Using
                    g.DrawRectangle(Pens.Gray, New Rectangle(j * (square + sqspace), 0, square, square))
                Next
            End Using

            buttons(i) = New RibbonButton(colors) With {
                .Text = String.Join(", ", colorss),
                .MaxSizeMode = RibbonElementSizeMode.Medium,
                .MinSizeMode = RibbonElementSizeMode.Medium
                }
        Next

        Dim blst = New RibbonButtonList(buttons) With {
                .FlowToBottom = False,
                .ItemsSizeInDropwDownMode = New Size(1, 10)
                }
        itemColors.DropDownItems.Insert(0, blst)
        itemColors.DropDownResizable = True
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub ribbonOrbOptionButton1_Click(sender As Object, e As EventArgs) Handles ribbonOrbOptionButton1.Click
        MyBase.Close()
    End Sub

    Private Sub ribbonButton2_Click(sender As Object, e As EventArgs) Handles ribbonButton2.Click
        Dim t = New Form()
        t.ShowDialog(Me)
    End Sub

    Private Sub ribbonButton5_Click(sender As Object, e As EventArgs) Handles ribbonButton5.Click
        Dim t = New Form()
        t.Show(Me)
    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs)
        ribbon1.Minimized = True
    End Sub
End Class