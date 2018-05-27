using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalkulatorReci
{
    public partial class Form1 : Form
    {
        bool plus = false;
        bool minus = false;
        bool mnozenje = false;
        bool deljenje = false;
        bool jednako = false;

        public void ProveriJednako() // Metoda namenjena uklanjanju baga da ne dodaje broj na rezultat nego pocinje novu kalkulaciju kad pritisnemo neki novi broj
        {
            if (jednako)
            {
                textBox1.Text = "";
                jednako = false;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProveriJednako();
            textBox1.Text = textBox1.Text + "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProveriJednako();
            textBox1.Text = textBox1.Text + "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProveriJednako();
            textBox1.Text = textBox1.Text + "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProveriJednako();
            textBox1.Text = textBox1.Text + "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ProveriJednako();
            textBox1.Text = textBox1.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ProveriJednako();
            textBox1.Text = textBox1.Text + "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ProveriJednako();
            textBox1.Text = textBox1.Text + "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ProveriJednako();
            textBox1.Text = textBox1.Text + "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ProveriJednako();
            textBox1.Text = textBox1.Text + "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ProveriJednako();
            textBox1.Text = textBox1.Text + "0";
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            ProveriJednako();
            if (textBox1.Text.Contains("."))
            {
                return;
            }
            else
            {
                textBox1.Text = textBox1.Text + ".";
            }
        }

        private void buttonPlusMinus_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("-"))
            {
                textBox1.Text = textBox1.Text.Remove(0, 1); // Uklanja prvi karakter
            }
            else
            {
                textBox1.Text = "-" + textBox1.Text;
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }
            else
            {
                plus = true;
                textBox1.Tag = textBox1.Text;
                textBox1.Text = "";
            }
        }

        private void buttonJednako_Click(object sender, EventArgs e)
        {
            jednako = true;
            if (plus)
            {
                double rez = Math.Round(Convert.ToDouble(textBox1.Tag) + Convert.ToDouble(textBox1.Text), 2); // Zaokruzuje na dve decimale
                textBox1.Text = BrojeviReciKomplet(rez);
            }
            if (minus)
            {
                double rez = Math.Round(Convert.ToDouble(textBox1.Tag) - Convert.ToDouble(textBox1.Text), 2);
                textBox1.Text = BrojeviReciKomplet(rez);
            }
            if (mnozenje)
            {
                double rez = Math.Round(Convert.ToDouble(textBox1.Tag) * Convert.ToDouble(textBox1.Text), 2);
                textBox1.Text = BrojeviReciKomplet(rez);
            }
            if (deljenje)
            {
                double rez = Math.Round(Convert.ToDouble(textBox1.Tag) / Convert.ToDouble(textBox1.Text), 2);
                textBox1.Text = BrojeviReciKomplet(rez);
            }
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }
            else
            {
                minus = true;
                textBox1.Tag = textBox1.Text;
                textBox1.Text = "";
            }
        }

        private void buttonMnozenje_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }
            else
            {
                mnozenje = true;
                textBox1.Tag = textBox1.Text;
                textBox1.Text = "";
            }
        }

        private void buttonDeljenje_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }
            else
            {
                deljenje = true;
                textBox1.Tag = textBox1.Text;
                textBox1.Text = "";
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            plus = minus = mnozenje = deljenje = jednako = false;
            textBox1.Text = "";
            textBox1.Tag = "";
        }

        static String BrojeviReciKomplet(double n) // Pretvara brojeve u reci ukljucujuci i decimale
        {
            string reci = "";
            double intDeo;
            double decDeo = 0;
            if (n == 0)
                return "nula";
            try
            {
                string[] spliter = n.ToString().Split('.');
                intDeo = double.Parse(spliter[0]);
                decDeo = double.Parse(spliter[1]);
            }
            catch
            {
                intDeo = n;
            }

            reci = BrojeviReci(intDeo);

            if (decDeo > 0)
            {
                if (reci != "")
                    reci += " i "; // pre decimala dodaje slovo 'i'
                int counter = decDeo.ToString().Length;
                switch (counter)
                {
                    case 1: reci += BrojeviReci(decDeo); break;
                    case 2: reci += BrojeviReci(decDeo); break;
                }
            }
            return reci;
        }

        static String BrojeviReci(double n) // Konvertuje brojeve u reci bez decimala
        {
            string[] brojeviArr = new string[] { "jedan", "dva", "tri", "cetiri", "pet", "sest", "sedam", "osam", "devet", "deset", "jedanaest", "dvanaest", "trinaest", "cetrnaest", "petnaest", "sesnaest", "sedamnaest", "osamnaest", "devetnaest" };
            string[] desetArr = new string[] { "dvadeset", "trideset", "cetrdeset", "pedeset", "sezdeset", "sedamdeset", "osamdeset", "devedeset" };
            string[] stoArr = new string[] { "sto", "dvesta", "trista", "cetiristo", "petsto", "sesto", "sedamsto", "osamsto", "devetsto" };
            string[] sufiksArr = new string[] { "hiljadu", "milion", "bilion", "trilion" };
            string reci = "";

            bool desetice = false;

            if (n < 0)
            {
                reci += "minus ";
                n *= -1;
            }

            int stepenovanje = (sufiksArr.Length + 1) * 3;

            while (stepenovanje > 3)
            {
                double stepen = Math.Pow(10, stepenovanje);
                if (n >= stepen)
                {
                    if (n % stepen > 0)
                    {
                        reci += BrojeviReci(Math.Floor(n / stepen)) + sufiksArr[(stepenovanje / 3) - 1];
                    }
                    else if (n % stepen == 0)
                    {
                        reci += BrojeviReci(Math.Floor(n / stepen)) + sufiksArr[(stepenovanje / 3) - 1];
                    }
                    n %= stepen;
                }
                stepenovanje -= 3;
            }
            if (n >= 1000)
            {
                if (n < 2000)
                {
                    reci += "hiljadu";
                    n %= 1000;
                }
                else reci += BrojeviReci(Math.Floor(n / 1000)) + "hiljade";
                n %= 1000;
            }
            if (0 <= n && n <= 999)
            {
                if ((int)n / 100 > 0)
                {
                    reci += stoArr[(int)n / 100 - 1];
                    n %= 100;
                }

                if ((int)n / 10 > 1)
                {
                    if (reci != "")
                        reci += " ";
                    reci += desetArr[(int)n / 10 - 2];
                    desetice = true;
                    n %= 10;
                }

                if (n < 20 && n > 0)
                {
                    if (reci != "" && desetice == false)
                        reci += " ";
                    reci += (desetice ? brojeviArr[(int)n - 1] : brojeviArr[(int)n - 1]);
                    n -= Math.Floor(n);
                }
            }

            return reci;

        }
    }
}
    
    

