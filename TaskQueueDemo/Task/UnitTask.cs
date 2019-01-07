namespace TaskQueueDemo.Task
{
    /// <summary>
    /// 单元任务
    /// </summary>
    public abstract class UnitTask
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public UnitTask(string name) => Name = name;
        public override string ToString() => $"任务：{Name}";

        /// <summary>
        /// 执行任务
        /// </summary>
        public abstract void Execute();
    }
}
