using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1SingleChannel
{
    class PoissonRandom
    {
        private readonly Random _rand;
        private readonly double L;

        public PoissonRandom(double x)
            : this(x, Environment.TickCount)
        {

        }

        public PoissonRandom(double x, int seed)
        {
            L = Math.Exp(-x);
            _rand = new Random(seed);
        }

        public double Next()
        {
            double k = 0, p = 1;
            do
            {
                k++;
                p *= _rand.NextDouble();
            } while (p > L);
            return k - 1;
        }
    }
}
