using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1SingleChannel
{
    internal class QueueMessageTime
    {
        private List<double> _queue;
        public QueueMessageTime()
            => _queue = new List<double>();

        public void AddToQueuePeople(double count)
        {
            for (int i = 0; i < count; i++)
                _queue.Add(0.0f);
        }
        public void AddToQueuePeople(double count, Random value)
        {
            value = new Random();
            for (int i = 0; i < count; i++)
                _queue.Add(value.NextDouble());
        }

        public void AddWaiting()
        {
            for (int i = 0; i < _queue.Count; i++)
                _queue[i] += 1.0f;
        }
        public int Count => _queue.Count;
        public double GetFirstMessage()
            => _queue.First();
        public void RemoveFirst()
            => _queue.RemoveAt(0);
    }
}
