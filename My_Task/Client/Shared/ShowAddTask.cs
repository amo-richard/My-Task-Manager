using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Task.Client.Shared
{
    public class ShowAddTask
    {
        public bool AddTaskState = false;
        public event Action? Onchange;
        private void NotifyStateChange() => Onchange?.Invoke();
        
        public void Update()
        {
            AddTaskState = AddTaskState ? false : true;

            NotifyStateChange();
        }

        public void Hide()
        {
            AddTaskState = false;
            NotifyStateChange();
        }

    }
}
