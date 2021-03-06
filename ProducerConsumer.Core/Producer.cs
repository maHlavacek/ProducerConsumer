﻿using System;
using System.Collections.Generic;
using System.Windows.Threading;


namespace ProducerConsumer.Core
{
    public class Producer
    {
        #region Fields
        private EventHandler<string> _logTask;
        private Task _task;
        private int _minDuration;
        private int _maxDuration;
        private int _minutesToNextProduction;
        private Random _random;
        private int _taskNumber;
        private Queue<Task> _tasks;

        #endregion

        #region Constructor
        public Producer(int min,int max,EventHandler<string> logTask,Queue<Task> _queue)
        {
            _minDuration = min;
            _maxDuration = max;
            _tasks = _queue;
            _taskNumber = 0;
            _minutesToNextProduction = 0;
            FastClock.Instance.OneMinuteIsOver += Instance_OneMinuteIsOver;
            _random = new Random();
            _logTask = logTask;
        }
        #endregion

        #region Methods
        private void Instance_OneMinuteIsOver(object sender, DateTime time)
        {
            if(_minutesToNextProduction == 0)
            {
                _minutesToNextProduction = _random.Next(_minDuration, _maxDuration);
            }
            else
            {
                _minutesToNextProduction--;
                if(_minutesToNextProduction == 0)
                {
                    _task = new Task(_logTask);
                    _task.Start(_taskNumber, time, _tasks);
                    _taskNumber++;
                }
            }
        }
        #endregion
    }
}
