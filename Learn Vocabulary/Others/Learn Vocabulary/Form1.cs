using Kelime_Ezberleme.Sınıflar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Learn_Vocabulary
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) // Sets the initial properties of the form and controls
        {
            lblKelime.BackColor = Color.FromArgb(100, 0, 0, 0);
            btnOnayla.BackColor = Color.FromArgb(100, 0, 0, 0);
            btnSettings.BackColor = Color.FromArgb(100, 0, 0, 0);
            btnNext.BackColor = Color.FromArgb(100, 0, 0, 0);
           
            // Disables the next button.
            btnNext.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        { // Closes the application
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {// Minimizes the form
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {// Handles the event when the "Onayla" button is clicked
            btnNext.Enabled = true;
            // Creates a new `Q_A` object.
            var soruCevap = new Q_A();
            // Gets the answers from the question object.
            var sorununCevapları = soruCevap.SorununCevabı();
            // Gets the answer from the text box.
            var verilenCevap = txtCevap.Text;
            // Checks if the answer is correct.
            bool cevapDogrumu = false;
            string dogruCevaplar = "";
            foreach (var cevap in sorununCevapları)
            {
                if (cevap.Trim() == verilenCevap)
                    cevapDogrumu = true;
            }
            // If the answer is correct,
            if (cevapDogrumu)
            {
                // Sets the foreground color of the word label to green.
                lblKelime.ForeColor = System.Drawing.ColorTranslator.FromHtml("#40ff00");
                // Sets the text of the word label to "Your answer is correct".
                lblKelime.Text = "Your answer is correct";
                // Increments the value of the "Doğru" label.
                lblCorrect.Text = (Convert.ToInt32(lblCorrect.Text) + 1).ToString();
                // Disables the "Onayla" button.
                btnOnayla.Enabled = false;
                // Clears the text box.
                txtCevap.Clear();
            }
            // If the answer is incorrect,
            else
            {
                // Iterates through the answers.
                foreach (var cevap in sorununCevapları)
                {
                    // Appends the answer to a string.
                    dogruCevaplar += cevap + ", ";
                }
                // Removes the last comma from the string.
                dogruCevaplar = dogruCevaplar.Substring(0, dogruCevaplar.Length - 2);
                // Increments the value of the "Yanlış" label.
                lblWrong.Text = (Convert.ToInt32(lblWrong.Text) + 1).ToString();
                // Sets the text of the text box to "Your answer is wrong, The correct answers are " + dogruCevaplar.
                txtCevap.Text = "Your answer is wrong, The correct answers are " + dogruCevaplar;
                // Sets the foreground color of the text box to red.
                txtCevap.ForeColor = Color.Red;
                // Disables the "Onayla" button.
                btnOnayla.Enabled = false;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {// Handles the event when the "Next" button is clicked
            // Creates a new `Q_A` object.
            Q_A soruCevap = new Q_A();
            // Selects a question from the question object.
            soruCevap.SoruyuSec();
            // Gets the question in the language specified in the `FileContent` property.
            string soru;
            if (FileContent.SoruDili == "Türkçe")
                soru = soruCevap.TurkceSoru();
            else if (FileContent.SoruDili == "İngilizce")
                soru = soruCevap.IngilizceSoru();
            else soru = soruCevap.KarisikSoru();
            // Sets the text of the word label to the question.
            lblKelime.Text = soru;

            // Clears the text box.
            txtCevap.Clear();
            // Enables the "Onayla" button.
            btnOnayla.Enabled = true;
            // Sets the foreground color of the text box to black.
            txtCevap.ForeColor = Color.Black;
            // Sets the foreground color of the word label to white.
            lblKelime.ForeColor = Color.White;
            // Disables the "Next" button.
            btnNext.Enabled = false;
            txtCevap.Focus();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {// Opens the "AddWord" form when the "Settings" button is clicked
            // Creates a new `AddWord` form object.
            AddWord kelimeEklemeForm = new AddWord();
            // Displays the form modally.
            kelimeEklemeForm.ShowDialog();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
