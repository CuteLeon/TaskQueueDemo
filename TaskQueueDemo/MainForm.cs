using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using TaskQueueDemo.Task;
using TaskQueueDemo.TaskQueue;

namespace TaskQueueDemo
{
    public partial class MainForm : Form
    {
        TaskQueue<MessageTask> MessageQueue = new TaskQueue<MessageTask>("消息任务队列");

        public MainForm()
        {
            InitializeComponent();
            Console.WriteLine("注册事件...");
            this.FormClosing += (s, v) => { MessageQueue.Stop(); };
            /*
            MessageQueue.TaskEnqueued += new EventHandler<MessageTask>((s, v) => {
                this.Invoke(new Action(()=> { this.Text = MessageQueue.TaskCount.ToString(); }));
                Console.WriteLine($"<{((TaskQueue<MessageTask>)s).Name}> 入队了新任务：[{v.Name}]");
            });
            MessageQueue.TaskDequeued += new EventHandler((s, v) => {
                this.Invoke(new Action(() => { this.Text = MessageQueue.TaskCount.ToString(); }));
                Console.WriteLine($"<{((TaskQueue<MessageTask>)s).Name}>有任务出队，剩余任务个数：[{((TaskQueue<MessageTask>)s).TaskCount}]");
            });
             */
            MessageQueue.Idle += new EventHandler((s, v)=> {
                Console.WriteLine($"<{((TaskQueue<MessageTask>)s).Name}> 进入空闲状态 ...");
            });
            MessageQueue.QueueStarted += new EventHandler((s, v) => {
                Console.WriteLine($"<{((TaskQueue<MessageTask>)s).Name}> 任务开始执行 ...");
            });
            MessageQueue.QueueStoped += new EventHandler((s, v) => {
                Console.WriteLine($"<{((TaskQueue<MessageTask>)s).Name}> 任务停止执行 ...");
            });

            //MessageQueue.Start();
        }

        public void ShowTaskQueue()
        {
            Console.WriteLine($"队列内任务 (共 {MessageQueue.TaskCount} 个)：\n\t{string.Join("\n\t", MessageQueue.Tasks.AsEnumerable())}");
        }

        private void Enqueuebutton_Click(object sender, EventArgs e)
        {
            //测试并发任务入队
            Console.WriteLine("并行入队 10 个任务...");
            Parallel.For(0, 10, new Action<int>(index => {
                MessageQueue.Enqueue(new MessageTask($"消息任务-{index}"));
            }));
            Console.WriteLine($"队列内任务数量：{MessageQueue.TaskCount}");

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            MessageQueue.Start();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            MessageQueue.Stop();
        }
    }
}
