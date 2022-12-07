using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1SingleChannel
{
    class PersonRequest
    {
        private HistoryMessageTimes _history;
        private QueueMessageTime _queueTime;
        private double _l;
        //private NewPoisson Poisson;
        private PoissonRandom Poisson;
        private Random _random;
        private readonly double _tao;
        private List<double> _countMessageWin = new List<double>();
        private List<double> _messageSystemTime = new List<double>();
        public int CountQueue => _queueTime.Count;
        public int CountMessage => _countMessageWin.Count;
        public int HistoryCount => _history.Count;
        public double TimeMessageCount()
        {
            var sum = 0.0;
            for(int i = 0; i < _messageSystemTime.Count; i++)
            {
                sum += _messageSystemTime[i];
            }
            return sum;
        }

        public PersonRequest(double l , int m, double tao, Random rand)
        {
            _l = l / m;
            _random = rand;
            _tao = tao;
            //Poisson = new NewPoisson(_l, tao);
            Poisson = new PoissonRandom(_l, Guid.NewGuid().GetHashCode(), _tao);
            //Poisson = new PoissonRandom(_l);
            _queueTime = new QueueMessageTime();
            _history = new HistoryMessageTimes();
           
        }

        public void CheckMessageQueue()
        {
           _countMessageWin.Add(_queueTime.Count);
        }

        public void CheckMessageTime(bool isWin)
        {
            if (isWin)
                _messageSystemTime.Add(1.0 + _tao);
            else
                _messageSystemTime.Add(_tao);

        }
        public void GenerateMessage(bool isWin)
        {
            if (isWin)
                _queueTime.AddToQueuePeople(Poisson.Next(), _random);
            else
                _queueTime.AddToQueuePeople(Poisson.NextTao(), _random, tao: _tao);
        }

        public double GetArithmeticMeanCountMessage()
        {
            var res = 0.0;
            foreach (var item in _countMessageWin)
                res += item;
            return res / _countMessageWin.Count;
        }

        public void AddWaiting(bool isWin)
        {
            if (isWin)
            {
                _queueTime.AddWaiting();
            }
            else
            {
                _queueTime.AddWaiting(_tao);
            }

        }

        public double GetArithmeticMeanHistory()
            => _history.GetArithmeticMean();

        public void RemoveMessage()
        {
            _history.AddMessageToHistory(_queueTime.GetFirstMessage() + 1.0f);
            _queueTime.RemoveFirst();
        }

        public bool SendMessage()
            => _queueTime.Count > 0;
        
    }
}
