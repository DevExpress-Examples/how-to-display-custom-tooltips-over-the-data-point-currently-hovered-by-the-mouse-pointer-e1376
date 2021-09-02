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
			Dim hitInfo As ChartHitInfo = chartControl1.CalcHitInfo(e.GetPosition(chartControl1))

			If hitInfo IsNot Nothing AndAlso hitInfo.SeriesPoint IsNot Nothing Then
				Dim point As SeriesPoint = hitInfo.SeriesPoint

				tooltip_text.Text = String.Format("Series = {0}" & vbLf & "Argument = {1}" & vbLf & "Value = {2}", point.Series.DisplayName, point.Argument, point.Value)
				tooltip1.Placement = PlacementMode.Mouse

				tooltip1.IsOpen = True
				Cursor = Cursors.Hand
			Else
				tooltip1.IsOpen = False
				Cursor = Cursors.Arrow
			End If
		End Sub

		Private Sub chartControl1_MouseLeave(ByVal sender As Object, ByVal e As MouseEventArgs)
			tooltip1.IsOpen = False
		End Sub

	End Class
End Namespace
