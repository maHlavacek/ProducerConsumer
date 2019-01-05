using System;
using System.Collections.Generic;

namespace ProducerConsumer.Core
{
    public class Consumer
    {
        #region Fields
        private Task _currentTask;
        private int _maxDuration;
        private int _minDuration;
        private int _minutesToFinishConsumption;
        private int _random;
        private Queue<Task> _tasks;
        #endregion

        #region Constructor
        public Consumer(int min,int max,Queue<Task> _queue)
        {
            _minDuration = min;
            _maxDuration = max;
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
