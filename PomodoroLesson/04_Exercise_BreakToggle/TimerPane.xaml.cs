using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Pomodoro.Components
{
    public sealed partial class TimerPane : UserControl
    {
        public TimerPane()
        {
            this.InitializeComponent();
            // RadioButton Checked handlers intentionally not implemented — students will add them.
        }

        // Student implements:
        // private void TimerMode_Checked(object sender, RoutedEventArgs e)
        // {
        //     if (FocusRadio.IsChecked == true)
        //         TimerDisplay.Text = "25:00";
        //     else if (BreakRadio.IsChecked == true)
        //         TimerDisplay.Text = "05:00";
        // }
    }
}
