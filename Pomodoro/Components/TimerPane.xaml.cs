using Microsoft.UI.Xaml.Controls;

namespace Pomodoro.Components
{
    public sealed partial class TimerPane : UserControl
    {
        public TimerPane()
        {
            this.InitializeComponent();
        }

        public ProgressRing TimerProgress => timerProgress;
        public TextBox TimerDisplay => timerDisplay;
        public Button ResetBtn => resetBtn;
        public Button PrimaryActionBtn => primaryActionBtn;
        public Button SkipBtn => skipBtn;
    }
}
