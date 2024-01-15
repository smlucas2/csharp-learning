using System.ComponentModel;
using System.Windows;

namespace Calculator
{
    public partial class Window1 : Window, INotifyPropertyChanged
    {
        private CalculatorEngine calculator;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _someText;
        public string SomeText
        {
            get { return _someText; }
            set
            {
                _someText = value;
                OnPropertyChanged("SomeText");
            }
        }

        public Window1()
        {
            InitializeComponent();
            this.DataContext = this;
            this.calculator = new CalculatorEngine();
        }

        private void One_Button_Click(object sender, RoutedEventArgs e)
        {
            this.SomeText = this.calculator.Input("1");
        }

        private void Two_Button_Click(object sender, RoutedEventArgs e)
        {
            this.SomeText = this.calculator.Input("2");
        }

        private void Three_Button_Click(object sender, RoutedEventArgs e)
        {
            this.SomeText = this.calculator.Input("3");
        }

        private void Four_Button_Click(object sender, RoutedEventArgs e)
        {
            this.SomeText = this.calculator.Input("4");
        }

        private void Five_Button_Click(object sender, RoutedEventArgs e)
        {
            this.SomeText = this.calculator.Input("5");
        }

        private void Six_Button_Click(object sender, RoutedEventArgs e)
        {
            this.SomeText = this.calculator.Input("6");
        }

        private void Seven_Button_Click(object sender, RoutedEventArgs e)
        {
            this.SomeText = this.calculator.Input("7");
        }

        private void Eight_Button_Click(object sender, RoutedEventArgs e)
        {
            this.SomeText = this.calculator.Input("8");
        }

        private void Nine_Button_Click(object sender, RoutedEventArgs e)
        {
            this.SomeText = this.calculator.Input("9");
        }

        private void Zero_Button_Click(object sender, RoutedEventArgs e)
        {
            this.SomeText = this.calculator.Input("0");
        }

        private void Dot_Button_Click(object sender, RoutedEventArgs e)
        {
            this.SomeText = this.calculator.Input(".");
        }

        private void Equals_Button_Click(object sender, RoutedEventArgs e)
        {
            this.SomeText = this.calculator.Input("EQ");
        }

        private void Plus_Button_Click(object sender, RoutedEventArgs e)
        {
            this.SomeText = this.calculator.Input("ADD");
        }

        private void Minus_Button_Click(object sender, RoutedEventArgs e)
        {
            this.SomeText = this.calculator.Input("SUB");
        }

        private void Mult_Button_Click(object sender, RoutedEventArgs e)
        {
            this.SomeText = this.calculator.Input("MUL");
        }

        private void Divide_Button_Click(object sender, RoutedEventArgs e)
        {
            this.SomeText = this.calculator.Input("DIV");
        }

        private void PM_Button_Click(object sender, RoutedEventArgs e)
        {
            this.SomeText = this.calculator.Input("PM");
        }

        private void C_Button_Click(object sender, RoutedEventArgs e)
        {
            this.SomeText = this.calculator.Input("C");
        }

        private void CE_Button_Click(object sender, RoutedEventArgs e)
        {
            this.SomeText = this.calculator.Input("CE");
        }
    }
}
