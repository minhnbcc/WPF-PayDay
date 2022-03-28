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

namespace PayDay_Minh_Hoang
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
        const decimal work_per_week = 37.25m;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = "The Pay Calculator";
            Window.ResizeMode = ResizeMode.NoResize;
            //this.ResizeMode = ResizeMode.NoResize;
            txtWork.Focus();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtWork.Text = String.Empty;
            txtPay.Text = String.Empty;
            tbOvertime.Text = String.Empty;
            tbAnswer.Text = String.Empty;
            txtWork.Focus();
        }

        private void BtnCal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal hours_work = Convert.ToDecimal(txtWork.Text);
                decimal rate_pay = Convert.ToDecimal(txtPay.Text);
                decimal overtime_hours = hours_work - work_per_week;
                decimal gross_pay = hours_work * rate_pay + rate_pay * 1.5m + overtime_hours;
                decimal net_pay = gross_pay - gross_pay * 0.18m;
                tbOvertime.Text = Convert.ToString(overtime_hours);
                tbAnswer.Text = "Your Gross Pay is " + gross_pay.ToString("c") + "\n" + "Your Net Pay is " + net_pay.ToString("c");
                MessageBox.Show("Your Gross Pay is " + gross_pay.ToString("c") + "\n" + "Your Net Pay is " + net_pay.ToString("c"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
    }
}
