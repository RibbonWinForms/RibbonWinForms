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

using System.Drawing;

namespace System.Windows.Forms.Classes.Collections
{
    /// <summary>
    /// An extended ImageList Implementation with ability to store two sizes for each Image, large and small.
    /// 
    /// <seealso href="http://dotnetframework.org/default.aspx/DotNET/DotNET/8@0/untmp/whidbey/REDBITS/ndp/fx/src/WinForms/Managed/System/WinForms/ImageList@cs/4/ImageList@cs"/>
    /// [Disable JavaScript when viewing this file]
    /// </summary>
    public class MultiSizeImageList
    {
        protected ImageList LargeImageList = new ImageList();
        protected ImageList SmallImageList = new ImageList();

        public MultiSizeImageList(int SmallWidth = 16, int SmallHeight = 16)
        {
            int LargeWidth = SmallWidth * 2;
            int LargeHeight = SmallHeight * 2;

            /// Fix bug with alpha channels by enabling transparency before adding any images to the list.
            /// <seealso href="https://www.codeproject.com/articles/9142/adding-and-using-32-bit-alphablended-images-and-ic"/>
            this.LargeImageList.ColorDepth = this.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;

            this.LargeImageList.ImageSize = new Size(LargeWidth, LargeHeight);
            this.SmallImageList.ImageSize = new Size(SmallWidth, SmallHeight);
        }

        // TODO: ImageList.AddStrip
        // TODO: Simple resize: Bitmap resizedBitmap = new Bitmap(imageList.Images[i], scaledSize);
        // TODO: High Quality resize: https://stackoverflow.com/questions/1922040/how-to-resize-an-image-c-sharp
    }
}
