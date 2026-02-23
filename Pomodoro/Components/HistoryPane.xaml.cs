using Microsoft.UI.Xaml.Controls;

namespace Pomodoro.Components
{
    public sealed partial class HistoryPane : UserControl
    {
        public HistoryPane()
        {
            this.InitializeComponent();
        }

        public ListView HistoryListView => historyListView;
    }
}
