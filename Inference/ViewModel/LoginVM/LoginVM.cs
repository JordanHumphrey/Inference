using Inference.Model;
using Inference.View.Commands;
using Inference.ViewModel.Interfaces;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Inference.ViewModel.LoginVM
{
    public class LoginVM
    {
        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        #region Commands

        public LoginCommand LoginCommand { get; set; }
        public RegisterCommand RegisterCommand { get; set; }
        public event EventHandler HasLoggedIn;

        #endregion Commands & EventHandlers

        public LoginVM()
        {
            User = new User();
            LoginCommand = new LoginCommand(this);
            RegisterCommand = new RegisterCommand(this);
        }

        #region Login & Register Account

        public void Register()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                conn.CreateTable<User>();

                var result = DatabaseHelper.Insert(User);

                if(result)
                {
                    App.UserId = user.Id.ToString();
                    HasLoggedIn(this, new EventArgs());
                }
            }
        }

        public void Login(object parameter)
        {
            if (parameter is IHavePassword passwordContainer)
            {
                var secureString = passwordContainer.Password;
                var vmPassword = ConvertToUnsecureString(secureString);

                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
                {
                    conn.CreateTable<User>();

                    var user = conn.Table<User>().Where(u => u.Username == User.Username).FirstOrDefault();

                    if (user == null) { }
                    else if (vmPassword.Contains(user.Password))
                    {
                        App.UserId = user.Id.ToString();                        
                        HasLoggedIn(this, new EventArgs());
                    }
                }
            }
        }

        #endregion Login & Register Account

        #region Password Retrieval

        private string ConvertToUnsecureString(SecureString securePassword)
        {
            if(securePassword == null)
            {
                return string.Empty;
            }

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        #endregion Password Retrieval
    }
}
