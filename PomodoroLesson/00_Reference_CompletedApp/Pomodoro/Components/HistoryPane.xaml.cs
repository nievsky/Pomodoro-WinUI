
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Pomodoro; // for SessionManager, SessionRecord, SessionDetailPage

namespace Pomodoro.Components
{
    public sealed partial class HistoryPane : UserControl
    {
        public HistoryPane()
        {
            this.InitializeComponent();

            historyListView.ItemsSource = SessionManager.Instance.HistoryRecords;
            historyListView.ItemClick += HistoryListView_ItemClick;
        }

        public ListView HistoryListView => historyListView;

        private void HistoryListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is SessionRecord record)
            {
                detailFrame.Content = new SessionDetailPage(record);
            }
        }

        private void ClearHistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            SessionManager.Instance.HistoryRecords.Clear();
            detailFrame.Content = null;
        }
    }
}
