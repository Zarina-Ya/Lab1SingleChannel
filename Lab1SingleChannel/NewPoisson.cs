using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1SingleChannel
{
    class NewPoisson
    {
        private double lambda;
        private double tao;
        private Random _random;

        List<double> count = new List<double>();
        List<double> countTao = new List<double>();
        private double _eps = 0.001;
        public NewPoisson(double lambda, double tao)
        {
            this.lambda = lambda;
            this.tao = tao;
            _random = new Random(Guid.NewGuid().GetHashCode());
            generateCounts(); 
        }


        public int next()
        {
            double tmp = _random.NextDouble();
           // Console.WriteLine(tmp);
            double sum = 0;
            for (int i = 0; i < count.Count; i++)
            {
                sum += count[i];
                if (tmp <= sum) return i;
            }
            return count.Count;
        }

        public int nextTao()
        {
            //_random = new Random(Guid.NewGuid().GetHashCode());
            double tmp = _random.NextDouble();
            //Console.WriteLine(tmp);
            double sum = 0;
            for (int i = 0; i < countTao.Count; i++)
            {
                sum += countTao[i];
                if (tmp <= sum) return i;
            }
            return countTao.Count;
        }

        private void generateCounts()
        {
            double p = 0.0;
            int c = 0;
            do
            {
                p = generate(c, 1.0);
                count.Add(p);
                c++;
            } while (p > _eps);

            p = 0.0;
            c = 0;
            do
            {
                p = generate(c, tao);
                countTao.Add(p);
                c++;
            } while (p > _eps);
        }
        public double generate(int k, double t)
        {
            return
                (double)(((double)Math.Pow(lambda, k) * (double)Math.Pow(t, k)) /(double) factorial(k))
                * Math.Pow(Math.E,(-lambda * t));
        }

        private double factorial(int x)
        {
            int res = 1;
            for (int i = 1; i <= x; i++)
            {
                res *= i;
            }
            return res;
        }
    }
}
