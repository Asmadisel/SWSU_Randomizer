using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;

namespace SWSU_Randomizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        DispatcherTimer timer = new DispatcherTimer();

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            //Установка видимости подсказки
            if(Tg_Btn.IsChecked== true)
            {
                tt_randomizer.Visibility= Visibility.Collapsed;
                tt_history.Visibility= Visibility.Collapsed;
                tt_settings.Visibility= Visibility.Collapsed;
            }
            else
            {
                tt_randomizer.Visibility= Visibility.Visible;
                tt_history.Visibility= Visibility.Visible;
                tt_settings.Visibility= Visibility.Visible;
            }
        }

        private void Nav_LV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void textBox2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }


        //Таймер
        

        private void Start_button_Click(object sender, RoutedEventArgs e)
        {
            string name = Start_button.Content.ToString();
            switch (name)
            {
                case "Старт":
                    if (textBox1.Text == "" && textBox1.Text == null)
                    {
                        MessageBox.Show("Заполните значение в первом поле");
                    }
                    else if (textBox2.Text == "" && textBox2.Text == null)
                    {
                        MessageBox.Show("Заполните значение во втором поле");
                    }
                    else if (int.Parse(textBox1.Text) > int.Parse(textBox2.Text))
                    {
                        MessageBox.Show("Значение первого поля должно быть меньше второго");
                    }
                    else
                    {
                        //меняем текст кнопки
                        Start_button.Content = "Стоп";
                        //Начинаем изменять значение
                        timer.Tick += new EventHandler(timer_Tick);
                        timer.Interval = TimeSpan.FromSeconds(0.3);

                        Random rnd = new Random();
                        timer.Start();

                        
                        //Random rnd = new Random();
                        //int value = rnd.Next(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
                        //TextBlockRandom.Text=($"{value}");

                    }
                    break;
                case "Стоп":
                    {
                       
                        Start_button.Content= "Старт";
                        timer.Stop();
                        MessageBox.Show($"Выбрано число: {TextBlockRandom.Text} ");
                    }
                    break;
            }
           
            

           

        }
        Random rnd = new Random();
        private void timer_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int value = rnd.Next(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
            TextBlockRandom.Text=($"{value}");
        }

        
        public void Roll(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int value = rnd.Next(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
            TextBlockRandom.Text=($"{value}");
            //int increment = 1;
            //increment++;
            //if(increment >= 250)
            //{
            //    timer.Stop();
            //    increment = 0;
            //}
            //TextBlockRandom.Text = $"{rnd.Next(int.Parse(textBox1.Text), int.Parse(textBox2.Text))}";



        }
    }
}
