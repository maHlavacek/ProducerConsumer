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
        private static int _count;
        #endregion

        #region EventHandler
        public  event EventHandler<string> LogTask;
        #endregion

        #region Constructor
        public Task(EventHandler<string> logTask)
        {
            LogTask += logTask;

        }
        #endregion

        #region Methods
        public void Start(int taskNumber, DateTime time, Queue<Task> tasks)
        {
            TaskNumber = taskNumber;
            _count++;
            CreationTime = time;
            tasks.Enqueue(this);
            LogTask?.Invoke(this, $"Quelength {_count}, Task {TaskNumber} erzeugt!");
        }
        public void Finish(int lenght, DateTime time)
        {
            LogTask?.Invoke(this, $"Quelength {_count}, Task {TaskNumber} wurde um {CreationTime.ToShortTimeString()} erzeugt und von {BeginConsuptionTime.ToShortTimeString()} - {time.ToShortTimeString()} bearbeitet!");
        }
        public void BeginConsuption(int length)
        {
            _count--;
            LogTask?.Invoke(this, $"Quelength {_count}, Task {TaskNumber} wird bearbeitet!");
        }
        #endregion
    }
}
