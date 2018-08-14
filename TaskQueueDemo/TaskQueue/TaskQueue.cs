using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using TaskQueueDemo.Task;

namespace TaskQueueDemo.TaskQueue
{
    /// <summary>
    /// 任务队列
    /// </summary>
    public class TaskQueue<T> where T : UnitTask
    {
        //TODO: IDispose 释放worker和list和event

        /// <summary>
        /// 有任务入队事件
        /// </summary>
        public event EventHandler<T> TaskEnqueued;// { add { } remove { } }

        /// <summary>
        /// 有任务出队事件
        /// </summary>
        public event EventHandler TaskDequeued;// { add { } remove { } }

        /// <summary>
        /// 队列开始执行
        /// </summary>
        public event EventHandler QueueStarted;// { add { } remove { } }

        /// <summary>
        /// 队列停止执行
        /// </summary>
        public event EventHandler QueueStoped;// { add { } remove { } }

        /// <summary>
        /// 任务队列名称
        /// </summary>
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// 任务列表（线程安全）
        /// </summary>
        private ConcurrentQueue<T> tasks { get; set; } = new ConcurrentQueue<T>();
        /// 任务列表（只读）
        /// </summary>
        public T[] Tasks { get => tasks.ToArray(); }

        /// <summary>
        /// 任务执行线程
        /// </summary>
        private BackgroundWorker TaskWorker = new BackgroundWorker()
        {
            WorkerReportsProgress = false,
            WorkerSupportsCancellation = true
        };
        
        /// <summary>
        /// <summary>
        /// 队列内任务总数
        /// </summary>
        public int TaskCount { get => tasks.Count; }

        public TaskQueue(string name)
        {
            Name = name;

            TaskWorker.DoWork += ExecuteTasks;
            TaskWorker.RunWorkerCompleted += ExecuteFinished;
        }

        /// <summary>
        /// 任务入队
        /// </summary>
        /// <param name="task"></param>
        public void Enqueue(T task)
        {
            //TODO: 使用信号量控制，防止队列循环空转

            if (task == null) return;
            tasks.Enqueue(task);
            
            TaskEnqueued?.Invoke(this, task);
        }

        /// <summary>
        /// 任务出队
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            //TODO: 使用信号量控制，防止队列循环空转

            bool result = tasks.TryDequeue(out T task);
            if (result) TaskDequeued?.Invoke(this, null);
            return task;
        }

        /// <summary>
        /// 任务队列开始执行
        /// </summary>
        public void Start()
        {
            TaskWorker.RunWorkerAsync();
            QueueStarted?.Invoke(this, null);

            //TODO: 使用信号量控制，防止队列循环空转
        }

        /// <summary>
        /// 任务队列停止执行
        /// </summary>
        public void Stop()
        {
            TaskWorker.CancelAsync();
            QueueStoped?.Invoke(this, null);

            //TODO: 使用信号量控制，防止队列循环空转
        }

        /// <summary>
        /// 开始轮询执行任务
        /// </summary>
        private void ExecuteTasks(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine($"<{Name}> 内 Worker 启动...");
            while (true)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"<{Name}> 队列内任务数：{TaskCount}");

                if ((sender as BackgroundWorker).CancellationPending) return;
                if (TaskCount == 0) continue;

                T task = Dequeue();
                if (task == null) continue;

                task.Execute();
                
            }
        }

        /// <summary>
        /// 任务轮询结束
        /// </summary>
        private void ExecuteFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            //TODO: 增加任务结束控制
            Console.WriteLine($"<{Name}> 内 Worker 停止...");
            Console.WriteLine($"<{Name}> 队列内剩余任务数：{TaskCount}");
        }

    }
}
