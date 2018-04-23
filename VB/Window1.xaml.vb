Imports Microsoft.VisualBasic
Imports System.Windows
Imports System.Windows.Controls.Primitives
Imports System.Windows.Input
Imports DevExpress.Xpf.Charts

Namespace DXChartsTooltips

    Partial Public Class Window1
        Inherits Window
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub chartControl1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim point As SeriesPoint = chartControl1.HitTest(e.GetPosition(chartControl1))

            If point IsNot Nothing Then
                tooltip_text.Text = String.Format("Series = {0}" & Constants.vbLf & _
                    "Argument = {1}" & Constants.vbLf & "Value = {2}", _
                    point.Series.DisplayName, point.Argument, point.Value)

                tooltip.Placement = PlacementMode.Mouse
                tooltip.IsOpen = True
                Cursor = Cursors.Hand
            Else
                tooltip.IsOpen = False
                Cursor = Cursors.Arrow
            End If
        End Sub

        Private Sub chartControl1_MouseLeave(ByVal sender As Object, ByVal e As MouseEventArgs)
            tooltip.IsOpen = False
        End Sub

    End Class
End Namespace
