# CLAUDE.md

## Build & Run

```bash
dotnet build UIDesignerWPFUI.csproj
dotnet run --project UIDesignerWPFUI.csproj
```

## Architecture

- **Pattern**: MVVM
- **UI Framework**: WPF-UI (Fluent Design System for WPF)
- **Dependency Injection**: Microsoft.Extensions.Hosting (`IHost` bootstraps the app)
- **MVVM Toolkit**: CommunityToolkit.Mvvm — use `[ObservableProperty]` and `[RelayCommand]` source generators instead of manual INotifyPropertyChanged/ICommand implementations

## Key Conventions

- **Navigation**: Uses WPF-UI's `INavigationWindow` and `INavigableView<TViewModel>` interfaces. Pages register with the navigation service and are resolved via DI.
- **Lifecycle**: `ApplicationHostService` (implementing `IHostedService`) handles app startup — sets up the main window, navigation, and theme.
- **Theme**: Managed via `ApplicationThemeManager` for Fluent light/dark theme switching.
- **ViewModels**: Inherit from `ObservableObject`. Use `[ObservableProperty]` for bindable properties and `[RelayCommand]` for commands.
