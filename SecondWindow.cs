using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB_of_Sportsmans;

namespace DB_of_Sportsmans
{
    public partial class SecondWindow : Form
    {      
        public SecondWindow()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
    }
}
