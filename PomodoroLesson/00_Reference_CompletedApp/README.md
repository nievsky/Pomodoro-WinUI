# 00_Reference_CompletedApp — Completed Reference Project

> [!IMPORTANT]
> This folder contains the **fully completed Pomodoro application**.
> Use it as a reference while working through the exercises — if you get stuck, look here to see how something is supposed to work.
> **Do not modify anything in this folder.**

## What is this?

This is the finished, working version of the Pomodoro WinUI 3 app that you are building step-by-step in the numbered exercise folders (`01_Exercise_*`, `02_Exercise_*`, …). Every feature is implemented and the app runs out of the box. Compare your exercise code against this whenever you need guidance.

## How to run it

```
cd Pomodoro
dotnet run
```

Or open the solution in Visual Studio and set `00_Reference_CompletedApp\Pomodoro` as the startup project.

---

## Project structure

```
00_Reference_CompletedApp/
├── README.md                          ← you are here
└── Pomodoro/                          ← WinUI 3 application project root
    ├── Pomodoro.csproj                ← project file (SDK-style, targets net8.0-windows)
    ├── Package.appxmanifest           ← MSIX package manifest (app identity, capabilities)
    ├── app.manifest                   ← Win32 / dpiAwareness compatibility manifest
    │
    ├── App.xaml                       ← application-level resources and theme definitions
    ├── App.xaml.cs                    ← App entry point, window creation
    │
    ├── MainWindow.xaml                ← root window layout — hosts the three panes via tab/nav
    ├── MainWindow.xaml.cs             ← code-behind for MainWindow
    │
    ├── Components/                    ← reusable UI user controls (each is a pane / view)
    │   ├── TimerPane.xaml             ← XAML layout for the countdown timer panel
    │   ├── TimerPane.xaml.cs          ← timer logic: start/pause/reset, session tracking
    │   ├── TaskPane.xaml              ← XAML layout for the task list panel
    │   ├── TaskPane.xaml.cs           ← add / complete / remove tasks, binds to TaskItem list
    │   ├── HistoryPane.xaml           ← XAML layout for the session history panel
    │   └── HistoryPane.xaml.cs        ← displays past Pomodoro sessions from SessionManager
    │
    ├── core/                          ← plain C# business-logic classes (no UI dependencies)
    │   ├── TaskItem.cs                ← simple model: task name + completion flag
    │   ├── SessionRecord.cs           ← model for a single completed Pomodoro session
    │   ├── SessionManager.cs          ← in-memory list of SessionRecords; add / query sessions
    │   └── SessionDetailPage.cs       ← helper that formats session data for display
    │
    ├── Assets/                        ← image assets required by the MSIX package manifest
    │   ├── SplashScreen.scale-200.png
    │   ├── Square44x44Logo.scale-200.png
    │   ├── Square44x44Logo.targetsize-24_altform-unplated.png
    │   ├── Square150x150Logo.scale-200.png
    │   ├── Wide310x150Logo.scale-200.png
    │   ├── LockScreenLogo.scale-200.png
    │   └── StoreLogo.png
    │
    └── Properties/                    ← IDE / publish settings
        ├── launchSettings.json        ← debug launch profile
        └── PublishProfiles/           ← MSIX publish profiles
```
