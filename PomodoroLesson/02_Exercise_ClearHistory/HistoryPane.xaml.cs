using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;

namespace Pomodoro.Components
{
    public sealed partial class HistoryPane : UserControl
    {
        public ObservableCollection<SessionRecord> SessionHistoryList { get; } = new ObservableCollection<SessionRecord>();

        public HistoryPane()
        {
            this.InitializeComponent();

            // sample data for the exercise
            SessionHistoryList.Add(new SessionRecord { DisplayText = "Focus — 25:00 — Done" });
            SessionHistoryList.Add(new SessionRecord { DisplayText = "Break — 05:00 — Done" });
        }

        // Student will implement this handler in the exercise
        // private void ClearHistory_Click(object sender, RoutedEventArgs e)
        // {
        //     SessionHistoryList.Clear();
        // }
    }
}
