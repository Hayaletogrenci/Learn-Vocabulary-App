using Kelime_Ezberleme.Sınıflar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learn_Vocabulary
{
    public partial class Settings : Form
    {
        
        public Settings()
        {
            InitializeComponent();
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            // Gets the language of the questions from the radio buttons.
            if (rdTurkish.Checked)
                FileContent.SoruDili = "Türkçe";
            else if (rdEnglish.Checked)
                FileContent.SoruDili = "İngilizce";
            else if (rdMixed.Checked)
                FileContent.SoruDili = "Karışık";
            else
            {
                MessageBox.Show("Please choose a language");
                return; 
            }

            // Gets the path of the database file.
            string dosyaAdi = "localdatabase.txt";
            string dosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dosyaAdi);

            // Checks if the database file exists.
            if (File.Exists(dosyaYolu))
            {
                // Reads the lines from the database file.
                FileContent.Icerik = FileSettings.ReadLinesOfFile(dosyaYolu);
            }
            else
            {
                // Displays an error message and returns.
                MessageBox.Show("The localdatabase.txt file does not exist.");
                return;
            }

            // Creates a new `Q_A` object.
            Q_A soruCevap = new Q_A();

            // Selects a question from the `Q_A` object.
            soruCevap.SoruyuSec();

            // Gets the question in the language specified in the `FileContent` property.
            string soru;
            if (FileContent.SoruDili == "Türkçe")
                soru = soruCevap.TurkceSoru();
            else if (FileContent.SoruDili == "İngilizce")
                soru = soruCevap.IngilizceSoru();
            else
                soru = soruCevap.KarisikSoru();

            // Creates a new `MainForm` object.
            MainForm mainForm = new MainForm();

            // Sets the text of the word label in the `MainForm` object to the question.
            mainForm.lblKelime.Text = soru;

            // Displays the `MainForm` object.
            mainForm.Show();

            // Hides the current form.
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddWord kelimeEklemeForm = new AddWord();
            kelimeEklemeForm.ShowDialog();
        }
    }
}
