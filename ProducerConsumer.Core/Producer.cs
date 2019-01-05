using System;
using System.Collections.Generic;

namespace ProducerConsumer.Core
{
    public class Producer
    {
        #region Fields
        private Task _logTask;
        private int _minDuration;
        private int _maxDuration;
        private int _minutesToNextProduction;
        private int _random;
        private int _taskNumber;
        private Queue<Task> _tasks;
        #endregion

        #region Constructor
        public Producer(int min,int max,Task LogTask,Queue<Task> _queue)
        {
            _minDuration = min;
            _maxDuration = max;
            _logTask = LogTask;
            _tasks = _queue;
        }
        #endregion

        #region Methods
        private void Instance_OneMinuteIsOver(object sender, DateTime time)
        {

        }
        #endregion
    }
}
