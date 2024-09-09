using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Numerics;

namespace WindowsFormsApp1
{
    public partial class excavstats : Form
    {
        excav standart;
        public excavstats()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            standart = new excav(textBox1.Text, sbyte.Parse(comboBox1.Text), uint.Parse(textBox2.Text), short.Parse(textBox3.Text), float.Parse(textBox4.Text,CultureInfo.InvariantCulture));
            excavcounter m = new excavcounter(standart);
            m.Show();
        }
    }
}


