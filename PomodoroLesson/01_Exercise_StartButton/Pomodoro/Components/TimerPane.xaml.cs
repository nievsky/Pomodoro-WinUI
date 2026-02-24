using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Timers;

namespace Pomodoro.Components
{
    public sealed partial class TimerPane : UserControl
    {
        private DispatcherTimer _timer;
        private TimeSpan _timeLeft;
        private TimeSpan _initialTime;
        private bool _isRunning = false;

        public TimerPane()
        {
            this.InitializeComponent();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;

            SetTime(25);

            primaryActionBtn.Click += PrimaryActionBtn_Click;
            resetBtn.Click += ResetBtn_Click;
            skipBtn.Click += SkipBtn_Click;
            timerDisplay.LostFocus += TimerDisplay_LostFocus;
        }

        public ProgressRing TimerProgress => timerProgress;
        public TextBox TimerDisplay => timerDisplay;
        public Button ResetBtn => resetBtn;
        public Button PrimaryActionBtn => primaryActionBtn;
        public Button SkipBtn => skipBtn;

        public void SetTime(int minutes)
        {
            _initialTime = TimeSpan.FromMinutes(minutes);
            _timeLeft = _initialTime;
            UpdateDisplay();
            UpdateTimerProgress();
        }

        private void Timer_Tick(object sender, object e)
        {
            if (_timeLeft.TotalSeconds > 0)
            {
                _timeLeft = _timeLeft.Subtract(TimeSpan.FromSeconds(1));
                UpdateDisplay();
                UpdateTimerProgress();
            }
            else
            {
                EndSession();
            }
        }

        private void UpdateDisplay()
        {
            timerDisplay.Text = _timeLeft.ToString(@"mm\:ss");
        }

        private void UpdateTimerProgress()
        {
            if (_initialTime.TotalSeconds > 0)
            {
                double percent = (_timeLeft.TotalSeconds / _initialTime.TotalSeconds) * 100.0;
                timerProgress.Value = Math.Max(0, Math.Min(100, percent));
            }
            else
            {
                timerProgress.Value = 0;
            }
        }

        private void PrimaryActionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_isRunning)
            {
                _timer.Stop();
                primaryActionBtn.Content = "Start";
            }
            else
            {
                if (_timeLeft.TotalSeconds > 0)
                {
                    _timer.Start();
                    primaryActionBtn.Content = "Pause";
                }
            }
            _isRunning = !_isRunning;
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            _isRunning = false;
            primaryActionBtn.Content = "Start";
            _timeLeft = _initialTime;
            UpdateDisplay();
        }

        private void SkipBtn_Click(object sender, RoutedEventArgs e)
        {
            EndSession();
        }

        private void EndSession()
        {
            _timer.Stop();
            _isRunning = false;
            primaryActionBtn.Content = "Start";
            _timeLeft = TimeSpan.Zero;
            UpdateDisplay();

            // Delegate session end handling to SessionManager
            SessionManager.Instance.EndSession();
        }

        private void TimerDisplay_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TimeSpan.TryParseExact(timerDisplay.Text, @"mm\:ss", null, out TimeSpan parsedTime))
            {
                _initialTime = parsedTime;
            }
            else if (int.TryParse(timerDisplay.Text, out int minutes))
            {
                _initialTime = TimeSpan.FromMinutes(minutes);
            }
            _timeLeft = _initialTime;
            UpdateDisplay();
        }
    }
}

