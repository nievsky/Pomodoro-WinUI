using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Pomodoro
{
    public class SessionManager
    {
        private static SessionManager _instance;
        public static SessionManager Instance => _instance ??= new SessionManager();

        public ObservableCollection<TaskItem> ActiveTasks { get; } = new ObservableCollection<TaskItem>();
        public ObservableCollection<TaskItem> CompletedTasks { get; } = new ObservableCollection<TaskItem>();
        public ObservableCollection<SessionRecord> HistoryRecords { get; } = new ObservableCollection<SessionRecord>();

        private int _sessionCount = 1;

        public void EndSession()
        {
            int totalTasks = ActiveTasks.Count + CompletedTasks.Count;
            if (totalTasks > 0)
            {
                var record = new SessionRecord
                {
                    SessionTitle = $"Pomodoro #{_sessionCount}",
                    TaskSummary = $"{CompletedTasks.Count} of {totalTasks} tasks completed",
                    Tasks = new ObservableCollection<string>(CompletedTasks.Select(t => t.Name))
                };

                HistoryRecords.Insert(0, record);
                _sessionCount++;
            }

            ActiveTasks.Clear();
            CompletedTasks.Clear();
        }
    }
}
