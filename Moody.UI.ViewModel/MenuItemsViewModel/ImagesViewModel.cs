// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImagesViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The images view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.UI.ViewModel.MenuItemsViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;

    using Moody.Service.BLL;
    using Moody.Service.Domain;
    using Moody.UI.Contract;

    /// <summary>
    ///     The images view model.
    /// </summary>
    public class ImagesViewModel : ViewModelBase
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ImagesViewModel"/> class.
        /// </summary>
        /// <param name="view">
        /// The view.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public ImagesViewModel(IView view)
        {
            try
            {
                this.View = view;
                this._imageList = this.GetImages();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        #endregion Constructor

        #region Image Properties

        /// <summary>
        ///     Gets or sets the tags.
        /// </summary>
        public string Tags
        {
            get
            {
                return (string)this.GetValue(ImagesTagsProperty);
            }

            set
            {
                this.SetValue(ImagesTagsProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        public string ImagePath
        {
            get
            {
                return (string)this.GetValue(ImagePathProperty);
            }

            set
            {
                this.SetValue(ImagePathProperty, value);
            }
        }

        #endregion Image Properties

        #region Fields

        /// <summary>
        ///     The view.
        /// </summary>
        private readonly IView View;

        /// <summary>
        ///     The images tags property.
        /// </summary>
        public static readonly DependencyProperty ImagesTagsProperty = DependencyProperty.Register(
            "Tags",
            typeof(string),
            typeof(ImagesViewModel),
            new UIPropertyMetadata(null));

        /// <summary>
        /// The image path property.
        /// </summary>
        public static readonly DependencyProperty ImagePathProperty = DependencyProperty.Register(
            "ImagePath",
            typeof(string),
            typeof(ImagesViewModel),
            new UIPropertyMetadata(null));

        /// <summary>
        /// The image manager.
        /// </summary>
        private readonly ImageManager imageManager = new ImageManager();

        /// <summary>
        ///     The _images list.
        /// </summary>
        private ObservableCollection<Image> _imageList = new ObservableCollection<Image>();
        #endregion Fields

        /// <summary>
        ///     Gets the images list.
        /// </summary>
        public ObservableCollection<Image> ImagesList
        {
            get
            {
                return this._imageList;
            }
        }

        /// <summary>
        /// The get images.
        /// </summary>
        /// <returns>
        /// The <see cref="ObservableCollection"/>.
        /// </returns>
        private ObservableCollection<Image> GetImages()
        {
            var images = this.imageManager.GetAllImages();
            ObservableCollection<Image> imageCollection = new ObservableCollection<Image>(images);
            return imageCollection;
        }
    }
}