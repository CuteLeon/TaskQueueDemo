using System;
using System.Threading;

namespace TaskQueueDemo.Task
{
    public class MessageTask : UnitTask
    {
        public MessageTask(string name) : base(name) { }

        public override void Execute()
        {
            Thread.Sleep(new Random().Next(1000));
            Console.WriteLine($"[{Name}] 执行任务完成！");
        }

    }
}
