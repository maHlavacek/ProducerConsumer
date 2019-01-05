using System;

namespace ProducerConsumer.Core
{
    public class Task
    {
        #region Properties
        public DateTime BeginConsuptionTime { get; private set; }
        private int CreationTime { get; set; }
        private int TaskNumber { get; set; }
        #endregion

        #region EventHandler
        public event EventHandler<Task> LogTask;
        #endregion

        #region Constructor
        public Task()
        {
            BeginConsuptionTime = DateTime.Now;
        }
        #endregion

        #region Methods
        #endregion
    }
}
