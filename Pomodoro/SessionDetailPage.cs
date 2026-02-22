using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Text;

namespace Pomodoro
{
    public class SessionDetailPage : Page
    {
        public SessionDetailPage(SessionRecord record)
        {
            var panel = new StackPanel
            {
                Padding = new Thickness(16),
                Spacing = 8
            };

            var title = new TextBlock
            {
                Text = record?.SessionTitle ?? "Session",
                FontSize = 20,
                FontWeight = FontWeights.SemiBold
            };

            var summary = new TextBlock
            {
                Text = record?.TaskSummary ?? string.Empty,
                Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 0x66, 0x66, 0x66)),
                TextWrapping = TextWrapping.Wrap
            };

            panel.Children.Add(title);
            panel.Children.Add(summary);

            if (record?.Tasks != null && record.Tasks.Count > 0)
            {
                var tasksLabel = new TextBlock
                {
                    Text = "Completed Tasks:",
                    FontSize = 16,
                    FontWeight = FontWeights.Medium,
                    Margin = new Thickness(0, 12, 0, 4)
                };
                panel.Children.Add(tasksLabel);

                var tasksPanel = new StackPanel();
                foreach (var task in record.Tasks)
                {
                    tasksPanel.Children.Add(new TextBlock
                    {
                        Text = task,
                        FontSize = 14,
                        Margin = new Thickness(8, 0, 0, 0)
                    });
                }
                panel.Children.Add(tasksPanel);
            }

            this.Content = panel;
        }
    }
}
