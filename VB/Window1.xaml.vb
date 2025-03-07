Imports System.Windows
Imports System.Windows.Controls.Primitives
Imports System.Windows.Input
Imports DevExpress.Xpf.Charts

Namespace DXChartsTooltips

    Public Partial Class Window1
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub chartControl1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim hitInfo As ChartHitInfo = Me.chartControl1.CalcHitInfo(e.GetPosition(Me.chartControl1))
            If hitInfo IsNot Nothing AndAlso hitInfo.SeriesPoint IsNot Nothing Then
                Dim point As SeriesPoint = hitInfo.SeriesPoint
                Me.tooltip_text.Text = String.Format("Series = {0}" & Microsoft.VisualBasic.Constants.vbLf & "Argument = {1}" & Microsoft.VisualBasic.Constants.vbLf & "Value = {2}", point.Series.DisplayName, point.Argument, point.Value)
                Me.tooltip1.Placement = PlacementMode.Mouse
                Me.tooltip1.IsOpen = True
                Cursor = Cursors.Hand
            Else
                Me.tooltip1.IsOpen = False
                Cursor = Cursors.Arrow
            End If
        End Sub

        Private Sub chartControl1_MouseLeave(ByVal sender As Object, ByVal e As MouseEventArgs)
            Me.tooltip1.IsOpen = False
        End Sub
    End Class
End Namespace
