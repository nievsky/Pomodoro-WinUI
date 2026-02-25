03_Exercise_ClearHistory

Exercise goal: C# logic & ObservableCollection

What the student must do:
- Add a `Button` to `HistoryPane.xaml` with: `Content="Clear History" Click="ClearHistory_Click"`.
- Implement `private void ClearHistory_Click(object sender, RoutedEventArgs e)` in `HistoryPane.xaml.cs` with a single line:
  `SessionHistoryList.Clear();`

Teacher setup performed by this scaffold:
- `HistoryPane.xaml` and `HistoryPane.xaml.cs` files are provided. The XAML intentionally does not include the Clear button.
- `HistoryPane.xaml.cs` exposes an `ObservableCollection<SessionRecord> SessionHistoryList` already populated with sample data — the `ClearHistory_Click` handler is intentionally missing.
