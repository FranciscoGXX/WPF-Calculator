using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculadoraWPF
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


        /*EVENTOS DE LA INTERFAZ*/
        private void ButtonMinizime_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }


        /*EVENTOS DE LA CALCULADORA*/


        /*Variables NECESARIOS*/

        string value1="0";
        string value2="0";
        string Operator="";



        private void WriteNumbers(string number) {
            if (DisplayCalculator.Text == "0")
            {
                DisplayCalculator.Text = "";
            }

            DisplayCalculator.Text += number;
        }

        private void OnClickNumber(object sender, RoutedEventArgs e)
        {
            var button = ((Button)sender);
            
            string TextButton = (String)button.Content;

            WriteNumbers(TextButton);
        }

        private void HandlerOperator(string Symbol)
        {
            if (DisplayCalculator.Text != "0")
            {
                value1 = DisplayCalculator.Text;
            }


            Operator = Symbol;

            DisplayCalculator.Text = " ";
           
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (DisplayCalculator.Text != " ")
            {
                value2 = DisplayCalculator.Text;
            }


            try
            {
                
                double number1 = double.Parse(value1);

               

                double number2 = double.Parse(value2);
                double result = 0;

                if (Operator == "+")
                {
                    
                    result = number1 + number2;
                }

                if (Operator == "-")
                {
                    result = number1 - number2;
                }

                if (Operator == "x")
                {
                    result = number1 * number2;
                }

                if (Operator == "/")
                {
                    result = number1 / number2;
                }


                if (Operator == "√")
                {
                    number1 = double.Parse(DisplayCalculator.Text);
                    result =  Math.Sqrt(number1);

                }

                if (Operator == "%")
                {

                    result = number1 * number2 / 100;

                }

                if (Operator == "null")
                {
                    return;
                }

                DisplayOperation.Text = $"{value1} {Operator}{value2}";

                if (value1 == "0") {
                    DisplayOperation.Text = $"{Operator}{value2}";
                }

                DisplayCalculator.Text = result.ToString();
            }
            catch (SystemException)
            {
                DisplayCalculator.Text = "Error";
                return;
            }
            
        }

        private void OnOperatorIsUse(object sender, RoutedEventArgs e)
        {
            var OBJOperator = ((Button)sender);
            string Operator = (string)OBJOperator.Content;
            HandlerOperator(Operator);
        }

        private void OnDeleteAll(object sender, RoutedEventArgs e)
        {
            value1 = "0";
            value2 = "0";
            Operator = "null";
            
            DisplayCalculator.Text = "0";
            DisplayOperation.Text = "";
        }

        private void OnDeleteOne(object sender, RoutedEventArgs e)
        {
            char[] toShow = DisplayCalculator.Text.ToCharArray(0, DisplayCalculator.Text.Length - 1);

            DisplayCalculator.Text = "";

            foreach (char number in toShow)
            {
                DisplayCalculator.Text+=number.ToString();
            }
        }
    }
}
