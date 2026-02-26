
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using System;
using Pomodoro; // for SessionManager, TaskItem

namespace Pomodoro.Components
{
    public sealed partial class TaskPane : UserControl
    {
        public TaskPane()
        {
            // It loads the XAML: It reads the compiled visual layout and actually draws your Grids, Buttons, and TextBlocks onto the screen.

            // It wires up your variables: It finds every element in your XAML that has an x:Name (like TimerDisplay or HistoryPane) and connects them to the C# variables so they aren't null.

            // It hooks up your events: It connects XAML events (like Click="PrimaryAction_Click") to the actual C# methods you wrote.

            this.InitializeComponent();

            // bind list sources to the shared SessionManager
            activeTaskListView.ItemsSource = SessionManager.Instance.ActiveTasks;
            completedTaskListView.ItemsSource = SessionManager.Instance.CompletedTasks;

            addTaskBtn.Click += AddTaskBtn_Click;
            newTaskInput.KeyDown += NewTaskInput_KeyDown;

        }
        public TextBox NewTaskInput => newTaskInput;
        public Button AddTaskBtn => addTaskBtn;
        public ListView ActiveTaskListView => activeTaskListView;
        public ListView CompletedTaskListView => completedTaskListView;

        private void AddTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateTask();
        }

        private void NewTaskInput_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter) CreateTask();
        }

        private void CreateTask()
        {
            if (!string.IsNullOrWhiteSpace(newTaskInput.Text))
            {
                SessionManager.Instance.ActiveTasks.Add(new TaskItem { Name = newTaskInput.Text });
                newTaskInput.Text = string.Empty;
            }
        }

        private void OnTaskChecked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox cb && cb.DataContext is TaskItem task)
            {
                SessionManager.Instance.ActiveTasks.Remove(task);
                SessionManager.Instance.CompletedTasks.Add(task);
            }
        }

        private void OnTaskUnchecked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox cb && cb.DataContext is TaskItem task)
            {
                SessionManager.Instance.CompletedTasks.Remove(task);
                SessionManager.Instance.ActiveTasks.Add(task);
            }
        }
    }
}
