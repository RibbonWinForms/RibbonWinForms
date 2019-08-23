// *********************************
// Message from Original Author:
//
// 2008 Jose Menendez Poo
// Please give me credit if you use this code. It's all I ask.
// Contact me for more info: menendezpoo@gmail.com
// *********************************
//
// Original project from http://ribbon.codeplex.com/
// Continue to support and maintain by http://officeribbon.codeplex.com/

using System.Diagnostics;
using System.Drawing;

namespace System.Windows.Forms.Classes.Collections
{
    /// <summary>
    /// An extended ImageList Implementation with ability to store two sizes for each Image, small and large.<br/>
    /// <br/>
    /// As an addition, AlphaBlending is enabled by default.<br/>
    /// <br/>
    /// <seealso href="http://dotnetframework.org/default.aspx/DotNET/DotNET/8@0/untmp/whidbey/REDBITS/ndp/fx/src/WinForms/Managed/System/WinForms/ImageList@cs/4/ImageList@cs"/>
    /// <b>- NOTE:</b> Disable JavaScript when viewing files on this site<br/>
    /// </summary>
    public class RibbonMultiSizeImageList
    {
        //= Enums =============================================
        public enum MultiSizeImageListScaleMode
        {
            Simple,
            HighQuality,
        }
        //= Enums =============================================

        protected ImageList SmallImageList = new ImageList();
        protected ImageList LargeImageList = new ImageList();


        public MultiSizeImageListScaleMode ScaleMode { get; set; } = MultiSizeImageListScaleMode.HighQuality;

        public Size SmallImageSize { get { return this.SmallImageList.ImageSize; } }
        public Size LargeImageSize { get { return this.LargeImageList.ImageSize; } }

        /// <summary>
        /// <see cref="RibbonMultiSizeImageList"/> ctor()
        /// <br/>
        /// Initializes internal ImageLists for small and large images.
        /// </summary>
        /// <param name="SmallWidth"></param>
        /// <param name="SmallHeight"></param>
        public RibbonMultiSizeImageList(int SmallWidth = 16, int SmallHeight = 16)        // TODO: IContainer!
        {
            int LargeWidth = SmallWidth * 2;
            int LargeHeight = SmallHeight * 2;

            /// Fix bug with alpha channels by enabling transparency before adding any images to the list.
            /// <seealso href="https://www.codeproject.com/articles/9142/adding-and-using-32-bit-alphablended-images-and-ic"/>
            this.SmallImageList.ColorDepth = this.LargeImageList.ColorDepth = ColorDepth.Depth32Bit;

            this.SmallImageList.ImageSize = new Size(SmallWidth, SmallHeight);
            this.LargeImageList.ImageSize = new Size(LargeWidth, LargeHeight);
        }

        /// <summary>
        /// Add images contained in given ImageStrip to this <see cref="RibbonMultiSizeImageList"/> instance.<br/><br/>
        /// Valid sizes for <paramref name="imageStrip"/> are as follows:<br/>
        /// SmallImageSize.Height: In this case, the large images will be scaled.<br/>
        /// LargeImageSize.Height: In this case, the small images will be scaled.<br/>
        /// </summary>
        /// <param name="imageStrip">An ImageStrip containing the Images that will be added.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when given ImageStrip has invalid size.</exception>
        public int AddStrip(Bitmap imageStrip)
        {
            int imageStripWidth = imageStrip.Width;
            int imageStripHeight = imageStrip.Height;
            int countOfImages;

            // Check height of given ImageStrip to determine the Image Extraction Method
            if (imageStripHeight == this.SmallImageSize.Height)                     // Small Image Extraction path
            {
                if (0 != (imageStripWidth % this.SmallImageSize.Width))
                    throw new RibbonBadImageStripSizeException(Width: imageStripWidth);

                countOfImages = imageStripWidth / this.SmallImageSize.Width;





                return countOfImages;
            }
            else if (imageStripHeight == this.LargeImageSize.Height)                // Large Image Extraction path
            {
                // Large images are given, so create ImageStrip with scaled images
                countOfImages = imageStripWidth / this.LargeImageSize.Width;
                int widthRemainder = imageStripWidth % this.LargeImageSize.Width;


                return countOfImages;
            }

            throw new ArgumentOutOfRangeException(nameof(imageStrip), "Can't extract Images from ImageStrip cause of invalid height.");
        }

        public void AddStrip(Bitmap smallImageStrip, Bitmap largeImageStrip)
        {
            int initialImageCount = this.SmallImageList.Images.Count;

            Debug.Assert(condition: (this.SmallImageList.Images.Count == this.LargeImageList.Images.Count),
                "Invalid state: Count of SmallImageList does not equal count of LargeImageList");

            try
            {
                int smallImagesAdded = this.SmallImageList.Images.AddStrip(smallImageStrip);
                int LargeImagesAdded = this.LargeImageList.Images.AddStrip(largeImageStrip);

                if (smallImagesAdded != LargeImagesAdded)
                    throw new Exception("");

                // TODO: Check smallImagesAdded against LargeImagesAdded; Use TempImageLists to create images from strip, then add them to the existing imagelists
            }
            catch (Exception ex)
            {
                // In case of exception, remove recently added images
                while (this.SmallImageList.Images.Count > initialImageCount)
                    this.SmallImageList.Images.RemoveAt(initialImageCount);
                while (this.LargeImageList.Images.Count > initialImageCount)
                    this.LargeImageList.Images.RemoveAt(initialImageCount);

                throw new Exception("Failed to add ImageStrip to RibbonMultiSizeImageList.", ex);
            }
        }

        // TODO: Simple resize: Bitmap resizedBitmap = new Bitmap(imageList.Images[i], scaledSize);
        // TODO: High Quality resize: https://stackoverflow.com/questions/1922040/how-to-resize-an-image-c-sharp
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class RibbonBadImageStripSizeException
      : Exception
    {
        public int Width { get; }
        public int Height { get; }

        protected RibbonBadImageStripSizeException()
          : base()
        {
        }

        //public RibbonBadImageStripSizeException(Size size, string message)
        //    : base(message)
        //{
        //}
        public RibbonBadImageStripSizeException(string message, int Width = 0, int Height = 0)
          : base(message)
        {
            this.Width = Width;
            this.Height = Height;
        }
        public RibbonBadImageStripSizeException(int Width = 0, int Height = 0)
          : base(message: "Unexpected image strip size")
        {
            this.Width = Width;
            this.Height = Height;
        }
    }

    /*
            /// <summary>
            /// Load image strip from embedded resource and return as new <see cref="ImageList"/>.
            /// </summary>
            /// <param name="control">The control that implements IElThemedControl interface.</param>
            /// <param name="themeName">The name of embedded resource that contains the theme.</param>
            /// <returns>The <see cref="ImageList"/> containing the images of the loaded image strip.</returns>
            public static ImageList LoadThemeImageListFromResource(this IElThemedControl control, string themeName)
            {
                try
                {
                    ImageList imageList = new ImageList
                    {
                        /// Fix bug with alpha channels by enabling transparency before adding any images to the list.
                        /// <seealso href="https://www.codeproject.com/articles/9142/adding-and-using-32-bit-alphablended-images-and-ic"/>
                        ColorDepth = ColorDepth.Depth32Bit
                    };

                    using (Stream bmpStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                        control.ThemeResourceNamespace + themeName + ElThemedControlExtensions.ThemeFileExtension))
                    {
                        var bitmap = new Bitmap(bmpStream);

                        imageList.ImageSize = new Size(bitmap.Height, bitmap.Height);

                        if (-1 == imageList.Images.AddStrip(bitmap))
                            throw new Exception(@"ImageList.Images.AddStrip() failed.");
                    }

                    return imageList;
                }
                catch (Exception ex)
                {
                    throw new Exception(@"Unable to get ImageList for theme.", ex);
                }
            }
    */
}
