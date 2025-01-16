using WinFormsMVVM.ViewModels;

namespace WinFormsMVVM
{
    public partial class LoginForm : Form
    {
        private readonly LoginViewModel _loginViewModel;
        private object? loginViewModel;

        public LoginForm(LoginViewModel loginViewModel)
        {
            
            InitializeComponent();
            _loginViewModel = loginViewModel;
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
           _loginViewModel.UserName = textBox1.Text;
            _loginViewModel.Password = textBox2.Text;
            _loginViewModel.LoginCommand.Execute(null);
            this.Hide();
        }
    }
}
