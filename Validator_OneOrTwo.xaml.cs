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
using System.Windows.Shapes;

namespace Validator
{
    /// <summary>
    /// Interaction logic for Validator_OneOrTwo.xaml
    /// </summary>
    public partial class Validator_OneOrTwo : Window
    {

        public int Output = -1;

        public Validator_OneOrTwo(string message1, string message2, string message3 = "")
        {
            InitializeComponent();
            if (message3 == "")
            {
                Thickness MSG1_margin = BT_MSG1.Margin;
                MSG1_margin.Top = 0;
                BT_MSG1.Margin = MSG1_margin;

                Thickness MSG2_margin = BT_MSG1.Margin;
                MSG2_margin.Top = 0;
                BT_MSG2.Margin = MSG2_margin;
            }
            BT_MSG1.Content = message1;
            BT_MSG2.Content = message2;
            LB_MSG3.Content = message3;
            this.Focus();
        }

        private void MSG1_CLicked(object sender, RoutedEventArgs e)
        {
            Output = 1;
            this.Close();
        }

        private void MSG2_CLicked(object sender, RoutedEventArgs e)
        {
            Output = 2;
            this.Close();
        }

        private void Cancel_CLicked(object sender, RoutedEventArgs e)
        {
            Output = 3;
            this.Close();
        }
    }
}
