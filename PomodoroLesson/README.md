# PomodoroLesson

This folder contains hands-on exercises for learning **WinUI 3** (XAML + C#) using the Pomodoro timer app as the working project. Each sub-folder is a self-contained Visual Studio project with its own README that tells you exactly what to do.

---

## How to work through the exercises

1. Start with `00_Reference_CompletedApp` to understand what the finished app looks like.
2. Open each numbered exercise folder in order.
3. Read its `README.md` — it explains the goal, the files to edit (marked ✏️), and step-by-step instructions.
4. If you get stuck at any point, compare your code against the reference.

---

## Folder overview

```
PomodoroLesson/
├── README.md                      ← you are here
├── PomodoroLesson.sln             ← solution file (open in Visual Studio)
│
├── 00_Reference_CompletedApp/     ← fully working app — READ ONLY, use as a reference
│   └── Pomodoro/
│
├── 01_Exercise_StartButton/       ← add 3 timer buttons in XAML & wire up Click handlers in C#
│   └── Pomodoro/
│
└── 02_Exercise_ClearHistory/      ← add a Clear History button & implement the handler in C#
    └── Pomodoro/
```

---

## Exercises at a glance

| # | Folder | What you build | Files to edit |
|---|--------|---------------|---------------|
| — | `00_Reference_CompletedApp` | Reference only — do not modify | — |
| 1 | `01_Exercise_StartButton` | Three timer control buttons (Reset / Start / Skip) wired to C# event handlers | `Components/TimerPane.xaml` `Components/TimerPane.xaml.cs` |
| 2 | `02_Exercise_ClearHistory` | A "Clear All Sessions" button that wipes the history list | `Components/HistoryPane.xaml` `Components/HistoryPane.xaml.cs` |

---

> [!TIP]
> Each exercise project runs independently with `dotnet watch` from inside its `Pomodoro/` sub-folder. See the individual README for the exact command.
