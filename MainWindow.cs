using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.IO;
using System;


namespace DB_of_Sportsmans
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            AcceptButton = buttonAdd;
        }                       //конструктор главного окна

        public List<Watch> watchs = new List<Watch>();//инициализация коллекции
        SecondWindow filtrationWindow = new SecondWindow();   //инициализация обекта класса окна для вывода результатов фильтрации/поиска
        public int iCur = 0;                    //количество блоков записи
        public int n = 0;                       //количество записей
        public int c = 0;
        public string fileName = "";
        public Watch FWatch
        {
            set
            {
                tbBrand.Text = value.Brand;
                tbExp.Text = value.Exp.ToString();
                tbModel.Text = value.Model;
                tbColor.Text = value.Color;
                cbWaterProof.Checked = value.WaterProof;
            }
            get
            {
                Watch s = new Watch();
                s.Brand = tbBrand.Text;
                if (tbExp.Text == "") tbExp.Text = "0";
                s.Exp = Convert.ToInt16(tbExp.Text);
                s.Model = tbModel.Text;
                s.Color = tbColor.Text;
                s.WaterProof = cbWaterProof.Checked;
                return s;
            }
        }          //метод для ввода и вывода на форму 

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            watchs.Add(FWatch);
            iCur++;
            if (timer1.Enabled == false) timer1.Enabled = true;
            tbBrand.Text = "";
            tbModel.Text = "";
            tbExp.Text = "";
            tbColor.Text = "";
            cbWaterProof.Checked = false;
            EnableButtons();
        }          //добавить запись

        private void FilterBrand_Click(object sender, EventArgs e)
        {
            Watch s = new Watch();
            List<Watch> filtredwatch = new List<Watch>();
            try
            {
                s.Brand = toolStripTextBox1.Text;
                filtredwatch = watchs.FindAll(x => x.Brand == s.Brand);
                if (toolStripTextBox1.Text == "")
                {
                    filtredwatch = watchs;
                }
            }
            catch
            {
                filtredwatch = watchs;
            }
            ShowWatch(filtredwatch);
        }//фильтр по ФИО

        private void FilterExp_Click(object sender, EventArgs e)
        {
            Watch s = new Watch();
            List<Watch> filtredwatch = new List<Watch>();
            try
            {
                s.Exp = Convert.ToInt16(toolStripTextBox1.Text);
                filtredwatch = watchs.FindAll(x => x.Exp == s.Exp);
            }
            catch (FormatException)
            {
                filtredwatch = watchs;
            }
            ShowWatch(filtredwatch);
        }//фильр по разряду

        private void radioButton3_Click(object sender, EventArgs e)
        {
            Watch s = new Watch();
            List<Watch> filtredwatch = new List<Watch>();
            try
            {
                s.Model = toolStripTextBox1.Text;
                filtredwatch = watchs.FindAll(x => x.Model == s.Model);
                if (toolStripTextBox1.Text == "")
                {
                    filtredwatch = watchs;
                }
            }
            catch
            {
                filtredwatch = watchs;
            }
            ShowWatch(filtredwatch);
        }        //фильтр по виду

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel1.Text = (iCur + 1).ToString();
            if (iCur + 1 == watchs.Count)
            {
                toolStripButton5.Enabled = false;
                toolStripButton6.Enabled = false;
            }
            else
            {
                toolStripButton5.Enabled = true;
                toolStripButton6.Enabled = true;
            }
            if (iCur == 0)
            {
                toolStripButton4.Enabled = false;
                toolStripButton3.Enabled = false;
            }
            else
            {
                toolStripButton4.Enabled = true;
                toolStripButton3.Enabled = true;
            }
            if (watchs.Count == 0) toolStripButton9.Enabled = false;
            else toolStripButton9.Enabled = true;
        }               //таймер для отображения индекса текущей зааписи + активации и деактивации кнопок управления, как способ обратоки исключения

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (iCur > watchs.Count - 1) FWatch = watchs[watchs.Count - 1];
                else
                {
                    iCur++;
                    this.FWatch = watchs[iCur];
                }
            }
            catch
            {
                MessageBox.Show("нет записей");
            }
            timer1.Enabled = true;
        }    //на запись вперёд

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (iCur == 0)
                    this.FWatch = watchs[0];
                else
                {
                    iCur--;
                    this.FWatch = watchs[iCur];
                }
            }
            catch
            {
                MessageBox.Show("нет записей");
            }
            timer1.Enabled = true;
        }    //на запись назад

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                fileName = savedialog.FileName;
                System.IO.StreamWriter writer = new System.IO.StreamWriter(fileName, true);
                Watch s = new Watch();
                for (int i = 0; i < watchs.Count; i++)
                {
                    s = watchs[i];
                    writer.WriteLine(s.Brand);
                    writer.WriteLine(s.Color);
                    writer.WriteLine(s.Model);
                    writer.WriteLine(s.Exp);
                    writer.WriteLine(s.WaterProof);
                }
                writer.WriteLine("КОНЕЦ");
                writer.Close();
            }
        }//сохранить КАК

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            watchs.Clear();
            iCur = 0;
            n = 0;
            OpenFileDialog opendialog = new OpenFileDialog();
            opendialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            if (opendialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(opendialog.FileName);

                System.IO.StreamReader calcRecs = new System.IO.StreamReader(opendialog.FileName);//
                while (calcRecs.ReadLine() != "КОНЕЦ") n++;                                       //подсчёт количества записей
                n = n / 5;                                                                        //
                calcRecs.Close();                                                                 //
                                                                                                    
                for (int i = 0; i < n; i++)
                {
                    Watch s = new Watch();
                    s.Brand = reader.ReadLine();
                    s.Color = reader.ReadLine();
                    s.Model = reader.ReadLine();
                    s.Exp = Convert.ToInt16(reader.ReadLine());
                    s.WaterProof = Convert.ToBoolean(reader.ReadLine());
                    watchs.Add(s);
                    iCur++;
                }
                reader.Close();
                toolStripStatusLabel1.Text = " загружено" + n;
                timer2.Enabled = true;
            }
            timer1.Enabled = true;
            EnableButtons();
        }//открыть/загрузить

        //-----------------------------------------------------класс----------------------
        public class Watch : IComparable<Watch>
        {
            public string Brand;     //Бренд
            private int exp;         //Срок годности
            public string Model;     //Модель 
            public string Color;     //Цвет
            public bool WaterProof;  //Водостойкость

            public int Exp
            {
                set { if (value > 0 && value <= 126) exp = value; }
                get { return exp; }
            }           //метод с условием для доступа к скрытому полю "exp"

            Watch(string Brand, int exp, string Model, string Color, bool WaterProof)
            {
                this.Brand = Brand;
                this.exp = Exp;
                this.Model = Model;
                this.Color = Color;
                this.WaterProof = WaterProof;
            }//конструктор с параметрами

            public Watch() : this("non", 1, "non", "black", false) { }//конструктор по умолчанию, наследованный от конструктора с параметрами

            public int CompareTo(Watch ob)
            {
                return this.Brand.CompareTo(ob.Brand);
            }

            public override bool Equals(Object obj)
            {
                return ((Watch)obj).Exp == this.Exp;
            }
        }
        //--------------------------------------------------------------------------------
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            try
            {
                this.FWatch = watchs[watchs.Count - 1];
                iCur = watchs.Count - 1;
            }
            catch
            {
                MessageBox.Show("нет записей");
            }
            timer1.Enabled = true;
        }      //в самый конец

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                iCur = 0;
                this.FWatch = watchs[iCur];
            }
            catch
            {
                MessageBox.Show("нет записей");
            }
            timer1.Enabled = true;
        }      //в самое начало

        private void FindBrand_Click(object sender, EventArgs e)
        {
            Watch s = new Watch();
            List<Watch> filtredwatch = new List<Watch>();
            try
            {
                s.Brand = toolStripTextBox2.Text;
                int k = watchs.FindIndex(x => x.Brand == s.Brand);
                filtredwatch.Add(watchs[k]);
            }
            catch
            {
                filtredwatch = watchs;
            }
            ShowWatch(filtredwatch);
        }    //поиск по фио

        private void FindExp_Click(object sender, EventArgs e)
        {
            Watch s = new Watch();
            List<Watch> filtredwatch = new List<Watch>();
            try
            {
                s.Exp = Convert.ToInt16(toolStripTextBox2.Text);
                int k = watchs.IndexOf(s, 0);
                filtredwatch.Add(watchs[k]);
            }
            catch (FormatException)
            {
                filtredwatch = watchs;
            }
            ShowWatch(filtredwatch);
        }   //поиск по разряду

        private void SortBrand_Click(object sender, EventArgs e)
        {
            watchs.Sort((x, y) => x.Brand.CompareTo(y.Brand));
        }    //сортировка по фио

        private void FindModel_Click(object sender, EventArgs e)
        {
            Watch s = new Watch();
            List<Watch> filtredwatch = new List<Watch>();
            try
            {
                s.Model = toolStripTextBox2.Text;
                int k = watchs.FindIndex(x => x.Model == s.Model);
                filtredwatch.Add(watchs[k]);
            }
            catch
            {
                filtredwatch = watchs;
            }
            ShowWatch(filtredwatch);
        }   //поиск по виду

        private void SortModel_Click(object sender, EventArgs e)
        {
            watchs.Sort((x, y) => x.Model.CompareTo(y.Model));
        }   //сортировка по виду

        private void SortExp_Click(object sender, EventArgs e)
        {
            watchs.Sort((x, y) => x.Exp.CompareTo(y.Exp));
        }   //сортировка по разряду

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(toolStripLabel1.Text) < 0 || Convert.ToInt16(toolStripLabel1.Text) > watchs.Count)
                {
                    MessageBox.Show("Записи с таким номером не существует");
                }
                else
                {
                    iCur = Convert.ToInt16(toolStripLabel1.Text);
                    iCur--;
                    this.FWatch = watchs[iCur];
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Для ввода номера записи используйте только цифры");
            }
            timer1.Enabled = true;
        }      //предыдущая

        private void toolStripLabel1_Enter(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }       //ввод

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {

                watchs.RemoveAt(iCur);
                if (iCur <= 0)
                    iCur = 0;
                else
                    iCur--;
                this.FWatch = watchs[iCur];

            }
            catch
            {
                MessageBox.Show("аяяй");
            }

        }             //удаление

        private void Form1_Load(object sender, EventArgs e)
        {
            //---------
            try
            {
            StreamReader r = new StreamReader("settings.ini");
            if (r.ReadLine() == "autoload = true") автозагрузкаБазыToolStripMenuItem.Checked = true;
            else автозагрузкаБазыToolStripMenuItem.Checked = false;
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке файла настроек");
            }
            //----------------
            if (автозагрузкаБазыToolStripMenuItem.Checked == true)
            {
                try
                {
                    watchs.Clear();
                    iCur = 0;
                    n = 0;

                    System.IO.StreamReader reader = new System.IO.StreamReader("База данных спортсменов.txt");

                    System.IO.StreamReader calcRecs = new System.IO.StreamReader("База данных спортсменов.txt");//
                    while (calcRecs.ReadLine() != "КОНЕЦ") n++;                                                 //подсчёт количества записей
                    n = n / 5;                                                                                  //
                    calcRecs.Close();                                                                           //

                    for (int i = 0; i < n; i++)
                    {
                        Watch s = new Watch();
                        s.Brand = reader.ReadLine();
                        s.Color = reader.ReadLine();
                        s.Model = reader.ReadLine();
                        s.Exp = Convert.ToInt16(reader.ReadLine()); 
                        s.WaterProof = Convert.ToBoolean(reader.ReadLine());
                        watchs.Add(s);
                        iCur++;
                    }
                    reader.Close();
                    toolStripStatusLabel1.Text = n + " записей загружено";
                    timer2.Enabled = true;
                    reader.Close();
                    timer1.Enabled = true;
                    EnableButtons();
                }
                catch
                {
                    MessageBox.Show("При автозагрузкии БД произошла ошибка. Возможно отсутствует файл 'База данных спортсменов.txt'");
                }
            }
             
        }                  //авто загрузка

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int iCur2 = iCur;
            watchs.RemoveAt(iCur);
            iCur--;
            watchs.Insert(iCur2, FWatch);
            iCur++;
        }            //редактирование

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.SelectAll();
        }

        private void toolStripTextBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void butShow_Click(object sender, EventArgs e)
        {
            ShowWatch(watchs);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            c++;
            if (c == 4)
            {
                timer2.Enabled = false;
                toolStripStatusLabel1.Text = "";
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void сохранитьToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (fileName != "")
            {
                try
                {
                    System.IO.StreamWriter writer = new System.IO.StreamWriter(fileName, false);
                    Watch s = new Watch();
                    for (int i = 0; i < watchs.Count; i++)
                    {
                        s = watchs[i];
                        writer.WriteLine(s.Brand);
                        writer.WriteLine(s.Color);
                        writer.WriteLine(s.Model);
                        writer.WriteLine(s.Exp);
                        writer.WriteLine(s.WaterProof);
                    }
                    writer.WriteLine("КОНЕЦ");
                    writer.Close();
                    toolStripStatusLabel1.Text = "Cохраненте выполнено в  " + fileName;
                    timer2.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("сохрениение не удалось");
                }
            }
            else
            {
                сохранитьToolStripMenuItem1_Click(sender, e);
            }
        }//сохранить

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                StreamWriter writer = new StreamWriter("settings.ini", false);
                if (автозагрузкаБазыToolStripMenuItem.Checked == true)
                    writer.WriteLine("autoload = true");
                if (автозагрузкаБазыToolStripMenuItem.Checked == false)
                    writer.WriteLine("autoload = false");
                if ((автозагрузкаБазыToolStripMenuItem.Checked != true) && (автозагрузкаБазыToolStripMenuItem.Checked != false)) MessageBox.Show("Ошибка при созранении файла настроек");
                writer.Close();
            }
            catch(System.IO.IOException)
            {
                MessageBox.Show("Нет доступа к файлу настроек. Если он открыт - закройте");
            }
        }

        private void butDelAll_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Удалить все записи?", "Удалить всё", MessageBoxButtons.OKCancel))
            {
                watchs.Clear();
                iCur = 0;
            }   
        }

        public void ShowWatch (List<Watch> filtredsportmans)
        {
            foreach (Watch x in filtredsportmans)
            {
                int i = filtrationWindow.dataGridView1.Rows.Add();
                filtrationWindow.dataGridView1["ColumnFIO", i].Value = x.Brand;
                filtrationWindow.dataGridView1["ColumnDataOfBorn", i].Value = x.Color;
                filtrationWindow.dataGridView1["ColumnKind", i].Value = x.Model;
                filtrationWindow.dataGridView1["ColumnRank", i].Value = x.Exp;
                filtrationWindow.dataGridView1["ColumnMedCheck", i].Value = x.WaterProof;
            }
            filtrationWindow.ShowDialog();
        }
        
        public void EnableButtons()
        {
            toolStripButton5.Enabled = true;
            toolStripButton6.Enabled = true;
            toolStripButton3.Enabled = true;
            toolStripButton4.Enabled = true;
            toolStripButton7.Enabled = true;
            toolStripButton9.Enabled = true;
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            toolStripTextBox2.SelectAll();
        }
    }
}
