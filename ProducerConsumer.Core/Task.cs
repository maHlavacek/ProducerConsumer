using System;

namespace ProducerConsumer.Core
{
    public class Task
    {
        #region Properties
        public DateTime BeginConsuptionTime { get; private set; }
        public int CreationTime { get; private set; }
        public int TaskNumber { get; private set; }
        #endregion

        #region EventHandler
        public event EventHandler<string> LogTask;
        #endregion

        #region Constructor
        public Task()
        {

        }
        #endregion

        #region Methods
        public void Start()
        {

        }
        public void Finish()
        {

        }
        public void BeginConsuption()
        {

        }
        #endregion
    }
}
