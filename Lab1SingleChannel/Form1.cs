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

            ALOHA aloha = new ALOHA(10,History, CountMess, NewChart);
            aloha.StartGeneration(10000, 0.9);
        }
    }
}
