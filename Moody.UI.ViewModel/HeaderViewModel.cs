namespace Moody.UI.ViewModel
{
    using System;

    using Moody.UI.Contract;

    public class HeaderViewModel
    {

        #region Fields

        private readonly IView View;

        #endregion Fields
        public HeaderViewModel(IView view)
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

    }
}