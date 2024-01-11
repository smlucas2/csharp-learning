using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Calculator
{
    public partial class Window1 : Window, INotifyPropertyChanged
    {
        private CalculatorEngine calculator;

        public event PropertyChangedEventHandler? PropertyChanged;

        private string _someText;
        public string SomeText
        {
            get { return _someText; }
            set
            {
                if (string.Equals(value, _someText))
                    return;
                _someText = value;
                OnPropertyChanged("SomeText");
            }
        }

        public Window1()
        {
            InitializeComponent();
            calculator = new CalculatorEngine();
        }

        private void One_Button_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.Input("1");
        }

        private void Two_Button_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.Input("2");
        }

        private void Three_Button_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.Input("3");
        }

        private void Four_Button_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.Input("4");
        }

        private void Five_Button_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.Input("5");
        }

        private void Six_Button_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.Input("6");
        }

        private void Seven_Button_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.Input("7");
        }

        private void Eight_Button_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.Input("8");
        }

        private void Nine_Button_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.Input("9");
        }

        private void Zero_Button_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.Input("0");
        }

        private void Dot_Button_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.Input(".");
        }

        private void Equals_Button_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.Input("EQ");
        }

        private void Plus_Button_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.Input("ADD");
        }

        private void Minus_Button_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.Input("SUB");
        }

        private void Mult_Button_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.Input("MUL");
        }

        private void Divide_Button_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.Input("DIV");
        }

        private void PM_Button_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.Input("PM");
        }

        private void C_Button_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.Input("C");
        }

        private void CE_Button_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.Input("CE");
        }

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
