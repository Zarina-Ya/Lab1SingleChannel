using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1SingleChannel
{
    public class Person
    {
        private HistoryMessageTimes _history;
        private QueueMessageTime _queueTime;
        private double _l;
        private PoissonRandom Poisson;
       // private NewPoisson Poisson;
        private static Random _rand;
        private readonly int M;

        private List<double> _countMessageWin = new List<double>();

        public double _p;
        public Person(double l, int m, Random random, double p = 0.5) {
            _l = l/m;
            _p = p;
            M = m;
             Poisson = new PoissonRandom(_l);
           // Poisson = new NewPoisson(l, 1.0);
            _queueTime = new QueueMessageTime();
            _history = new HistoryMessageTimes();
            _rand = random;
           
        }

        public void GenerateMessage()
        {
            _queueTime.AddToQueuePeople(Poisson.Next(), _rand);
        
        }

        public int CountQueue => _queueTime.Count;
        public int CountMessage => _countMessageWin.Count;

        public int HistoryCount => _history.Count;
        public double GetArithmeticMeanCountMessage()
        {
            var res = 0.0;
            foreach (var item in _countMessageWin)
                res += item;
            return res/_countMessageWin.Count;
        }
        public void UpdateProbability(Actiontype type)
        {
            switch (type)
            {
                case Actiontype.Conflict:
                     _p = Math.Max(1 / M, _p / 2);
                    break;
                case Actiontype.Empty:
                    _p = Math.Min(1, 2 * _p);
                    break;
                case Actiontype.Success:
                    _p = _p;
                    break;

            }
        }
        // влияние числа абонентов на характеристики системы 
        public void CheckMessageQueue()
            => _countMessageWin.Add(_queueTime.Count);

        public void AddWaiting()
            => _queueTime.AddWaiting();

        public double GetArithmeticMeanHistory()
            => _history.GetArithmeticMean();
        public void RemoveMessage()
        {
            _history.AddMessageToHistory(_queueTime.GetFirstMessage() + 1.0f);
            _queueTime.RemoveFirst();
        }

        public bool SendMessage()
        {
            var rand = _rand.NextDouble();
            return ( rand<= _p) && _queueTime.Count > 0;
        }
    }
}
