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
            SeriesPoint point = chartControl1.HitTest(e.GetPosition(chartControl1));

            if (point != null) {
                tooltip_text.Text = string.Format("Series = {0}\nArgument = {1}\nValue = {2}",
                    point.Series.DisplayName, point.Argument, point.Value);
                tooltip.Placement = PlacementMode.Mouse;
                tooltip.IsOpen = true;
                Cursor = Cursors.Hand;
            }
            else {
                tooltip.IsOpen = false;
                Cursor = Cursors.Arrow;
            }
        }

        private void chartControl1_MouseLeave(object sender, MouseEventArgs e) {
            tooltip.IsOpen = false;
        }
    }
}
