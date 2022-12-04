using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab1SingleChannel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            double accuracy = 0.001;
            int selection = (int)(9 / Math.Pow(4 * accuracy, 2));

            ALOHA aLOHA1 = new ALOHA(1, History, CountMess, NewChart);
            aLOHA1.StartGeneration(selection, 0, 0.9);
            InitPointToPlotAverageDelay(false, History);
            InitPointToPlotAverageNumSubscribers(CountMess);
            //ALOHA aLOHA2 = new ALOHA(2, History, CountMess, NewChart);
            //aLOHA2.StartGeneration(selection, 1, 0.9);

            //ALOHA aLOHA3 = new ALOHA(3, History, CountMess, NewChart);
            //aLOHA3.StartGeneration(selection, 2, 0.9);

            //ALOHA aLOHA4 = new ALOHA(4, History, CountMess, NewChart);
            //aLOHA4.StartGeneration(selection, 3, 0.9);

            //ALOHA aLOHA5 = new ALOHA(5, History, CountMess, NewChart);
            //aLOHA5.StartGeneration(selection, 4, 0.9);

            //ALOHA aLOHA6 = new ALOHA(8, History, CountMess, NewChart);
            //aLOHA6.StartGeneration(selection, 5, 0.9);

            //ALOHA aLOHA7 = new ALOHA(20, History, CountMess, NewChart);
            //aLOHA7.StartGeneration(selection, 6, 0.9);

            //ALOHA aLOHA8 = new ALOHA(30, History, CountMess, NewChart);
            //aLOHA8.StartGeneration(selection, 7, 0.9);

            //ALOHA aLOHA9 = new ALOHA(40, History, CountMess, NewChart);
            //aLOHA9.StartGeneration(selection, 8, 0.9);
            //Console.WriteLine($"Кол-во окон: {selection}");
            //Console.WriteLine($"Кол-во абонентов в сети: {2}");
        }

        private void History_Click(object sender, EventArgs e)
        {

        }

        public static void InitPointToPlotAverageNumSubscribers(Chart chart)
        {
            var lkr = 1.0;
            double l = 0.0f;
            while (l < lkr)
            {
                chart.Series[1].Points.AddXY(Math.Round(l, 1, MidpointRounding.AwayFromZero), AverageNumSubscribers(l));
                
                l += 0.1f;
            }
            chart.Series[1].LegendText = "Theoretical";
        }

        public static void InitPointToPlotAverageDelay(bool isAsync, Chart generalSync)
        {
           

            double l = 0.0f;
            var lkr = 1.0;
            while (l < lkr)
            {
                var Nl = AverageNumSubscribers(l) / l;
                var res = (isAsync ? Nl : Nl + 0.5f);
              
                    generalSync.Series[1].Points.AddXY(Math.Round(l, 1, MidpointRounding.AwayFromZero), res);
                    generalSync.Series[1].LegendText = "SyncTheoretical";

                
                l += 0.1f;
            }
        }

        private static double AverageNumSubscribers(double l)
            => l * (2 - l) / (2 * (1 - l));
    }
}