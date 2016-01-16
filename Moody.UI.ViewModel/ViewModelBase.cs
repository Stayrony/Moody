// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="">
//   
// </copyright>
// <summary>
//   The view model base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.UI.ViewModel
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows;

    /// <summary>
    ///     The view model base.
    /// </summary>
    public abstract class ViewModelBase : DependencyObject, INotifyPropertyChanged, IDisposable
    {
        #region DisplayName

        /// <summary>
        ///     Returns the user-friendly name of this object.
        ///     Child classes can set this property to a new value,
        ///     or override it to determine the value on-demand.
        /// </summary>
        public virtual string DisplayName { get; protected set; }

        #endregion DisplayName

        #region Debugging Aides

        /// <summary>
        /// Warns the developer if this object does not have
        ///     a public property with the specified name. This
        ///     method does not exist in a Release build.
        /// </summary>
        /// <param name="propertyName">
        /// The property Name.
        /// </param>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real,  
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                var msg = "Invalid property name: " + propertyName;

                if (this.ThrowOnInvalidPropertyName)
                {
                    throw new Exception(msg);
                }

                Debug.Fail(msg);
            }
        }

        /// <summary>
        ///     Returns whether an exception is thrown, or if a Debug.Fail() is used
        ///     when an invalid property name is passed to the VerifyPropertyName method.
        ///     The default value is false, but subclasses used by unit tests might
        ///     override this property's getter to return true.
        /// </summary>
        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

        #endregion Debugging Aides

        #region INotifyPropertyChanged Members

        /// <summary>
        ///     Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">
        /// The property that has a new value.
        /// </param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);

            var handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion INotifyPropertyChanged Members

        #region IDisposable Members

        /// <summary>
        ///     Invoked when this object is being removed from the application
        ///     and will be subject to garbage collection.
        /// </summary>
        public void Dispose()
        {
            this.OnDispose();
        }

        /// <summary>
        ///     Child classes can override this method to perform
        ///     clean-up logic, such as removing event handlers.
        /// </summary>
        protected virtual void OnDispose()
        {
        }

#if DEBUG

        /// <summary>
        /// Finalizes an instance of the <see cref="ViewModelBase"/> class. 
        ///     Уничтожает экземпляр класса <see cref="ViewModelBase"/>.
        ///     Useful for ensuring that ViewModel objects are properly garbage collected.
        /// </summary>
        ~ViewModelBase()
        {
            var msg = string.Format(
                "{0} ({1}) ({2}) Finalized",
                this.GetType().Name,
                this.DisplayName,
                this.GetHashCode());
            Debug.WriteLine(msg);
        }

#endif

        #endregion IDisposable Members
    }
}