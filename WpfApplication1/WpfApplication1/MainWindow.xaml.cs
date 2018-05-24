using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Meme> list;
        int randomMeme = 0;
        int correctAnswers = 0;
        int totalTries = 0;
        Random rand = new Random();
        public MainWindow()
        {
            InitializeComponent();
            XmlSerializer s = new XmlSerializer(typeof(List<Meme>));
            using (StreamReader sr = new StreamReader("memeBase.xml"))
            {
                list = (s.Deserialize(sr) as List<Meme>);
            }
            randomMeme = rand.Next(0, list.Count);
            string fileName = list[randomMeme].Source;
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"pictures\", fileName);
            BitmapImage bmp = new BitmapImage();
            MessageBox.Show(path);
            bmp.BeginInit();
            bmp.UriSource = new Uri(path);
            bmp.EndInit();
            mainImage.Source = bmp;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Opacity = 0;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button item in pictureCover.Children)
            {
                item.Opacity = 100;
            }
        }

        private void checkAnswer_Click_1(object sender, RoutedEventArgs e)
        {
            string lowercaseAnswer;
            int temp = randomMeme;
            if (AnswerBox.Text != "")
            {
                for (int i = 0; i < list[randomMeme].Answers.Count; i++)
                {

                    lowercaseAnswer = AnswerBox.Text.ToLower();
                    if (list[randomMeme].Answers[i].Contains(lowercaseAnswer))
                    {
                        correctAnswers++;
                        randomMeme = rand.Next(0, list.Count);
                        while (true)
                        {
                            if (randomMeme == temp)
                            {
                                randomMeme = rand.Next(0, list.Count);
                            }
                            else
                            {
                                break;
                            }
                        }
                        string fileName = list[randomMeme].Source;
                        string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"pictures\", fileName);
                        BitmapImage bmp = new BitmapImage();
                        bmp.BeginInit();
                        bmp.UriSource = new Uri(path);
                        bmp.EndInit();
                        mainImage.Source = bmp;
                        foreach (Button item in pictureCover.Children)
                        {
                            item.Opacity = 100;
                        }
                        break;
                    }
                }
                totalTries++;
                AnswerBox.Text = "";
                totalTriesLabel.Content = "Total tries: " + totalTries.ToString();
                correctAnswersLabel.Content = "Correct answers: " + correctAnswers.ToString();
            }
           
        }

        private void ButtonSkip_Click(object sender, RoutedEventArgs e) {

            int temp = randomMeme;

            System.Diagnostics.Process.Start(list[randomMeme].LinkToMeme);

            while (true) {
                if (randomMeme == temp) {
                    randomMeme = rand.Next(0, list.Count);
                }
                else {
                    break;
                }
            }
            string fileName = list[randomMeme].Source;
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"pictures\", fileName);
            BitmapImage bmp = new BitmapImage();
                        bmp.BeginInit();
                        bmp.UriSource = new Uri(path);
                        bmp.EndInit();
                        mainImage.Source = bmp;

                        foreach (Button item in pictureCover.Children) {
                            item.Opacity = 100;
                        }

            totalTries++;
            AnswerBox.Text = "";
                totalTriesLabel.Content = "Total tries: " + totalTries.ToString();
                correctAnswersLabel.Content = "Correct answers: " + correctAnswers.ToString();

            

        }


    }
}
