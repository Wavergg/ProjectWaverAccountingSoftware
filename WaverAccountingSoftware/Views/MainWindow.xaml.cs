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

namespace WaverAccountingSoftware.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window _loginPage;
        bool _isClosedByButtonPress = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(Window loginPage)
        {
            _loginPage = loginPage;
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!_isClosedByButtonPress)
            { 
                CloseNicely();
            }
        }

        private void _ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            CloseNicely();
        }

        private void CloseNicely()
        {
            Application.Current.Shutdown();
        }

        private void _ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void _ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            if (_loginPage == null) return;
            _loginPage.Visibility = Visibility.Visible;
            _isClosedByButtonPress = true;
            this.Close();
        }
    }
}
