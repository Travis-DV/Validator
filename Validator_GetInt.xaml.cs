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
using System.Windows.Shapes;

namespace Validator
{
    /// <summary>
    /// Interaction logic for Validator_GetInt.xaml
    /// </summary>
    public partial class Validator_GetInt : Window
    {

        public int Output;
        private int Min;
        private int Max;

        public Validator_GetInt(string message, int Min=0, int Max = 0)
        {
            InitializeComponent();
            string Message = $"{message}";
            if (Max > 0)
            {
                Message += $"({Min}-{Max})";
            }
            else
            {
                Message += $"(>{Min})";
            }

            LB_Input.Content = Message;

            this.Min = Min;
            this.Max = Max;

            this.Focus();
        }

        private void NUMBERSONLY(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void OkClicked(object sender, RoutedEventArgs e)
        {
            
            Tuple<bool, int> output = Validator.CheckInt(this.TB_Input.Text, Min: Min, Max: Max);
            
            if (output.Item1)
            {
                Output = output.Item2;
                this.Close();
            }
        }
    }
}
