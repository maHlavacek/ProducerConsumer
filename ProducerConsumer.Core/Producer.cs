using System;

namespace ProducerConsumer.Core
{
    public class Producer
    {
        #region Fields

        private int _minDuration;
        private int _maxDuration;
        private int _minutesToNextProduction;
        private int _taskNumber;
        private Random _random;
        private Task _logTask;

        #endregion
    }
}
