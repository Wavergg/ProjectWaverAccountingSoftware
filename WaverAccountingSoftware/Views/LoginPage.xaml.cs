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
using WaverAccountingSoftware.Controllers;
using WaverAccountingSoftware.Data;
using WaverAccountingSoftware.Models;

namespace WaverAccountingSoftware.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        const string USERNAME_TEXTBOX_PLACEHOLDER = "e.g Waver";
        const string PASSWORD_TEXTBOX_PLACEHOLDER = "Password";

        public LoginPage()
        {
            InitializeComponent();
            _TextBoxUsername.Text = USERNAME_TEXTBOX_PLACEHOLDER;
            _TextBoxPassword.Text = PASSWORD_TEXTBOX_PLACEHOLDER;
        }

        private void _TextBoxUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            if(_TextBoxUsername.Text == USERNAME_TEXTBOX_PLACEHOLDER)
            {
                _TextBoxUsername.Text = "";
            }
        }

        private void _TextBoxUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_TextBoxUsername.Text == "")
            {
                _TextBoxUsername.Text = USERNAME_TEXTBOX_PLACEHOLDER;
            }
        }


        private void _TextBoxPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if(_TextBoxPassword.Text == "")
            {
                _TextBoxPassword.Text = PASSWORD_TEXTBOX_PLACEHOLDER;
            }
        }

        private void _TextBoxPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if(_TextBoxPassword.Text == PASSWORD_TEXTBOX_PLACEHOLDER)
            {
                _TextBoxPassword.Text = "";
            }
            KeyDown += LoginPage_KeyDown;
        }

        private void LoginPage_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                _ButtonSignIn_Click(sender, e);
            }
        }

        private void _ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            CloseNicely();
        }

        private void _ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (_TextBoxUsername.Text == USERNAME_TEXTBOX_PLACEHOLDER || _TextBoxPassword.Text == PASSWORD_TEXTBOX_PLACEHOLDER) {
                MessageBox.Show("Enter USERNAME and PASSWORD");
                return;
            }

            bool result = LoginController.LoginCheck(_TextBoxUsername.Text, _TextBoxPassword.Text);

            if(!result)
            {
                MessageBox.Show("Invalid Username or Password");
            } else
            {
                MainWindow mainPage = new MainWindow(this);
                mainPage.Show();
                this.Visibility = Visibility.Collapsed;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CloseNicely();
        }

        public void CloseNicely()
        {
            Application.Current.Shutdown();
        }
    }
}
