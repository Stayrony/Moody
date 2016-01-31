// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The login view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.UI.ViewModel
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Input;

    using Moody.Exception;
    using Moody.Exception.Properties;
    using Moody.Service.BLL;
    using Moody.Service.Contract;
    using Moody.Service.Domain;
    using Moody.UI.Context;
    using Moody.UI.Contract;
    using Moody.UI.Utility;

    /// <summary>
    ///     The login view model.
    /// </summary>
    public class LoginViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        /// <param name="view">
        /// The view.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public LoginViewModel(IView view)
        {
            try
            {
                this.View = view;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        #endregion Constructor

        // , IDataErrorInfo
        #region Fields

        /// <summary>
        ///     The view.
        /// </summary>
        private readonly IView View;

        /// <summary>
        ///     The login info user.
        /// </summary>
        private LoginInfo loginInfoUser;

        /// <summary>
        ///     The login command.
        /// </summary>
        private RelayCommand _loginCommand;

        /// <summary>
        ///     The sign up command.
        /// </summary>
        private RelayCommand _signUpCommand;

        /// <summary>
        ///     The login property.
        /// </summary>
        public static readonly DependencyProperty LoginNameProperty = DependencyProperty.Register(
            "LoginName",
            typeof(string),
            typeof(LoginViewModel),
            new UIPropertyMetadata(null));

        /// <summary>
        ///     The password property.
        /// </summary>
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
            "Password",
            typeof(string),
            typeof(LoginViewModel),
            new UIPropertyMetadata(null));

        #endregion Fields

        #region Presentation Properties

        /// <summary>
        ///     Gets the login command.
        /// </summary>
        public ICommand LoginCommand
        {
            get
            {
                if (this._loginCommand == null)
                {
                    this._loginCommand = new RelayCommand(param => this.Login(), param => this.CanLogin);
                }

                return this._loginCommand;
            }
        }

        /// <summary>
        ///     Gets the sign up command.
        /// </summary>
        public ICommand SignUpCommand
        {
            get
            {
                if (this._signUpCommand == null)
                {
                    this._signUpCommand = new RelayCommand(param => this.SignUp(), param => this.CanSignUp);
                }

                return this._signUpCommand;
            }
        }

        #endregion Presentation Properties

        #region Private Helpers

        /// <summary>
        ///     Returns true if the user is valid and can be login.
        /// </summary>
        private bool CanLogin
        {
            get
            {
                return this.IsValid;
            }
        }

        /// <summary>
        /// Gets a value indicating whether can sign up.
        /// </summary>
        private bool CanSignUp
        {
            get
            {
                return true;
            }
        }

        #endregion Private Helpers

        #region Public Method

        /// <summary>
        ///     The login.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        public void Login()
        {
            try
            {
                // IFrontServiceClient coreServiceClient =
                // ServiceManager.GetInstance().GetManager("FrontService") as IFrontServiceClient;
                // MemberInfo user = coreServiceClient.SystemEnter(this.Login, this.Password);
                // ApplicationContext.GetInstance().AddValue("user", user);
                // ControlManager.GetInstance().Place("MainWindow", "mainRegion", "DashboardControl");
                ServiceManager.GetInstance().AddManager("UserManager", typeof(UserManager));

                var coreServiceClient = ServiceManager.GetInstance().GetManager("UserManager") as IFrontServiceClient;

                this.loginInfoUser = new LoginInfo { Password = this.Password, LoginName = this.LoginName };

                // User user = coreServiceClient.EnterTheSystem(this.loginInfoUser);
                var um = new UserManager();
                var user = um.EnterTheSystem(this.loginInfoUser);

                // ApplicationContext.GetInstance().AddValue("user", user);
                ControlManager.GetInstance().Place("MainWindow", "mainRegion", "DashboardControl");
                ControlManager.GetInstance().Place("DashboardControl", "mainRegion", "HomepageControl");
            }
            catch (ExceptionBase exception)
            {
                var message = exception.GetMessage();
                this.View.ShowError(message);
            }
        }

        /// <summary>
        ///     The sign up.
        /// </summary>
        public void SignUp()
        {
            try
            {
                ControlManager.GetInstance().Place("MainWindow", "mainRegion", "RegisterControl");
            }
            catch (ExceptionBase exception)
            {
                var message = exception.GetMessage();
                this.View.ShowError(message);
            }
        }

        #endregion Public Method

        #region User Properties

        /// <summary>
        ///     Gets or sets the login name.
        /// </summary>
        public string LoginName
        {
            get
            {
                return (string)this.GetValue(LoginNameProperty);
            }

            set
            {
                this.SetValue(LoginNameProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        public string Password
        {
            get
            {
                return (string)this.GetValue(PasswordProperty);
            }

            set
            {
                this.SetValue(PasswordProperty, value);
            }
        }

        #endregion User Properties

        #region Validation

        /// <summary>
        ///     Returns true if this object has no validation errors.
        /// </summary>
        public bool IsValid
        {
            get
            {
                foreach (var property in ValidatedProperties)
                {
                    if (this.GetValidationError(property) != null)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        /// <summary>
        ///     The validated properties.
        /// </summary>
        private static readonly string[] ValidatedProperties = { "LoginName", "Password" };

        /// <summary>
        /// The get validation error.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetValidationError(string propertyName)
        {
            if (Array.IndexOf(ValidatedProperties, propertyName) < 0)
            {
                return null;
            }

            string error = null;

            switch (propertyName)
            {
                case "LoginName":
                    error = this.ValidateLoginName();
                    break;
                case "Password":
                    error = this.ValidatePassword();
                    break;
                default:
                    Debug.Fail("Unexpected property being validated on User: " + propertyName);
                    break;
            }

            return error;
        }

        /// <summary>
        ///     The validate password.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        private string ValidatePassword()
        {
            if (IsStringMissing(this.Password))
            {
                return Error.User_Error_Missing_Password;
            }

            return null;
        }

        /// <summary>
        ///     The validate login name.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        private string ValidateLoginName()
        {
            if (IsStringMissing(this.LoginName))
            {
                return Error.User_Error_Missing_LoginName;
            }

            return null;
        }

        /// <summary>
        /// The is string missing.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsStringMissing(string value)
        {
            return string.IsNullOrEmpty(value) || value.Trim() == string.Empty;
        }

        #endregion Validation

        #region IDataErrorInfo Members


        /// <summary>
        ///     Gets the error.
        /// </summary>
        string IDataErrorInfo.Error
        {
            get
            {
                return null;
                //  (this.loginInfoUser as IDataErrorInfo).Error;
            }
        }

        /// <summary>
        /// The i data error info.this.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                string error = this.GetValidationError(propertyName);
                return error;
            }
        }

        #endregion IDataErrorInfo Members
    }
}