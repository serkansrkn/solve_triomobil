using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace solve_triomobil
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<int> liste = new List<int>();

        int altKume = 0;
        int sayi = 0;
        int sayac = 0;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = -50000;
            numericUpDown1.Maximum = 50000;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            liste.Add((int)numericUpDown1.Value);
            listBox1.Items.Add(numericUpDown1.Value);
            numericUpDown1.Value = 0;
        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            int altKumeSayisi = (int)Math.Pow(2, liste.Count)/4;
            int[] altKumeler = new int[altKumeSayisi];
            int[] altKumeler2 = new int[altKumeSayisi];

            for (int i = 0; i < altKumeSayisi; i++)
            {
                sayi = i;
                altKume = 0;
                sayac = 0;

                for (int j = 0; j < liste.Count; j+=2)
                {
                    if (sayi % 2 == 1)
                    {
                        if (sayac == 0){ altKume += liste[j]; }
                        else { altKume += liste[j]; }
                        sayac++;
                    }

                    if (sayi == 1) { break; }
                    if (sayi >= 2) { sayi /= 2; }
                }
                altKumeler[i] = altKume;
            }

            for (int i = 0; i < altKumeSayisi; i++)
            {
                sayi = i;
                altKume = 0;
                sayac = 0;

                for (int j = 1; j < liste.Count; j += 2)
                {
                    if (sayi % 2 == 1)
                    {
                        if (sayac == 0) { altKume += liste[j]; }
                        else { altKume += liste[j]; }
                        sayac++;
                    }

                    if (sayi == 1) { break; }
                    if (sayi >= 2) { sayi /= 2; }
                }
                altKumeler2[i] = altKume;
            }

            int mak = altKumeler[0];
            for (int i = 1; i < altKumeSayisi; i++)
            {     
                if (mak < altKumeler[i])
                    mak = altKumeler[i];
            }

            int mak2 = altKumeler2[0];
            for (int i = 1; i < altKumeSayisi; i++)
            {
                if (mak2 < altKumeler2[i])
                    mak2 = altKumeler2[i];
            }

            if(mak>mak2)
            {
                label2.Text = mak.ToString();
            }
            else
            {
                label2.Text = mak2.ToString();
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            liste.Clear();
            altKume = 0;
        }

    }
}
