﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.0
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moody.Exception.Properties {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
   public class Error {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Error() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Moody.Exception.Properties.Error", typeof(Error).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }

        /// <summary>
        ///   Ищет локализованную строку, похожую на Cannot login an invalid user..
        /// </summary>
        public static string LoginViewModel_Exception_CannotLogin {
            get {
                return ResourceManager.GetString("LoginViewModel_Exception_CannotLogin", resourceCulture);
            }
        }

        /// <summary>
        ///   Ищет локализованную строку, похожую на Blank characters are not allowed in Password..
        /// </summary>
        public static string User_Error_Blank_Characters_In_Password {
            get {
                return ResourceManager.GetString("User_Error_Blank_Characters_In_Password", resourceCulture);
            }
        }

        /// <summary>
        ///   Ищет локализованную строку, похожую на Blank characters are not allowed in Username..
        /// </summary>
        public static string User_Error_Blank_Characters_In_LoginName {
            get {
                return ResourceManager.GetString("User_Error_Blank_Characters_In_LoginName", resourceCulture);
            }
        }

        /// <summary>
        ///   Ищет локализованную строку, похожую на Password does not match the confirm password..
        /// </summary>
        public static string User_Error_ConfirmPassword {
            get {
                return ResourceManager.GetString("User_Error_ConfirmPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The Email must contains a valid email address..
        /// </summary>
        public static string User_Error_Invalid_Email_Address {
            get {
                return ResourceManager.GetString("User_Error_Invalid_Email_Address", resourceCulture);
            }
        }

        /// <summary>
        ///   Ищет локализованную строку, похожую на Please enter a ConfirmPassword..
        /// </summary>
        public static string User_Error_Missing_ConfirmPassword {
            get {
                return ResourceManager.GetString("User_Error_Missing_ConfirmPassword", resourceCulture);
            }
        }

        /// <summary>
        ///   Ищет локализованную строку, похожую на Please enter an Email..
        /// </summary>
        public static string User_Error_Missing_Email {
            get {
                return ResourceManager.GetString("User_Error_Missing_Email", resourceCulture);
            }
        }

        /// <summary>
        ///   Ищет локализованную строку, похожую на Login Name is missing.
        /// </summary>
        public static string User_Error_Missing_LoginName {
            get {
                return ResourceManager.GetString("User_Error_Missing_LoginName", resourceCulture);
            }
        }

        /// <summary>
        ///   Ищет локализованную строку, похожую на Please enter a Password..
        /// </summary>
        public static string User_Error_Missing_Password {
            get {
                return ResourceManager.GetString("User_Error_Missing_Password", resourceCulture);
            }
        }

        /// <summary>
        ///   Ищет локализованную строку, похожую на Please enter a Username..
        /// </summary>
        public static string User_Error_Missing_Username {
            get {
                return ResourceManager.GetString("User_Error_Missing_Username", resourceCulture);
            }
        }

        /// <summary>
        ///   Ищет локализованную строку, похожую на Password must contains minimum 8 characters at least 1 Uppercase Alphabet, 1 Lowercase Alphabet, 1 Number and 1 Special Character..
        /// </summary>
        public static string User_Error_Password_Policy {
            get {
                return ResourceManager.GetString("User_Error_Password_Policy", resourceCulture);
            }
        }
    }
}
