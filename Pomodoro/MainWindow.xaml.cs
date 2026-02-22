using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Pomodoro
{
    public sealed partial class MainWindow : Window
    {
        private DispatcherTimer _timer;
        private TimeSpan _timeLeft;
        private TimeSpan _initialTime;
        private bool _isRunning = false;
        private int _sessionCount = 1;

        public ObservableCollection<TaskItem> ActiveTasks { get; set; }
        public ObservableCollection<TaskItem> CompletedTasks { get; set; }
        public ObservableCollection<SessionRecord> HistoryRecords { get; set; } // New History List

        public MainWindow()
        {
            this.InitializeComponent();

            ActiveTasks = new ObservableCollection<TaskItem>();
            CompletedTasks = new ObservableCollection<TaskItem>();
            HistoryRecords = new ObservableCollection<SessionRecord>();

            ActiveTaskListView.ItemsSource = ActiveTasks;
            CompletedTaskListView.ItemsSource = CompletedTasks;
            HistoryListView.ItemsSource = HistoryRecords; // Bind the left menu

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;

            SetTime(25);
        }

        private void SetTime(int minutes)
        {
            _initialTime = TimeSpan.FromMinutes(minutes);
            _timeLeft = _initialTime;
            UpdateDisplay();
        }

        private void Timer_Tick(object sender, object e)
        {
            if (_timeLeft.TotalSeconds > 0)
            {
                _timeLeft = _timeLeft.Subtract(TimeSpan.FromSeconds(1));
                UpdateDisplay();
            }
            else
            {
                EndSession();
            }
        }

        private void UpdateDisplay()
        {
            TimerDisplay.Text = _timeLeft.ToString(@"mm\:ss");
        }

        private void PrimaryAction_Click(object sender, RoutedEventArgs e)
        {
            if (_isRunning)
            {
                _timer.Stop();
                PrimaryActionBtn.Content = "Start";
            }
            else
            {
                if (_timeLeft.TotalSeconds > 0)
                {
                    _timer.Start();
                    PrimaryActionBtn.Content = "Pause";
                }
            }
            _isRunning = !_isRunning;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            _isRunning = false;
            PrimaryActionBtn.Content = "Start";
            _timeLeft = _initialTime;
            UpdateDisplay();
        }

        private void Skip_Click(object sender, RoutedEventArgs e) => EndSession();

        private void EndSession()
        {
            // 1. Stop the timer
            _timer.Stop();
            _isRunning = false;
            PrimaryActionBtn.Content = "Start";
            _timeLeft = TimeSpan.Zero;
            UpdateDisplay();

            // 2. Record the history if there were any tasks
            int totalTasks = ActiveTasks.Count + CompletedTasks.Count;
            if (totalTasks > 0)
            {
                var record = new SessionRecord
                {
                    SessionTitle = $"Pomodoro #{_sessionCount}",
                    TaskSummary = $"{CompletedTasks.Count} of {totalTasks} tasks completed"
                };

                // Add to the top of the history list
                HistoryRecords.Insert(0, record);
                _sessionCount++;
            }

            // 3. Clear the lists for the next session
            ActiveTasks.Clear();
            CompletedTasks.Clear();
        }

        private void TimerDisplay_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TimeSpan.TryParseExact(TimerDisplay.Text, @"mm\:ss", null, out TimeSpan parsedTime))
            {
                _initialTime = parsedTime;
            }
            else if (int.TryParse(TimerDisplay.Text, out int minutes))
            {
                _initialTime = TimeSpan.FromMinutes(minutes);
            }
            _timeLeft = _initialTime;
            UpdateDisplay();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e) => CreateTask();
        private void NewTaskInput_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter) CreateTask();
        }

        private void CreateTask()
        {
            if (!string.IsNullOrWhiteSpace(NewTaskInput.Text))
            {
                ActiveTasks.Add(new TaskItem { Name = NewTaskInput.Text });
                NewTaskInput.Text = string.Empty;
            }
        }

        private void Task_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox cb && cb.DataContext is TaskItem task)
            {
                ActiveTasks.Remove(task);
                CompletedTasks.Add(task);
            }
        }

        private void Task_Unchecked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox cb && cb.DataContext is TaskItem task)
            {
                CompletedTasks.Remove(task);
                ActiveTasks.Add(task);
            }
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            Reset_Click(null, null);
            if (args.InvokedItemContainer.Tag.ToString() == "Focus") SetTime(25);
            else if (args.InvokedItemContainer.Tag.ToString() == "Break") SetTime(5);
        }
    }

    public class TaskItem
    {
        public string Name { get; set; }
    }

    // New class for History formatting
    public class SessionRecord
    {
        public string SessionTitle { get; set; }
        public string TaskSummary { get; set; }
    }
}

// changes made