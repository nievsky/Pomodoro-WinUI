using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Pomodoro.Components
{
    public sealed partial class TaskPane : UserControl
    {
        public TaskPane()
        {
            this.InitializeComponent();
        }

        public TextBox NewTaskInput => newTaskInput;
        public Button AddTaskBtn => addTaskBtn;
        public ListView ActiveTaskListView => activeTaskListView;
        public ListView CompletedTaskListView => completedTaskListView;
        public event RoutedEventHandler TaskChecked;
        public event RoutedEventHandler TaskUnchecked;

        private void OnTaskChecked(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            TaskChecked?.Invoke(sender, e);
        }

        private void OnTaskUnchecked(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            TaskUnchecked?.Invoke(sender, e);
        }
    }
}
