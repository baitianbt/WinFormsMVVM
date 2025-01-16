using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WinFormsMVVM.Commands;
using WinFormsMVVM.Services;

namespace WinFormsMVVM.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly IUserService _userService;
        public event PropertyChangedEventHandler? PropertyChanged;

        public string UserName { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand { get; }

        public LoginViewModel(IUserService userService)
        {
            _userService = userService;
            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            var user = _userService.GetUserByUserName(UserName);
            if (user != null && user.Password == Password)
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("登录失败");
            }
        }
    }
}
