using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

//Разработать в WPF приложении класс WeatherControl, моделирующий погодную сводку – температуру (целое число в диапазоне от -50 до +50),
//направление ветра(строка), скорость ветра(целое число), наличие осадков(возможные значения: 0 – солнечно, 1 – облачно, 2 – дождь, 3 – снег.
//Можно использовать целочисленное значение, либо создать перечисление enum).
//Свойство «температура» преобразовать в свойство зависимости.
namespace WpfLab6
{
    public enum Precip
    {
        Sunny,
        Cloudy,
        Rain,
        Snow
    };
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TempProperty;
        private string windDir;
        private uint windSpeed;
        public string WindDir
        {
            get
            {
                return windDir;
            }
            set
            {
                if (value == "north" | value == "south" | value == "east" | value == "west")
                {
                    windDir = value; 
                }
                else
                {
                    windDir = null;
                }
            }
        }

        public uint WindSpeed
        {
            get
            {
                return windSpeed;
            }
            set
            {
                windSpeed = value;
            }
        }
        public Precip Precipitation { get; set; } 
        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }

        public WeatherControl(int temp, string windDir, uint windSpeed, Precip precip)
        {
            this.Temp = temp;
            this.WindDir = windDir;
            this.WindSpeed = windSpeed;
            this.Precipitation = precip;
        }

        static WeatherControl()
        {
            TempProperty=DependencyProperty.Register(
                
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure|FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemp)),
                new ValidateValueCallback(ValidateTemp));
        }

        private static bool ValidateTemp(object value)
        {
            int v = (int) value;
            if (v >= -50 && v <= 5)
                return true;
            else
                return false; ;
        }

        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v>=-50 && v<=50)
                return v;
            else
                return 0;
        }
    }
    
}
