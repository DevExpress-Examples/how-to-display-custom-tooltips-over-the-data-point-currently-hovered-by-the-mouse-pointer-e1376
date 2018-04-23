using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using DevExpress.Xpf.Charts;

namespace DXChartsTooltips {

    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
        }

        private void chartControl1_MouseMove(object sender, MouseEventArgs e) {
            ChartHitInfo hitInfo = chartControl1.CalcHitInfo(e.GetPosition(chartControl1));
            
            if (hitInfo != null && hitInfo.SeriesPoint != null) {
                SeriesPoint point = hitInfo.SeriesPoint;

                tooltip_text.Text = string.Format("Series = {0}\nArgument = {1}\nValue = {2}",
                    point.Series.DisplayName, point.Argument, point.Value);
                tooltip1.Placement = PlacementMode.Mouse;
                
                tooltip1.IsOpen = true;
                Cursor = Cursors.Hand;
            }
            else {
                tooltip1.IsOpen = false;
                Cursor = Cursors.Arrow;
            }
        }

        private void chartControl1_MouseLeave(object sender, MouseEventArgs e) {
            tooltip1.IsOpen = false;
        }

    }
}
