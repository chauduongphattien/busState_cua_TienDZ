using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace busState.viewModel
{
    public class loginViewmodel:viewmodelbase
    {
        private string _userName;
        private SecureString _password;
        private string _errMessage;
        private bool _isViewvisible;

        public string UserName {

            get {
               return  _userName;
            }
            set {

                _userName = value;
               OnPropertyChanged(nameof(UserName));
             }
                    
        }
        public SecureString Password {

            get {
                return _password;
                    
              } set
            {

                _password = value;
                OnPropertyChanged(nameof(Password));
            }


        }
        public string ErrMessage {

            get
            {
                return _errMessage;

            }
            set
            {

                _errMessage = value;
                OnPropertyChanged(nameof(ErrMessage));
            }
        }
        public bool IsViewvisible
        {
            get { return _isViewvisible; }
            set { _isViewvisible = value;
                OnPropertyChanged(nameof(IsViewvisible));

            }
        }


        public ICommand loginCommand { get; }
        public ICommand recoverPassCommand { get; }
        public ICommand showPass { get; }
        public ICommand rememberPass { get; }

        public loginViewmodel() {
            loginCommand = new viewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            recoverPassCommand = new viewModelCommand(p=>excrecoverPassCommand("",""));

        }

        private void excrecoverPassCommand(string userame,string mail)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteLoginCommand(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
