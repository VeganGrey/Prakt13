﻿using System;
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
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.IsEnabled = true;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            time.Text = now.ToString("HH:mm:ss");
            data.Text = now.ToString("dd.MM.yyyy");
            matrrazm.Text = $"{matr.GetLength(0)}x{matr.GetLength(1)}";
            indx.Text = $"{nachl.SelectedIndex+1}";
        }

        double[,] matr = new double[0,0];
        double[,] rematr;
        Swap mas = new Swap();

        private void Spavka(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Калитин С.А. ИСП-31 Вариант 13\nДана вещественная матрица А(M, N). " +
                "Строку, содержащий максимальный элемент, поменять местами со строкой, содержащей минимальный элемент.");
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

        private void Massiv(object sender, RoutedEventArgs e)
        {
            if(Row.Text == "" || Column.Text == "" || Maxrand.Text == "")
            {
                MessageBox.Show("Введите правильные данные");
            }
            else
            {
                Int32.TryParse(Row.Text, out int row); Int32.TryParse(Column.Text, out int column); Int32.TryParse(Maxrand.Text, out int maxrand);
                matr = new double[row, column];
                LibMas.Masssiv.DvDoubleZapol(row, column, maxrand, ref matr);
                nachl.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
                LibMas.Masssiv.clearmatrica(ref rematr);
                rezu.ItemsSource = null;
            }
        }

        private void Rechange(object sender,RoutedEventArgs e)
        {
            rematr = mas.MatrixSwap(matr);
            rezu.ItemsSource = VisualArray.ToDataTable(rematr).DefaultView;
        }
    }
}
