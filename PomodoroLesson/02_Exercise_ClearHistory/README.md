# 02_Exercise_ClearHistory — Add a Clear History Button

## Goal

The session history panel displays past Pomodoro sessions but has no way to clear them. Your task is to add a **"Clear All Sessions"** button to the XAML layout and implement the click handler that wipes the list.

---

## What you need to do

### Step 1 — Add the button in XAML

Open **`Components/HistoryPane.xaml`** and add a `Button` at the bottom of the layout (after the `<Frame>` element, still inside the panel):

| Attribute | Value |
|---|---|
| `x:Name` | `clearHistoryBtn` |
| `Content` | `🗑 Clear All Sessions` |
| `HorizontalAlignment` | `Stretch` |
| `Click` | `ClearHistoryBtn_Click` |

> [!TIP]
> Setting `Click="ClearHistoryBtn_Click"` in XAML is a shorthand that tells WinUI to call a method with that name in the code-behind whenever the button is clicked — you'll write that method in Step 2.

### Step 2 — Implement the handler in C #

Every control with an `x:Name` in XAML automatically generates a C# field of the same name. Here `x:Name="clearHistoryBtn"` means `clearHistoryBtn` is available directly in your code-behind.

Open **`Components/HistoryPane.xaml.cs`** and add the handler method inside the `HistoryPane` class:

```csharp
private void ClearHistoryBtn_Click(object sender, RoutedEventArgs e)
{
    SessionManager.Instance.HistoryRecords.Clear();
    detailFrame.Content = null;
}
```

`SessionManager.Instance.HistoryRecords` is an `ObservableCollection` — calling `.Clear()` on it automatically updates the `ListView` in real time because the UI is bound to it. `detailFrame.Content = null` dismisses any session detail that may be showing.

> [!TIP]
> If you are stuck, open `00_Reference_CompletedApp/Pomodoro/Components/HistoryPane.xaml` and `HistoryPane.xaml.cs` side-by-side to compare against your work.

---

## How to run

```
cd Pomodoro

dotnet watch
```

---

## Project structure

Files you need to edit are marked with **✏️**. Everything else is already complete and should not need changes.

```
02_Exercise_ClearHistory/
├── README.md                          ← you are here
└── Pomodoro/
    ├── Pomodoro.csproj                ← project file
    ├── Package.appxmanifest           ← MSIX package manifest
    ├── app.manifest                   ← Win32 compatibility manifest
    │
    ├── App.xaml                       ← application resources / theme
    ├── App.xaml.cs                    ← app entry point
    │
    ├── MainWindow.xaml                ← root window, hosts the three panes
    ├── MainWindow.xaml.cs             ← code-behind for MainWindow
    │
    ├── Components/
    │   ├── HistoryPane.xaml    ✏️     ← ADD the clear button here
    │   ├── HistoryPane.xaml.cs ✏️     ← ADD ClearHistoryBtn_Click handler here
    │   ├── TimerPane.xaml             ← timer panel (already complete)
    │   ├── TimerPane.xaml.cs          ← timer logic (already complete)
    │   ├── TaskPane.xaml              ← task list panel (already complete)
    │   └── TaskPane.xaml.cs           ← task list logic (already complete)
    │
    ├── core/                          ← business logic — do not modify
    │   ├── TaskItem.cs                ← task model
    │   ├── SessionRecord.cs           ← single session model
    │   ├── SessionManager.cs          ← holds HistoryRecords (ObservableCollection)
    │   └── SessionDetailPage.cs       ← formats session data for display
    │
    ├── Assets/                        ← app icons and splash screen images
    └── Properties/                    ← launch settings and publish profiles
```
