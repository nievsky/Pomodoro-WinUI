using System.Collections.ObjectModel;

namespace Pomodoro
{
    public class SessionRecord
    {
        public string SessionTitle { get; set; }
        public string TaskSummary { get; set; }
        public ObservableCollection<string> Tasks { get; set; } = new ObservableCollection<string>();
    }
}
