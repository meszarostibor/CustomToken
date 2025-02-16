using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System;

namespace CustomTokenTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string[] levels = new string[6] { "0", "1", "2", "3", "4", "5" };
        string[] expirationTime = new string[] { "20","30","60","600","3600"};
        TokenHolder tokenHolder = new TokenHolder(1000);

        public static System.Timers.Timer aTimer1;
        private object guid;

        public void SetTimer()
        {
            aTimer1 = new System.Timers.Timer(500);
            aTimer1.Elapsed += OnTimed1Event;
            aTimer1.AutoReset = true;
            aTimer1.Enabled = true;
        }

        public void OnTimed1Event(Object source, ElapsedEventArgs e)
        {

            Application.Current.Dispatcher.Invoke(() =>
            {
                // tokenHolder.DecValidityPeriod();
                dataGrid1.Items.Refresh();
            });

        }

        public MainWindow()
        {
            InitializeComponent();
            cmbLevel.ItemsSource = levels;
            cmbLevel.SelectedIndex = 2;
            cmbExpirationTime.ItemsSource = expirationTime;
            cmbExpirationTime.SelectedIndex = 3;
            txbUserName.Text = "Bármi Áron";
            txbUserId.Text = Guid.NewGuid().ToString();
            dataGrid1.ItemsSource = tokenHolder.tokens;
            txbVerification.Text = "Click on an item in the list";
            SetTimer();
            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Guid guid = Guid.NewGuid();
            txbUserId.Text = guid.ToString();
        }

        private void btnGenerateToken_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tokenHolder.GenerateToken(Guid.Parse(txbUserId.Text), int.Parse(cmbLevel.Text), txbUserName.Text, int.Parse(cmbExpirationTime.Text));
                dataGrid1.Items.Refresh();
            }
            catch 
            {


            }
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid1.SelectedIndex>=0)
            {
                txbVerification.Text = dataGrid1.Items[dataGrid1.SelectedIndex].ToString().Split(";")[0];
                tbxTokenValidity.Clear();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //aTimer1.Stop();
            aTimer1.Close();
        }

        private void btnVerification_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tbxTokenValidity.Clear();
                CustomToken t = tokenHolder.CheckTokenValidity(Guid.Parse(txbVerification.Text));
                if (t.Level < 0)
                {
                    tbxTokenValidity.Text = "Invalid token!";
                }
                else
                {
                    tbxTokenValidity.Text = "Level: " + t.Level.ToString();
                    tbxTokenValidity.Text += $"\nId: {t.UserId}";
                    tbxTokenValidity.Text += $"\nUserName: {t.UserName}";

                }
            }
            catch 
            {
                tbxTokenValidity.Text = "Wrong input data!";
            }
        }


    }
}