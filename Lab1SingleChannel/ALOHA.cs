using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
namespace Lab1SingleChannel
{
    public class ALOHA
    {
        private const double _lkr = 0.9;

        private readonly int M;

        private List<Person> _persons;

        private Chart _history;
        private Chart _countMessage;
        private Chart _newChart;
        private Random _random = new Random();
        public ALOHA(int m, Chart history, Chart countMessage, Chart newChart)
        {
            M = m;
            _history = history;
            _countMessage = countMessage;
            _newChart = newChart;
           
        }
           
        private void CreatePerson(double l, double p)
        {
            _persons = new List<Person>();

            for (int i = 0; i < M; i++)
            {
                _persons.Add(new Person(l, M, _random, p));
            }

        }

        private void GenerateMessageAllPersons()
        {
            foreach (Person person in _persons)
                person.GenerateMessage();
        }

        private void CheckMessageInSystem()
        {
            foreach(Person person in _persons)
                person.CheckMessageQueue();
        }


        private void SendMessageAllPersons()
        {
            var message = new List<Tuple<bool, Person>>();
            foreach (Person person in _persons)
                message.Add(new Tuple<bool, Person>(person.SendMessage(), person));

            var sendMessagePerson = message.FindAll(s => s.Item1 == true);

            if (sendMessagePerson.Count > 1)
            {
                foreach (var person in _persons)
                    person.UpdateProbability(Actiontype.Conflict);
            }
            else if (sendMessagePerson.Count == 1)
                sendMessagePerson.First().Item2.RemoveMessage();
            else
            {
                foreach (var person in _persons)
                    person.UpdateProbability(Actiontype.Empty);
            }
        }



        private void UpdateTimesMessage()
        {
            foreach (var person in _persons)
            {
                person.AddWaiting();
            }
        }

        public void StartGeneration( int countWin, double p = 0.5)
        {
            var l = 0.0;

            while(l < _lkr )
            {
                CreatePerson(l, p);
                for (int i = 0; i < countWin; i++)
                {
                    GenerateMessageAllPersons();
                    CheckMessageInSystem();
                    SendMessageAllPersons();
                    UpdateTimesMessage();
  
                }

                SendRemainingMessages();
                InitPlots(l);

                l += 0.1;
            }
        }

        private void InitPlots(double l)
        {
            var resHistory = 0.0;
            var resMessage = 0.0;
            
            var countOutput = 0.0;

            MinMaxPlot(_newChart);

            foreach (var person in _persons)
            {
                resHistory += person.GetArithmeticMeanHistory();
                resMessage += person.GetArithmeticMeanCountMessage();
                countOutput +=(double)(person.HistoryCount /(double) person.CountMessage);
        
            }
           
            _history.Series[0].Points.AddXY(Math.Round(l, 1, MidpointRounding.AwayFromZero), resHistory/M);
            _countMessage.Series[0].Points.AddXY(Math.Round(l, 1, MidpointRounding.AwayFromZero), resMessage/M);
            _newChart.Series[0].Points.AddXY(Math.Round(l, 1, MidpointRounding.AwayFromZero), countOutput);
        }

        private static void MinMaxPlot(Chart chart)
        {
            chart.ChartAreas[0].AxisX.Maximum = 1;
            chart.ChartAreas[0].AxisX.Minimum = 0;
        }

        private bool CheckMessagePersons()
        {
            var messgePersons = _persons.FindAll(s => s.CountQueue > 0);
            if(messgePersons.Count > 0)
                return true;
            return false;
        }
        private  void SendRemainingMessages()
        {
            while (CheckMessagePersons())
            { 
                CheckMessageInSystem();
                SendMessageAllPersons();
                UpdateTimesMessage();
            }
        }

    }

    
    public enum Actiontype
    {
        Empty,
        Conflict,
        Success
    }
}
