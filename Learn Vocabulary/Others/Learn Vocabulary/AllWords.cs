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
    public partial class AllWords : Form
    {
        public AllWords()
        {
            InitializeComponent();
            textBox1.TextChanged += textBox1_TextChanged;
        }

        private void AllWords_Load(object sender, EventArgs e)
        {
            LoadAllWords();
        }
        public void LoadAllWords()
        {
            // File path containing all the words
            string fileName = "localdatabase.txt";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // If the file exists, read all lines and add them to the ListBox
                string[] lines = File.ReadAllLines(filePath);
                listBoxKelime.Items.Clear(); // Clear existing items
                listBoxKelime.Items.AddRange(lines);
            }
            else
            {
                // If the file doesn't exist, show a message to the user
                MessageBox.Show("The localdatabase.txt file does not exist.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // File path and name
                string dosyaAdi = "localdatabase.txt";
                string dosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dosyaAdi);

                // Get the text entered by the user in the TextBox
                string arananKelime = textBox1.Text;

                // Clear the existing items of the ListBox
                listBoxKelime.Items.Clear();

                // Check if the file exists
                if (File.Exists(dosyaYolu))
                {
                    // Read the file and add lines similar to the searched word to the ListBox
                    using (StreamReader reader = new StreamReader(dosyaYolu, Encoding.UTF8))
                    {
                        string satir;
                        while ((satir = reader.ReadLine()) != null)
                        {
                            if (satir.Contains(arananKelime))
                            {
                                listBoxKelime.Items.Add(satir);
                            }
                        }
                    }
                }
                else
                {
                    // Show a message to the user if the file doesn't exist
                    MessageBox.Show("The localdatabase.txt file does not exist.");
                }
            }
            catch (Exception ex)
            {
                // Show a message to the user in case of an error
                MessageBox.Show(ex.Message, "Database Operations");
            }
        }
    }
}
