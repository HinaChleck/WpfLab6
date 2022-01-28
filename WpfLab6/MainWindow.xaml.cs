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


namespace WpfLab6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>



    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WeatherControl wheather = new WeatherControl(-20, "west", 6, Precip.Sunny);
            textBox.Text =$"Температура: { wheather.Temp} градусов Цельсия \nНаправление ветра: { wheather.WindDir} \nСкорость ветра: { wheather.WindSpeed} м/с\nОсадки: { wheather.Precipitation}";

        }
       
    }
}
