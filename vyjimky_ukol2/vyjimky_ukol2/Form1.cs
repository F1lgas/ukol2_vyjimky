using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vyjimky_ukol2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int vysledek = 1;
        private int i = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader(@"../../cisla.txt");

                while (!sr.EndOfStream)
                {
                    try
                    {
                        string cislo = sr.ReadLine();

                        int cislo2 = Convert.ToInt32(cislo);

                        if (cislo2 % 1 == 0)
                        {
                            vysledek *= cislo2;
                        }

                        listBox1.Items.Add(cislo);
                    }
                    catch (FormatException)
                    {
                        i++;
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("V souboru je moc velké číslo!");
                        Application.Exit();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Soubor nenalezen!");
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Součin všech celých čísel je " + vysledek + Environment.NewLine + "Přeskočilo se " + i + " řádků");
        }
    }
}
