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
    public class TaskQueue<T> : IDisposable where T : UnitTask
    {
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
        public event DoWorkEventHandler QueueStarted;// { add { } remove { } }

        /// <summary>
        /// 队列停止执行
        /// </summary>
        public event RunWorkerCompletedEventHandler QueueStoped;// { add { } remove { } }

        /// <summary>
        /// 队列进入空闲状态
        /// </summary>
        public event EventHandler Idle;// { add { } remove { } }

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
        /// 任务控制信号量（防止队列循环空转）
        /// </summary>
        private volatile ManualResetEvent QueueEvent = new ManualResetEvent(false);
        
        /// <summary>
        /// 队列内任务总数
        /// </summary>
        public int TaskCount { get => tasks?.Count() ?? 0; }

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
            if (task == null) return;

            if (TaskCount == 0)
            {
                Console.WriteLine($"<{Name}> 队列信号量 Enqueue-Set()");
                QueueEvent.Set();
            }
            tasks.Enqueue(task);

            TaskEnqueued?.Invoke(this, task);
        }

        /// <summary>
        /// 任务出队
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            bool result = tasks.TryDequeue(out T task);
            if (result) TaskDequeued?.Invoke(this, null);
            return task;
        }

        /// <summary>
        /// 任务队列开始执行
        /// </summary>
        public void Start()
        {
            if (TaskWorker.IsBusy) return;
            TaskWorker.RunWorkerAsync();
        }

        /// <summary>
        /// 任务队列开始执行
        /// </summary>
        public void Start(object argument)
        {
            if (TaskWorker.IsBusy) return;
            TaskWorker.RunWorkerAsync(argument);
        }

        /// <summary>
        /// 任务队列停止执行
        /// </summary>
        public void Stop()
        {
            if (!TaskWorker.IsBusy) return;
            TaskWorker.CancelAsync();
            Console.WriteLine($"<{Name}> 队列信号量 Stop-Set()");
            QueueEvent.Set();
        }

        /// <summary>
        /// 开始轮询执行任务
        /// </summary>
        private void ExecuteTasks(object sender, DoWorkEventArgs e)
        {
            QueueStarted?.Invoke(this, e);
            Console.WriteLine($"<{Name}> 内 Worker 启动...");

            while (true)
            {
                try
                {
                    //Thread.Sleep(1000);
                    Console.WriteLine($"<{Name}> 队列内任务数：{TaskCount}");

                    if ((sender as BackgroundWorker).CancellationPending) return;
                    if (TaskCount == 0)
                    {
                        Console.WriteLine($"<{Name}> 队列信号量 Execute-WaitOne");
                        //队列进入空闲状态，触发空闲事件
                        Idle?.Invoke(this, null);
                        QueueEvent.Reset();
                        QueueEvent.WaitOne();
                        //WaitOne 之后要先 continue 一次
                        continue;
                    }

                    T task = Dequeue();
                    if (task == null) continue;

                    task.Execute();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"<{Name}> 队列内发生异常：{ex.Message}");
                }
            }
        }

        /// <summary>
        /// 任务轮询结束
        /// </summary>
        private void ExecuteFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine($"<{Name}> 内 Worker 停止...");
            Console.WriteLine($"<{Name}> 队列内剩余任务数：{TaskCount}");

            if (e.Error != null) Console.WriteLine($"<{Name}> 队列内发生异常：{e.Error.Message}");
            QueueStoped?.Invoke(this, e);
        }

        #region IDisposable Support

        public void Dispose()
        {
            Stop();
            TaskWorker.Dispose();
            while (tasks.TryDequeue(out T task)) { }
            tasks = null;
            QueueEvent.Close();
            
            //TODO: 感觉这里不太对...
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
