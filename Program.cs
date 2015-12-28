using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB_of_Sportsmans;

namespace DB_of_Sportsmans
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainWindow form1 = new MainWindow();
            SecondWindow form2 = new SecondWindow();
            Application.Run(form1);

        }
    }
}
