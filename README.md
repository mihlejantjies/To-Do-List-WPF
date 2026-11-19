# To-Do-List-WPF

# To-Do List (C# WPF App)

A beginner-friendly desktop to-do list with a text box, a list box and buttons. Tasks are saved automatically to `tasks.txt` when you close the window.

## Features

- Add tasks with the **Add** button or by pressing **Enter**
- Select a task and click **Mark Done** (it shows `[x]`)
- Select a task and click **Delete** to remove it
- Tasks are saved when the window closes and loaded when it opens

## Setup in Visual Studio 2022

1. Click **Create a new project**.
2. Search for `WPF` and choose **WPF Application** (C#, **not** ".NET Framework"). Click **Next**.
3. Name the project `TodoListWpf` (this must match the namespace in the code). Click **Next**, then **Create**.
4. In **Solution Explorer**, expand `MainWindow.xaml` and you'll see `MainWindow.xaml.cs` beneath it.
5. Open `MainWindow.xaml`, press **Ctrl+A**, delete everything, and paste in the XAML from this project.
6. Open `MainWindow.xaml.cs`, press **Ctrl+A**, delete everything, and paste in the C# code from this project.
7. Press **F5** to run.

## How to Use

1. Type a task in the text box and press **Enter** (or click **Add**).
2. Click a task in the list to select it.
3. Click **Mark Done** to tick it off, or **Delete** to remove it.
4. Close the window. Your tasks are saved automatically.

## How It Works

| Concept | Where |
|---------|-------|
| Layout with `Grid` and `StackPanel` | `MainWindow.xaml` |
| Event handlers (`Click`, `KeyDown`, `Closing`) | linked in the XAML, written in `MainWindow.xaml.cs` |
| `ObservableCollection<T>` | keeps the `ListBox` in sync with the task list |
| `ListBox.SelectedItem` | finds which task the user clicked |
| `MessageBox.Show` | friendly warnings |
| File reading and writing | `SaveTasks`, `LoadTasks` |

## Where is `tasks.txt`?

In the folder the program runs from, usually `bin\Debug\net<version>-windows\` inside your project folder.

## Troubleshooting

- **Errors about `InitializeComponent` or a missing class:** the project name doesn't match. Either name the project `TodoListWpf`, or change `TodoListWpf` to your project name in both the `x:Class` line of the XAML and the `namespace` line of the C# file.
- **Event handler errors:** make sure you pasted *both* files, since the XAML refers to methods in the C# file.
- **Can't find the WPF template:** open the Visual Studio Installer and add the **.NET desktop development** workload.

## Ideas to Extend It

- Show completed tasks with a strikethrough or grey text
- Add a checkbox in each row using a `DataTemplate`
- Add a "Clear completed" button
- Add due dates with a `DatePicker`
