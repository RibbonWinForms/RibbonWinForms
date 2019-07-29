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
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;

namespace System.Windows.Forms.RibbonHelpers
{
    public static partial class WinApi
    {
        /// <summary>
        /// Extends the window frame behind the client area.
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="marInset"></param>
        /// <returns></returns>
        [DllImport("dwmapi.dll")]
        internal static extern int DwmExtendFrameIntoClientArea(IntPtr hdc, ref MARGINS marInset);

        /// <summary>
        /// Default window procedure for Desktop Window Manager (DWM) hit-testing within the non-client area.
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("dwmapi.dll")]
        internal static extern int DwmDefWindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, out IntPtr result);

        /// <summary>
        /// Obtains a value that indicates whether Desktop Window Manager (DWM) composition is enabled.
        /// </summary>
        /// <param name="pfEnabled"></param>
        /// <returns></returns>
        [DllImport("dwmapi.dll")]
        internal static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        /// <summary>
        /// Examine if current Operating System uses Aero Glass effects for Window Frames by default.
        /// 
        /// That's the case for Windows Vista and Windows 7, but not for Windows 8 or higher.
        /// </summary>
        public static bool IsGlassEnabled {
            get {
                // Check for Windows Vista or Windows 7, but exclude Windows 8 and higher
                if (IsWindowsVistaOrGreater && (!IsWindows8OrGreater))
                {
                    //Check what DWM says about composition
                    int enabled = 0;
                    int response = DwmIsCompositionEnabled(ref enabled);

                    // response is HRESULT, (HRESULT == 0) equals HRESULT.S_OK
                    if ((response == 0) && (enabled > 0))
                        return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Fills an area for glass rendering
        /// </summary>
        /// <param name="g"></param>
        /// <param name="r"></param>
        public static void FillForGlass(Graphics g, Rectangle r)
        {
            RECT rc = new RECT
            {
                Left = r.Left,
                Right = r.Right,
                Top = r.Top,
                Bottom = r.Bottom
            };

            IntPtr destdc = g.GetHdc();    //hwnd must be the handle of form,not control
            IntPtr Memdc = CreateCompatibleDC(destdc);
            IntPtr bitmap;
            IntPtr bitmapOld = IntPtr.Zero;

            BITMAPINFO dib = new BITMAPINFO();
            dib.bmiHeader.biHeight = -(rc.Bottom - rc.Top);
            dib.bmiHeader.biWidth = rc.Right - rc.Left;
            dib.bmiHeader.biPlanes = 1;
            dib.bmiHeader.biSize = Marshal.SizeOf(typeof(BITMAPINFOHEADER));
            dib.bmiHeader.biBitCount = 32;
            dib.bmiHeader.biCompression = BI_RGB;

            if (!(SaveDC(Memdc) == 0))
            {
                bitmap = CreateDIBSection(Memdc, ref dib, DIB_RGB_COLORS, (IntPtr)0, IntPtr.Zero, 0);
                if (!(bitmap == IntPtr.Zero))
                {
                    bitmapOld = SelectObject(Memdc, bitmap);
                    BitBlt(destdc, rc.Left, rc.Top, rc.Right - rc.Left, rc.Bottom - rc.Top, Memdc, 0, 0, SRCCOPY);

                }

                //Remember to clean up
                SelectObject(Memdc, bitmapOld);

                DeleteObject(bitmap);

                ReleaseDC(Memdc, (IntPtr)(-1));
                DeleteDC(Memdc);


            }
            g.ReleaseHdc();

        }

        /// <summary>
        /// Draws theme text on glass.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="bounds"></param>
        /// <param name="glowSize"></param>
        /// <remarks>This method is courtesy of 版权所有 (I hope the name's right)</remarks>
        public static void DrawTextOnGlass(Graphics graphics, String text, Font font, Rectangle bounds, int glowSize)
        {
            if (IsGlassEnabled)
            {
                IntPtr destdc = IntPtr.Zero;
                try
                {
                    destdc = graphics.GetHdc();
                    IntPtr Memdc = CreateCompatibleDC(destdc);   // Set up a memory DC where we'll draw the text.
                    IntPtr bitmap;
                    IntPtr bitmapOld = IntPtr.Zero;
                    IntPtr logfnotOld;

                    int uFormat = DT_SINGLELINE | DT_CENTER | DT_VCENTER | DT_NOPREFIX;   //text format

                    BITMAPINFO dib = new BITMAPINFO();
                    dib.bmiHeader.biHeight = -bounds.Height;         // negative because DrawThemeTextEx() uses a top-down DIB
                    dib.bmiHeader.biWidth = bounds.Width;
                    dib.bmiHeader.biPlanes = 1;
                    dib.bmiHeader.biSize = Marshal.SizeOf(typeof(BITMAPINFOHEADER));
                    dib.bmiHeader.biBitCount = 32;
                    dib.bmiHeader.biCompression = BI_RGB;

                    if (!(SaveDC(Memdc) == 0))
                    {
                        bitmap = CreateDIBSection(Memdc, ref dib, DIB_RGB_COLORS, (IntPtr)0, IntPtr.Zero, 0);   // Create a 32-bit bmp for use in offscreen drawing when glass is on
                        if (!(bitmap == IntPtr.Zero))
                        {
                            bitmapOld = SelectObject(Memdc, bitmap);
                            IntPtr hFont = font.ToHfont();
                            logfnotOld = SelectObject(Memdc, hFont);
                            try
                            {

                                VisualStyleRenderer renderer = new VisualStyleRenderer(VisualStyleElement.Window.Caption.Active);

                                DTTOPTS dttOpts = new DTTOPTS
                                {
                                    dwSize = (uint)Marshal.SizeOf(typeof(DTTOPTS)),
                                    dwFlags = DTT_COMPOSITED | DTT_GLOWSIZE,
                                    iGlowSize = glowSize
                                };

                                RECT rc2 = new RECT(0, 0, bounds.Width, bounds.Height);
                                int dtter = DrawThemeTextEx(renderer.Handle, Memdc, 0, 0, text, -1, uFormat, ref rc2, ref dttOpts);
                                bool bbr = BitBlt(destdc, bounds.Left, bounds.Top, bounds.Width, bounds.Height, Memdc, 0, 0, SRCCOPY);
                                if (!bbr)
                                {
                                    //throw new Exception("???");
                                }
                            }
                            catch (Exception)
                            {
                                //Console.WriteLine(e.ToString());
                                //throw new Exception("???");
                            }

                            //Remember to clean up
                            SelectObject(Memdc, bitmapOld);
                            SelectObject(Memdc, logfnotOld);
                            DeleteObject(bitmap);
                            DeleteObject(hFont);

                            ReleaseDC(Memdc, (IntPtr)(-1));
                            DeleteDC(Memdc);
                        }
                    }
                }
                finally
                {
                    if (destdc != IntPtr.Zero)
                        graphics.ReleaseHdc(destdc);
                }
            }
        }
    }
}
