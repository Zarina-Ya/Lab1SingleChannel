using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1SingleChannel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            double accuracy = 0.01;
            int selection = (int)(9 / Math.Pow(4 * accuracy, 2));
            int countPerson = 10;
            ALOHA aloha = new ALOHA(countPerson, History, CountMess, NewChart);
            aloha.StartGeneration(selection, 0.9);
            OnRequest onRequest = new OnRequest(countPerson, 0.2, History, CountMess, NewChart);
            onRequest.StartGeneration(100);
            //PoissonRandom random = new PoissonRandom(1.0, 10, 0.8);
            //var sum = 0.0;
            //for(int i = 0; i < 10000; i++)
            //{
            //    sum += random.NextTao();
            //}
            //Console.WriteLine(sum / 10000);
        }

        private void NewChart_Click(object sender, EventArgs e)
        {

        }
    }
}
