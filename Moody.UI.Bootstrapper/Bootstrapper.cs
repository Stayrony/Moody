// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company="">
//   
// </copyright>
// <summary>
//   The boot initializer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Moody.UI.Bootstrapper
{
    using Moody.UI.Context;
    using Moody.UI.Control;

    /// <summary>
    ///     The boot initializer.
    /// </summary>
    public class Bootstrapper
    {
        /// <summary>
        /// The bootstrapper.
        /// </summary>
        protected static Bootstrapper bootstrapper;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Bootstrapper" /> class.
        /// </summary>
        protected Bootstrapper()
        {
            this.Init();
        }

        /// <summary>
        ///     The get instance.
        /// </summary>
        /// <returns>
        ///     The <see cref="Bootstrapper" />.
        /// </returns>
        public static Bootstrapper GetInstance()
        {
            if (bootstrapper == null)
            {
                bootstrapper = new Bootstrapper();
            }

            return bootstrapper;
        }

        /// <summary>
        /// The init.
        /// </summary>
        public void Init()
        {
            this.InitControls();
            this.InitServices();
        }

        /// <summary>
        /// The init controls.
        /// </summary>
        public void InitControls()
        {
            ControlManager.GetInstance().Add("MainWindow", typeof(MainWindow));
            ControlManager.GetInstance().Add("LoginControl", typeof(LoginControl));
            ControlManager.GetInstance().Add("DashboardControl", typeof(DashboardControl));
        }

        /// <summary>
        /// The init services.
        /// </summary>
        public void InitServices()
        {
        }
    }
}