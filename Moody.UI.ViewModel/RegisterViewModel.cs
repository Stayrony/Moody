// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The register view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;

namespace Moody.UI.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Input;

    using Moody.Exception;
    using Moody.Exception.Properties;
    using Moody.Service.BLL;
    using Moody.Service.Domain;
    using Moody.UI.Context;
    using Moody.UI.Contract;
    using Moody.UI.Utility;

    /// <summary>
    ///     The register view model.
    /// </summary>
    public class RegisterViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterViewModel"/> class.
        /// </summary>
        /// <param name="view">
        /// The view.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public RegisterViewModel(IView view)
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

        #region Fields

        /// <summary>
        ///     The view.
        /// </summary>
        private readonly IView View;

        /// <summary>
        ///     The register info user.
        /// </summary>
        private RegisterInfo registerInfoUser;

        /// <summary>
        ///     The _sign up command.
        /// </summary>
        private RelayCommand _signUpCommand;

        /// <summary>
        ///     The _login command.
        /// </summary>
        private RelayCommand _loginCommand;

        /// <summary>
        ///     The username property.
        /// </summary>
        public static readonly DependencyProperty LoginNameProperty = DependencyProperty.Register(
            "LoginNameReq",
            typeof(string),
            typeof(RegisterViewModel),
            new UIPropertyMetadata(null));

        /// <summary>
        ///     The email property.
        /// </summary>
        public static DependencyProperty EmailProperty = DependencyProperty.Register(
            "Email",
            typeof(string),
            typeof(RegisterViewModel),
            new UIPropertyMetadata(null));

        /// <summary>
        ///     The password property.
        /// </summary>
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
            "PasswordReq",
            typeof(string),
            typeof(RegisterViewModel),
            new UIPropertyMetadata(null));

        /// <summary>
        ///     The confirm password property.
        /// </summary>
        public static readonly DependencyProperty ConfirmPasswordProperty =
            DependencyProperty.Register(
                "ConfirmPassword",
                typeof(string),
                typeof(RegisterViewModel),
                new PropertyMetadata(null));

        #endregion Fields

        #region Presentation Properties

        /// <summary>
        ///     Gets the sign up command.
        /// </summary>
        public ICommand SignUpCommandReg
        {
            get
            {
                if (this._signUpCommand == null)
                {
                    this._signUpCommand = new RelayCommand(param => this.SignUpReg(), param => this.CanSignUpReg);
                }

                return this._signUpCommand;
            }
        }

        /// <summary>
        ///     Gets the login command.
        /// </summary>
        public ICommand LoginCommandReg
        {
            get
            {
                if (this._loginCommand == null)
                {
                    this._loginCommand = new RelayCommand(param => this.LoginReg(), param => this.CanLoginReg);
                }

                return this._loginCommand;
            }
        }

        #endregion Presentation Properties

        #region Private Helpers

        /// <summary>
        ///     Gets a value indicating whether can sign up.
        /// </summary>
        private bool CanSignUpReg
        {
            get
            {
                return this.IsValid;
            }
        }

        /// <summary>
        ///     Gets a value indicating whether can login.
        /// </summary>
        private bool CanLoginReg
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
        public void LoginReg()
        {
            try
            {
                ControlManager.GetInstance().Place("MainWindow", "mainRegion", "LoginControl");
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
        public void SignUpReg()
        {
            try
            {
                this.registerInfoUser = new RegisterInfo
                {
                    LoginName = this.LoginNameReg,
                    Email = this.Email,
                    Password = this.PasswordReg
                };

                //TODO 
                UserManager userManager = new UserManager();
                userManager.CreateUser(this.registerInfoUser);

                ControlManager.GetInstance().Place("MainWindow", "mainRegion", "DashboardControl");

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
        /// Gets or sets the login name.
        /// </summary>
        public string LoginNameReg
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
        ///     Gets or sets the email.
        /// </summary>
        public string Email
        {
            get
            {
                return (string)this.GetValue(EmailProperty);
            }

            set
            {
                this.SetValue(EmailProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        public string PasswordReg
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

        /// <summary>
        ///     Gets or sets the confirm password.
        /// </summary>
        public string ConfirmPassword
        {
            get
            {
                return (string)this.GetValue(ConfirmPasswordProperty);
            }

            set
            {
                this.SetValue(ConfirmPasswordProperty, value);
            }
        }

        #endregion User Properties

        #region Validation

        /// <summary>
        ///     Gets a value indicating whether is valid.
        /// </summary>
        public bool IsValid
        {
            get
            {
                foreach (var property in this.ValidatedProperties)
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
        private readonly List<string> ValidatedProperties = new List<string>
                                                                {
                                                                    "LoginNameReg",
                                                                    "Email",
                                                                    "PasswordReg",
                                                                    "ConfirmPassword"
                                                                };

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
            string error = null;
            switch (propertyName)
            {
                case "LoginNameReg":
                    error = this.ValidateLoginName();
                    break;
                case "Email":
                    error = this.ValidateEmail();
                    break;
                case "PasswordReg":
                    error = this.ValidatePassword();
                    break;
                case "ConfirmPassword":
                    error = this.ValidateConfirmPassword();
                    break;
                default:
                    Debug.Fail("Unexpected property being validated on User: " + propertyName);
                    break;
            }

            return error;
        }

        /// <summary>
        ///     The validate username.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        private string ValidateLoginName()
        {
            string error = null;
            if (string.IsNullOrEmpty(this.LoginNameReg))
            {
                return Error.User_Error_Missing_LoginName;
            }

            if (this.LoginNameReg.Contains(" "))
            {
                return Error.User_Error_Blank_Characters_In_LoginName;
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
            string error = null;

            if (string.IsNullOrEmpty(this.PasswordReg))
            {
                return Error.User_Error_Missing_Password;
            }

            // Minimum 8 characters at least 1 Uppercase Alphabet, 1 Lowercase Alphabet, 1 Number and 1 Special Character
            var passwordPattern = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}");
            if (!passwordPattern.IsMatch(this.PasswordReg))
            {
                return Error.User_Error_Password_Policy;
            }

            return error;
        }

        /// <summary>
        ///     The validate email.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        private string ValidateEmail()
        {
            string error = null;

            if (string.IsNullOrEmpty(this.Email))
            {
                return Error.User_Error_Missing_Email;
            }

            var mailPattern =
                new Regex(
                    @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            if (!mailPattern.IsMatch(this.Email))
            {
                return Error.User_Error_Invalid_Email_Address;
            }

            return error;
        }

        /// <summary>
        ///     The validate confirm password.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        private string ValidateConfirmPassword()
        {
            // var error = string.Empty;
            string error = null;

            if (string.IsNullOrEmpty(this.ConfirmPassword))
            {
                return Error.User_Error_Missing_ConfirmPassword;
            }

            if (this.PasswordReg != this.ConfirmPassword)
            {
                return Error.User_Error_ConfirmPassword;
            }

            return error;
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