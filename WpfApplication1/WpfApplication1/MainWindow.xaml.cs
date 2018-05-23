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
namespace WpfApplication1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public List<Meme> list = new List<Meme>();
        public MainWindow() {
            InitializeComponent();
            Meme m = new Meme();
            m.Source = @"http://i0.kym-cdn.com/entries/icons/original/000/016/546/hidethepainharold.jpg";
            m.Answers.Add("Harold");
            XmlSerializer s = new XmlSerializer(typeof (List<Meme>));
            list.Add(m);
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Admin\Source\Repos\memegame\WpfApplication1\WpfApplication1\memeBase.xml"))
            {
                s.Serialize(sw, list);
            }
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
    }
}
