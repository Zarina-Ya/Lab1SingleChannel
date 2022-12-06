using System.Collections.Generic;
namespace Lab1SingleChannel
{
    internal class HistoryMessageTimes
    {
        private List<double> _historyTimes;

        public int Count => _historyTimes.Count;
        public HistoryMessageTimes()
            => _historyTimes = new List<double>();

        public void AddMessageToHistory(double time)
            => _historyTimes.Add(time);

        private double GetAllHistoryTimes()
        {
            var res = 0.0;
            foreach (var item in _historyTimes)
                res += item;
            return res;
        }

        public double GetArithmeticMean()
            => GetAllHistoryTimes() / _historyTimes.Count;
    }
}
