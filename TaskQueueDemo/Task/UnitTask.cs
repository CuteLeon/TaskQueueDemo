using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public UnitTask(string name) => Name = name;
        public override string ToString() => $"任务：{Name}";
    }
}
