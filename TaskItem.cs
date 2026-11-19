using System;
using System.Collections.Generic;
using System.Text;

namespace To_DoListWPF
{
    internal class TaskItem
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public TaskItem(string title, bool isDone = false)
        {
            Title = title;
            IsDone = isDone;
        }

        // The ListBox shows whatever ToString() returns
        public override string ToString()
        {
            return IsDone ? "[x]  " + Title : "[  ]  " + Title;
        }
    }
}

