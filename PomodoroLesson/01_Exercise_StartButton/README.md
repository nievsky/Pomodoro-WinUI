# 01_Exercise_StartButton — Add Timer Buttons & Wire Up Logic

## Goal

The timer panel is missing its three control buttons. Your task is to add them back in XAML and connect them to the event handlers already waiting in the C# code-behind.

---

## What you need to do

### Step 1 — Add the buttons in XAML

Open **`Components/TimerPane.xaml`** and uncomment (or recreate) the `StackPanel` with the three buttons inside the timer area:

| Button name (x:Name) | Content | Purpose |
|---|---|---|
| `resetBtn` | `🔄` | Resets the timer back to the start |
| `primaryActionBtn` | `Start` | Starts or pauses the countdown |
| `skipBtn` | `⏭` | Skips the current session immediately |

The buttons should sit in a horizontal `StackPanel` centered below the circular timer display. Look at the commented-out block already present in the file for a hint.

### Step 2 — Wire up events in C #

Every control that has an `x:Name` attribute in XAML automatically gets a C# field with the same name generated for you. That means `x:Name="primaryActionBtn"` in the XAML file produces a `primaryActionBtn` variable you can use directly in the code-behind.

Open **`Components/TimerPane.xaml.cs`** and, inside the `TimerPane()` constructor, use those generated variables to subscribe each button to its handler:

```csharp
primaryActionBtn.Click += PrimaryActionBtn_Click;
resetBtn.Click         += ResetBtn_Click;
skipBtn.Click          += SkipBtn_Click;
```

The handler methods (`PrimaryActionBtn_Click`, `ResetBtn_Click`, `SkipBtn_Click`) are already defined in the reference project — you need to copy them into this file too.

> [!TIP]
> If you are stuck, open `00_Reference_CompletedApp/Pomodoro/Components/TimerPane.xaml` and `TimerPane.xaml.cs` side-by-side to compare against your work.

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
01_Exercise_StartButton/
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
    │   ├── TimerPane.xaml      ✏️     ← ADD the three buttons here
    │   ├── TimerPane.xaml.cs   ✏️     ← WIRE UP Click handlers here
    │   ├── TaskPane.xaml              ← task list panel (already complete)
    │   ├── TaskPane.xaml.cs           ← task list logic (already complete)
    │   ├── HistoryPane.xaml           ← history panel (already complete)
    │   └── HistoryPane.xaml.cs        ← history logic (already complete)
    │
    ├── core/                          ← business logic — do not modify
    │   ├── TaskItem.cs                ← task model
    │   ├── SessionRecord.cs           ← single session model
    │   ├── SessionManager.cs          ← manages session list
    │   └── SessionDetailPage.cs       ← formats session data for display
    │
    ├── Assets/                        ← app icons and splash screen images
    └── Properties/                    ← launch settings and publish profiles
```
