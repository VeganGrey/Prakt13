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
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Threading;
using System.Windows.Diagnostics;
using LibMas;

namespace Prakt13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private DispatcherTimer timer;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(this.Timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.IsEnabled = true;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            matrrazm.Text = $"{matr.GetLength(0)+1}x{matr.GetLength(1)+1}";
            indx.Text = $"";
            DateTime now = DateTime.Now;
            time.Text = now.ToString("HH:mm:ss");
            data.Text = now.ToString("dd.MM.yyyy");
        }

        double[] matr;

        private void Spavka(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Калитин С.А. ИСП-31 Вариант 13\nДаны координаты трех вершин треугольника: (x1, y1), (x2, y2), (x3, y3). Найти его " +
                "периметр и площадь, используя окнолу для расстояния между двумя точками на" +
                "плоскости (см. задание 12). Для нахождения площади треугольника со сторонами a,b, c использовать окнолу Герона\n" +
                "Дано трехзначное число. Найти сумму и произведение его цифр.");
        }

        private void Support(object sender, RoutedEventArgs e)
        {
            string target = "https://t.me/Username1_1";
            System.Diagnostics.Process.Start(target);
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Clear_Click(object sender,RoutedEventArgs e)
        {
            rezu = null;nachl = null;
        }
    }
}
