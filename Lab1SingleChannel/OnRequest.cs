using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab1SingleChannel
{
    class OnRequest
    {
        private readonly int _M;
        private readonly double _lkr = 0.9;
        private List<PersonRequest> _peoples = new List<PersonRequest>();

        private readonly double _t = 0.3;
        private Chart _history;
        private Chart _countMessage;
        private Chart _newChart;
        private Random random;

        public OnRequest(int M, double t,
            Chart history, Chart CountMessage, Chart newChart)
        {
            _M = M;
            _t = t;
            _history = history;
            _countMessage = CountMessage;
            _newChart = newChart;
            random = new Random();
        }
        public void SendRequestToPerson(int index)
        {
            AddWaitingOrRequest();
            GenerateMessageAllPersonsRequest();
          
            if (_peoples[index].SendMessage())
            {
                _peoples[index].RemoveMessage();
                AddWaitingForWin();
                GenerateMessageAllPersonsWin();
                CheckWaitingTime(true);
            }
            else
                CheckWaitingTime(false);
        }
        private void CheckWaitingTime(bool isWin)
        {
            foreach (var i in _peoples)
                i.CheckMessageTime(isWin);
        }
        private void AddWaitingOrRequest()
        {
            foreach (var i in _peoples)
                i.AddWaiting(false);
        }
        
        private void AddWaitingForWin()
        {
            foreach (var i in _peoples)
                i.AddWaiting(true);
        }
        private void CheckMessageInSystem()
        {
            foreach (PersonRequest person in _peoples)
                person.CheckMessageQueue();
        }
        private void CreatePerson(double l)
        {
            _peoples = new List<PersonRequest>();
            for(int i = 0; i < _M; i++)
            {
                _peoples.Add(new PersonRequest(l, _M, _t ,random));
            }
        }

        private void GenerateMessageAllPersonsWin()
        {
            foreach (PersonRequest person in _peoples)
                person.GenerateMessage(true);
        }

        private void GenerateMessageAllPersonsRequest()
        {
            foreach (PersonRequest person in _peoples)
                person.GenerateMessage(false);
        }

        private void UpdateTimesMessage()
        {
            foreach (var person in _peoples)
            {
                person.AddWaiting(true);
            }
        }

        public void StartGeneration(int countWin)
        {
            var l = 0.0;

            while( l < _lkr)
            {
                CreatePerson(l);
                GenerateMessageAllPersonsWin();
                for (int i = 0; i < countWin; i++)
                {
                    SendRequestToPerson(i % _peoples.Count);
                    CheckMessageInSystem();
                }
                SendRemainingMessages(countWin);
                InitPlots(l);

                l += 0.1;

            }
        }

        private void InitPlots(double l)
        {
            var resHistory = 0.0;
            var resMessage = 0.0;

            var countOutput = 0.0;

            
            foreach (var person in _peoples)
            {
                resHistory += person.GetArithmeticMeanHistory();
                resMessage += person.GetArithmeticMeanCountMessage();
                countOutput += (double)(person.HistoryCount / (double)person.TimeMessageCount());

            }

            _history.Series[1].Points.AddXY(Math.Round(l, 1, MidpointRounding.AwayFromZero), resHistory / _M);
            _countMessage.Series[1].Points.AddXY(Math.Round(l, 1, MidpointRounding.AwayFromZero), resMessage / _M);
            _newChart.Series[1].Points.AddXY(Math.Round(l, 1, MidpointRounding.AwayFromZero), countOutput);
        }
        private bool CheckMessagePersons()
        {
            var messgePersons = _peoples.FindAll(s => s.CountQueue > 0);
            if (messgePersons.Count > 0)
                return true;
            return false;
        }

        private void SendRemainingMessages(int win)
        {
            int i = win;
            while (CheckMessagePersons())
            {
                SendRequestToPerson(i % _peoples.Count);
                CheckMessageInSystem();
                i++;
            }
        }
    }
}
