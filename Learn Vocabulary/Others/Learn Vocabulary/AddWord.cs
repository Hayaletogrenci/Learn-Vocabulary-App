using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Learn_Vocabulary
{
    public partial class AddWord : Form
    {
        private AllWords allWordsForm;
        public AddWord()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Gets the Turkish word from the `txtTurkceKelime` text box.
            string turkceKelime = txtTurkceKelime.Text;

            // Gets the English word from the `txtIngilizceKelime` text box.
            string ingilizceKelime = txtIngilizceKelime.Text;

            // Checks if both words are empty.
            if (!string.IsNullOrEmpty(turkceKelime) && !string.IsNullOrEmpty(ingilizceKelime))
            {
                // Creates a string with the English word followed by a hyphen followed by the Turkish word.
                string veri = ingilizceKelime + " - " + turkceKelime;

                // Writes the string to the file.
                WriteToFile(veri);

                // Clears the `txtTurkceKelime` and `txtIngilizceKelime` text boxes.
                txtTurkceKelime.Clear();
                txtIngilizceKelime.Clear();

                // Displays a message box that the word addition process is complete.
                MessageBox.Show("Word addition process completed.");
                // The LoadAllWords method is called to update the AllWords form.
                AllWords allWordsForm = Application.OpenForms["AllWords"] as AllWords;
                if (allWordsForm != null)
                {
                    allWordsForm.LoadAllWords();
                }
            }
            else
            {
                // Displays a message box that the user needs to fill in all fields.
                MessageBox.Show("Please fill in all fields.");
            }
        }

        private void WriteToFile(string veri)
        {
            // Gets the path of the file to write to.
            string dosyaAdi = "localdatabase.txt";
            string dosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dosyaAdi);

            // Opens a stream writer for the file.
            using (StreamWriter writer = new StreamWriter(dosyaYolu, true))
            {
                // Writes the string to the file.
                writer.WriteLine(veri);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ingilizceKelime = txtIngilizceKelime.Text.Trim();
            string turkceKelime = txtTurkceKelime.Text.Trim();
            string dosyaYolu = "localdatabase.txt";
            string[] satirlar = File.ReadAllLines(dosyaYolu);

            List<string> yeniSatirlar = new List<string>();
            bool kelimeSilindi = false;

            foreach (string satir in satirlar)
            {
                if (!string.IsNullOrEmpty(ingilizceKelime) && satir.Contains(ingilizceKelime + " - "))
                {
                    kelimeSilindi = true;
                    continue;
                }
                else if (!string.IsNullOrEmpty(turkceKelime) && satir.StartsWith(turkceKelime + " - "))
                {
                    kelimeSilindi = true;
                    continue;
                }

                yeniSatirlar.Add(satir);
            }

            if (kelimeSilindi)
            {
                File.WriteAllLines(dosyaYolu, yeniSatirlar);
                MessageBox.Show("Word deletion process completed.");

                // To update the AllWords form, call the LoadAllWords method.
                AllWords allWordsForm = Application.OpenForms["AllWords"] as AllWords;
                if (allWordsForm != null)
                {
                    allWordsForm.LoadAllWords();
                }
            }
            else
            {
                MessageBox.Show("The specified word could not be found.");
            }

            txtTurkceKelime.Clear();
            txtIngilizceKelime.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (allWordsForm == null || allWordsForm.IsDisposed)
            {
                allWordsForm = new AllWords();
                
            }
            allWordsForm.Show();
        }
    }  
}
