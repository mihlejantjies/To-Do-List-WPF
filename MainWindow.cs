using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace To_DoListWPF
{
        public partial class MainWindow : Window
        {
            // ObservableCollection tells the ListBox when items are added or removed
            private ObservableCollection<TaskItem> tasks = new ObservableCollection<TaskItem>();
        private object TaskTextBox;

        // Tasks are saved to this file next to the program
        private const string FileName = "tasks.txt";

        public object TaskListBox { get; private set; }

        public MainWindow()
            {
                InitializeComponent();

                LoadTasks();
                TaskListBox.ItemsSource = tasks;   // connect the list to the ListBox
                TaskTextBox.Focus();
            }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        // "Add" button clicked
        private void AddButton_Click(object sender, RoutedEventArgs e)
            {
                AddTask();
            }

            // Pressing Enter in the text box also adds the task
            private void TaskTextBox_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Enter)
                {
                    AddTask();
                }
            }

            private void AddTask()
            {
                string title = TaskTextBox.Text.Trim();

                if (title == "")
                {
                    MessageBox.Show("Please type a task first.", "Empty task");
                    return;
                }

                tasks.Add(new TaskItem(title));
                TaskTextBox.Clear();
                TaskTextBox.Focus();
            }

            // "Mark Done" button clicked
            private void DoneButton_Click(object sender, RoutedEventArgs e)
            {
                TaskItem selected = TaskListBox.SelectedItem as TaskItem;

                if (selected == null)
                {
                    MessageBox.Show("Select a task in the list first.", "No task selected");
                    return;
                }

                selected.IsDone = true;
                TaskListBox.Items.Refresh();   // redraw the list so the [x] appears
            }

            // "Delete" button clicked
            private void DeleteButton_Click(object sender, RoutedEventArgs e)
            {
                TaskItem selected = TaskListBox.SelectedItem as TaskItem;

                if (selected == null)
                {
                    MessageBox.Show("Select a task in the list first.", "No task selected");
                    return;
                }

                tasks.Remove(selected);
            }

            // Runs automatically when the window is closing, so tasks are always saved
            private void Window_Closing(object sender, CancelEventArgs e)
            {
                SaveTasks();
            }

            // Each line looks like:  0|Buy milk   (0 = not done, 1 = done)
            private void SaveTasks()
            {
                using (StreamWriter writer = new StreamWriter(FileName))
                {
                    foreach (TaskItem task in tasks)
                    {
                        writer.WriteLine((task.IsDone ? "1" : "0") + "|" + task.Title);
                    }
                }
            }

            private void LoadTasks()
            {
                if (!File.Exists(FileName)) return;

                foreach (string line in File.ReadAllLines(FileName))
                {
                    string[] parts = line.Split('|', 2);
                    if (parts.Length == 2)
                    {
                        tasks.Add(new TaskItem(parts[1], parts[0] == "1"));
                    }
                }
            }
        }
    }


