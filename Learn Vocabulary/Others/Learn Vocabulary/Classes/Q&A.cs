using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelime_Ezberleme.Sınıflar
{
    public class Q_A // This class is used to generate questions and answers.
    {// These variables are used to store the current question and answer.
        private static string _satir;
        private static string _soruTipi;
        private Random _random;

        public Q_A() // This constructor initializes the random number generator.
        {
            _random = new Random();
        }

        public void SoruyuSec() // This method selects a random question from the content.
        {
            _satir = FileContent.Icerik[_random.Next(0, FileContent.Icerik.Count)];
        }

        public string TurkceSoru() // Generates a Turkish question
        {
            var turkceSoru = _satir.Split('-')[1]; // Split the line into two parts, the Turkish question and the English answer.
            turkceSoru = KelimeleriBol(turkceSoru); // Split the Turkish question into words.
            _soruTipi = "Türkçe";  // Set the question type to Turkish.
            return turkceSoru; // Return the Turkish question.
        }

        public string IngilizceSoru()  // Generates an English question
        {
            var ingilizceSoru = _satir.Split('-')[0]; // Split the line into two parts, the Turkish question and the English answer.
            ingilizceSoru = KelimeleriBol(ingilizceSoru); // Split the English question into words.
            _soruTipi = "İngilizce"; // Set the question type to English.
            return ingilizceSoru; // Return the English question.
        }

        // This method generates a mixed question with random language.
        public string KarisikSoru()
        {
            // Select a random number between 0 and 1.
            var randomSayi = _random.Next(0, 2);

            // Split the line into two parts, the Turkish question and the English answer.
            var karisikSoru = _satir.Split('-')[randomSayi];

            // Split the mixed question into words.
            karisikSoru = KelimeleriBol(karisikSoru);

            // If the random number is 0, set the question type to Turkish.
            // Otherwise, set the question type to English.
            if (randomSayi == 0)
                _soruTipi = "İngilizce";
            else _soruTipi = "Türkçe";

            // Return the mixed question.
            return karisikSoru;
        }

        // This method divides the words and selects a random one.
        public string KelimeleriBol(string kelimeler)
        {
            // Split the words into an array.
            var bolunmusKelime = kelimeler.Split(',');

            // Create a variable to store the random word.
            var kelime = "";

            // If the array has more than one word, select a random word.
            // Otherwise, return the first word.
            if (bolunmusKelime.Length > 1)
            {
                kelime = bolunmusKelime[_random.Next(0, 2)];
            }
            else kelime = bolunmusKelime[0];

            // Return the random word.
            return kelime;
        }

        // This method retrieves the correct answer for the question.
        public string[] SorununCevabı()
        {
            // Create a variable to store the answer.
            string cevap = "";

            // If the question type is Turkish, set the answer to the Turkish answer.
            // Otherwise, set the answer to the English answer.
            if (_soruTipi == "Türkçe")
                cevap = _satir.Split('-')[0];
            else cevap = _satir.Split('-')[1];

            // Split the answer into an array.
            return cevap.Split(',');
        }
    }
}
