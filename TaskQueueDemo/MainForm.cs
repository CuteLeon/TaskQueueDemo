﻿using System;
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

            this.FormClosing += (s, v) => { MessageQueue.Stop(); };
            MessageQueue.TaskEnqueued += new EventHandler<MessageTask>((s, v) => { Console.WriteLine($"<{((TaskQueue<MessageTask>)s).Name}> 入队了新任务：[{v.Name}]"); });
            MessageQueue.TaskDequeued += new EventHandler((s, v) => { Console.WriteLine($"<{((TaskQueue<MessageTask>)s).Name}>有任务出队，剩余任务个数：[{((TaskQueue<MessageTask>)s).TaskCount}]"); });
            MessageQueue.QueueStarted += new EventHandler((s, v) => { Console.WriteLine($"<{((TaskQueue<MessageTask>)s).Name}> 任务开始执行 ..."); });
            MessageQueue.QueueStoped += new EventHandler((s, v) => { Console.WriteLine($"<{((TaskQueue<MessageTask>)s).Name}> 任务停止执行 ..."); });

            MessageQueue.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //测试并发任务入队
            Parallel.For(0, 100, new Action<int>(index => {
                MessageQueue.Enqueue(new MessageTask($"消息任务-{index}"));
            }));

            //MessageQueue.Dequeue();
            ShowTaskQueue();

        }

        public void ShowTaskQueue()
        {
            Console.WriteLine($"队列内任务 (共 {MessageQueue.TaskCount} 个)：\n\t{string.Join("\n\t", MessageQueue.Tasks.AsEnumerable())}");
        }
    }
}
