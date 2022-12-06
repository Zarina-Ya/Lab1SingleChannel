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
        public void AddToQueuePeople(double count, Random value, double tao = 1.0)
        {
            value = new Random(Guid.NewGuid().GetHashCode());
           
            for (int i = 0; i < count; i++)
            {
                var item = value.NextDouble();
               // Console.WriteLine($"value{item}");
                _queue.Add(item * (tao));
            }
        }

        public void AddWaiting(double tao = 1.0)
        {
            for (int i = 0; i < _queue.Count; i++)
                _queue[i] += tao;
        }
        public int Count => _queue.Count;
        public double GetFirstMessage()
            => _queue.First();
        public void RemoveFirst()
            => _queue.RemoveAt(0);
    }
}
