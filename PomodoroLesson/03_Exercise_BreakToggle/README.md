04_Exercise_BreakToggle

Exercise goal: UI state & C# logic

What the student must do:
- Add `Checked="TimerMode_Checked"` to both RadioButtons in `TimerPane.xaml`.
- Implement `private void TimerMode_Checked(object sender, RoutedEventArgs e)` in `TimerPane.xaml.cs` so that:
  - If Focus is checked → `TimerDisplay.Text = "25:00"`
  - If Short Break is checked → `TimerDisplay.Text = "05:00"`

Teacher setup performed by this scaffold:
- `TimerPane.xaml` and `TimerPane.xaml.cs` are provided; the RadioButtons are present but missing `Checked` handlers and the handler implementation in code-behind is missing.
