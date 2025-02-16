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

namespace CustomTokenTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string[] levels = new string[6] { "0", "1", "2", "3", "4", "5" };
        TokenHolder tokenHolder = new TokenHolder(1000, true);

        public static System.Timers.Timer aTimer1;

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
            dataGrid1.ItemsSource = tokenHolder.tokens;
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
                tokenHolder.GenerateToken(Guid.Parse(txbUserId.Text), cmbLevel.SelectedIndex, txbUserName.Text);
                dataGrid1.Items.Refresh();
            }
            catch (Exception ex)
            {


            }
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid1.SelectedIndex>=0)
            {
                tbxVerification.Text = dataGrid1.Items[dataGrid1.SelectedIndex].ToString().Split(";")[0];
            }
        }
    }
}