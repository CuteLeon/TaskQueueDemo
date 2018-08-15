# TaskQueueDemo
实现信号量控制的线程安全的任务队列系统；

异步任务队列框架：
    TaskQueue: 异步任务的队列载体，将需要的执行的任务集合依次入队（线程安全，可以并行入队），任务队列启动后将会一次将任务出栈并执行；
    UnitTask: 单元任务抽象类，具体的任务类需要继承此类并实现具体的任务逻辑；

框架特点
    1. 线程安全，可以将任务并行入队，任务线程由BackgroundWorker承担，在单独线程执行任务；
    2. 信号量控制，当任务队列为空时，寻魂会进入WaitOne状态以阻塞线程，避免循环空转，有新任务入队时将信号量Set，以接触阻塞重新启动任务队列；
    
    
使用方法：
  1. 任务类继承 UnitTask 并实现 Execute() 方法以执行具体的任务；
  
  2. 创建任务队列对象
      TaskQueue<MessageTask> MessageQueue = new TaskQueue<MessageTask>("消息任务队列");
      
  3. 按需绑定任务队列的事件，已提供事件包括：任务入队、任务出队、队列启动、队列停止、进入空闲状态...
  
  4. 消息入队
      Parallel.For(0, 10, new Action<int>(index => {
          MessageQueue.Enqueue(new MessageTask($"消息任务-{index}"));
      }));
      
  5. 队列启动
      MessageQueue.Start();
      
  6. 队列停止
    MessageQueue.Stop();
