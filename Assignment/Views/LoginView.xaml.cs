using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Assignment.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {

        //register LoginCommandProperty to LoginView since PasswordBox doens't expose DependencyProperty 
        public static readonly DependencyProperty LoginCommandProperty =
            DependencyProperty.Register("LoginCommand", typeof(ICommand), typeof(LoginView), new PropertyMetadata(null));


        public ICommand LoginCommand
        {
            get { return (ICommand)GetValue(LoginCommandProperty); }
            // SetValue is method in ContentControl and UserControl is derieved from ContentControl
            // the value is from LoginViewModel
            set { SetValue(LoginCommandProperty, value); }
        }
        public LoginView()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (LoginCommand != null)
            {
                // pbPassword is a property of LoginView
                // LoginCommand.Execute will execute command that bind in the LoginViewModel which is LoginCommand
                string password = pbPassword.Password;
                LoginCommand.Execute(password);
            }
        }
    }
}
