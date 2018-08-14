using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskQueueDemo.Task
{
    public class MessageTask : UnitTask
    {
        public MessageTask(string name) : base(name) { }
    }
}
