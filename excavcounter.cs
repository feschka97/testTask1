using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class excavcounter : Form
    {
        excav standart;
        public excavcounter(excav pass)
        {
            InitializeComponent();
            standart = pass;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            float excavatorsNeeded = (int.Parse(textBox1.Text) / standart.performanceExcav);
            MessageBox.Show($"Нам необоходимо:{excavatorsNeeded},{standart.name}");
        }
    }
}
