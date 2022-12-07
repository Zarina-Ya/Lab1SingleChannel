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
        private readonly double Ltao;
        private readonly double L;

       /* public PoissonRandom(double x)
            : this(x, Environment.TickCount)
        {

        }*/

        public PoissonRandom(double x, int seed, double tao)
        {
            Ltao = Math.Exp(-x* tao);
            L = Math.Exp(-x );
            _rand = new Random(Guid.NewGuid().GetHashCode());
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

        public double NextTao()
        {
            double k = 0, p = 1;
            do
            {
                k++;
                p *= _rand.NextDouble();
            } while (p > Ltao);
            return k - 1;
        }
    }
}
// ЗАПРОС ДОЛЯ ОТ 1 ВЕРЕНИ , КУБИК С ИНТЕКНСИВНОСТЬ  0,2L