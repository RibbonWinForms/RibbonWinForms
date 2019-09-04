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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

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

        // TODO: Replace() ///////////////////////////////////////////////////////////////////////////////////////////
        // TODO: Instead of “trying to add” Image(Strip)s to both Lists, which is very, very error-prone when trying
        //       to do a “RollBack”, extracting from ImageStrip will only be done in the constructor; then,
        //       via “Replace[Images]”, we can simply replace the existing lists by already existing ones.

        /// <summary>
        /// Add images contained in given ImageStrip to this <see cref="RibbonMultiSizeImageList"/> instance.<br/><br/>
        /// Valid sizes for <paramref name="imageStrip"/> are as follows:<br/>
        /// SmallImageSize.Height: In this case, the large images will be scaled.<br/>
        /// LargeImageSize.Height: In this case, the small images will be scaled.<br/>
        /// </summary>
        /// <param name="imageStrip">An ImageStrip containing the Images that will be added.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when given ImageStrip has invalid size.</exception>
        public int AddStrip(Bitmap imageStrip)      // TODO: See Replace()
        {
            int imageStripWidth = imageStrip.Width;
            int imageStripHeight = imageStrip.Height;
            int countOfImages;

            // Check height of given ImageStrip to determine the Image Extraction Method
            if (imageStripHeight == this.SmallImageSize.Height)                     // Small Image Extraction path
            {
                if (0 != (imageStripWidth % this.SmallImageSize.Width))
                    throw new RibbonBadImageStripException(Width: imageStripWidth);

                countOfImages = imageStripWidth / this.SmallImageSize.Width;
                int scaledWidth = (this.LargeImageSize.Width) * countOfImages;
                int scaledHeight = this.LargeImageSize.Height;

                //                var scaledBitmap = blubb;
                //var bitmap = new Bitmap(bmpStream);

                //imageList.ImageSize = new Size(bitmap.Height, bitmap.Height);




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

        public int AddStrip(Bitmap smallImageStrip, Bitmap largeImageStrip)       // TODO: See Replace()
        {
            int oldTempImageCount;

            Debug.Assert(condition: (this.SmallImageList.Images.Count == this.LargeImageList.Images.Count),
                "Invalid state: Count of SmallImageList does not equal count of LargeImageList");

            int smallImageCount = this.VerifyImageStripTargetedForImageList(ref smallImageStrip, ref this.SmallImageList);
            int largeImageCount = this.VerifyImageStripTargetedForImageList(ref largeImageStrip, ref this.LargeImageList);

            if (smallImageCount != largeImageCount)
                throw new RibbonBadImageStripException($"Count of images in Small Image Strip ({smallImageCount}) " +
                    $"does not match count of images in Large Image Strip ({largeImageCount})");

            int smallImagesAdded, largeImagesAdded;

            //
            // Add small images to our internal image list
            //
            oldTempImageCount = this.SmallImageList.Images.Count;

            try
            {
                smallImagesAdded = this.SmallImageList.Images.AddStrip(smallImageStrip);

                if (smallImagesAdded != smallImageCount)
                    throw new RibbonBadImageStripException("Error while adding Images to small ImageList");
            }
            catch (Exception ex)
            {
                // In case of exception, remove recently added images
                while (this.SmallImageList.Images.Count > oldTempImageCount)
                    this.SmallImageList.Images.RemoveAt(oldTempImageCount);

                throw new RibbonBadImageStripException("Failed to add small ImageStrip to RibbonMultiSizeImageList", ex);
            }

            //
            // Add large images to our internal image list
            //
            oldTempImageCount = this.LargeImageList.Images.Count;

            try
            {
                largeImagesAdded = this.LargeImageList.Images.AddStrip(largeImageStrip);

                if (largeImagesAdded != largeImageCount)
                    throw new RibbonBadImageStripException("Error while adding Images to large ImageList");
            }
            catch (Exception ex)
            {
                // In case of exception, remove recently added images
                while (this.SmallImageList.Images.Count > oldTempImageCount)
                    this.SmallImageList.Images.RemoveAt(oldTempImageCount);
                while (this.LargeImageList.Images.Count > oldTempImageCount)
                    this.LargeImageList.Images.RemoveAt(oldTempImageCount);

                throw new RibbonBadImageStripException("Failed to add large ImageStrip to RibbonMultiSizeImageList", ex);
            }

            return smallImagesAdded;
        }

        protected int VerifyImageStripTargetedForImageList(ref Bitmap imageStrip, ref ImageList targetImageList)
        {
            int imageStripWidth = imageStrip.Width;
            int imageStripHeight = imageStrip.Height;
            Size targetImageSize = targetImageList.ImageSize;

            // Check width of ImageStrip
            if (0 != (imageStripWidth % targetImageSize.Width))
                throw new RibbonBadImageStripException(Width: imageStripWidth);

            // Check height of ImageStrip
            if (imageStripHeight != targetImageSize.Height)
                throw new RibbonBadImageStripException(Height: imageStripHeight);

            // Return number of images
            return (imageStripWidth / targetImageSize.Width);
        }

        protected Bitmap CreateScaledBitmap(ref Bitmap sourceBitmap, ref Size targetSize, MultiSizeImageListScaleMode scaleMode)
        {
            //
            // Simple resize
            //
            if (MultiSizeImageListScaleMode.Simple == scaleMode)
            {
                return new Bitmap(sourceBitmap, targetSize);
            }
            //
            // High Quality resize <see href="https://stackoverflow.com/questions/1922040/how-to-resize-an-image-c-sharp"/>
            //
            else if (MultiSizeImageListScaleMode.HighQuality == scaleMode)
            {
                var destRect = new Rectangle(0, 0, targetSize.Width, targetSize.Height);
                var destImage = new Bitmap(targetSize.Width, targetSize.Height);

                destImage.SetResolution(sourceBitmap.HorizontalResolution, sourceBitmap.VerticalResolution);

                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(sourceBitmap, destRect, 0, 0, sourceBitmap.Width, sourceBitmap.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                }

                return destImage;
            }

            throw new ArgumentOutOfRangeException("ScaleMode", "Unknown ScaleMode");
        }
    }

    /// <summary>
    /// <see cref="RibbonBadImageStripException"/> is thrown by <see cref="RibbonMultiSizeImageList"/>
    /// whenever extracting Images from the given ImageStrip fails cause of invalid input parameters.
    /// </summary>
    [Serializable()]
    public class RibbonBadImageStripException
      : Exception
    {
        protected RibbonBadImageStripException()
          : base() { }

        public RibbonBadImageStripException(int? Width = null, int? Height = null)
          : base(message: $"Invalid image strip size:"
                          + (Width != null ? " Width=" + Width : "")
                          + (Height != null ? " Height=" + Height : ""))
        { }

        public RibbonBadImageStripException(string message)
          : base(message) { }

        public RibbonBadImageStripException(string message, Exception innerException)
          : base(message, innerException) { }
    }
}
