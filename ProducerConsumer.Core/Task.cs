using System;
using System.Collections.Generic;

namespace ProducerConsumer.Core
{
    public class Task
    {
        #region Properties
        public DateTime BeginConsuptionTime { get; set; }
        public DateTime CreationTime { get; private set; }
        public int TaskNumber { get; private set; }
        #endregion

        #region EventHandler
        public  event EventHandler<string> LogTask;
        #endregion

        #region Constructor
        public Task()
        {
        }
        #endregion

        #region Methods
        public void Start(int taskNumber, DateTime time, Queue<Task> tasks)
        {
            TaskNumber = taskNumber;
            CreationTime = time;
            tasks.Enqueue(this);
            LogTask?.Invoke(this, $"Task {TaskNumber} erzeugt!");
        }
        public void Finish(int lenght, DateTime time)
        {
            LogTask?.Invoke(this, $"Task {TaskNumber} wurde um {CreationTime.ToShortTimeString()} erzeugt und von {BeginConsuptionTime.ToShortTimeString()} - {time.ToShortTimeString()} bearbeitet!");
        }
        public void BeginConsuption(int length)
        {
            LogTask?.Invoke(this, $"Task {TaskNumber} wird bearbeitet!");
        }
        #endregion
    }
}
