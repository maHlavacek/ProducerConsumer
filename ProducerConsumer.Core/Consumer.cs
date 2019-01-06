using System;
using System.Collections.Generic;
using System.Windows.Threading;


namespace ProducerConsumer.Core
{
    public class Consumer
    {
        #region Fields
        private Task _currentTask;
        private int _maxDuration;
        private int _minDuration;
        private int _minutesToFinishConsumption;
        private Random _random;
        private Queue<Task> _tasks;
        #endregion

        #region Properties
        public bool IsBusy { get; private set; }
        #endregion

        #region Constructor
        public Consumer(int min,int max,Queue<Task> _queue, EventHandler<string> logTask)
        {
            _minDuration = min;
            _maxDuration = max;
            _tasks = _queue;
            IsBusy = false;
            _minutesToFinishConsumption = 0;
            _random = new Random();
            FastClock.Instance.OneMinuteIsOver += Instance_OneMinuteIsOver;
        }
        #endregion

        #region Methods
        private void Instance_OneMinuteIsOver(object sender, DateTime time)
        {
            if(!IsBusy && _tasks.Count > 0)
            {
                _currentTask = _tasks.Peek();
                _tasks.Dequeue();
                IsBusy = true;
                _minutesToFinishConsumption = _random.Next(_minDuration, _maxDuration + 1);
                _currentTask.BeginConsuptionTime = time;
                _currentTask.BeginConsuption(_tasks.Count);
            }
            else
            {
                _minutesToFinishConsumption--;
                if(_minutesToFinishConsumption == 0)
                {
                    _currentTask.Finish(_tasks.Count, time);
                    IsBusy = false;
                }
            }
        }
        #endregion
    }
}
