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

namespace System.Windows.Forms.RibbonHelpers
{
    /// <summary>
    /// Provides Windows Operative System specific functionallity.
    /// </summary>
    public static partial class WinApi
    {
        #region Constants

        public const int SWP_NOSIZE = 0x0001;
        public const int SWP_NOMOVE = 0x0002;
        public const int SWP_NOZORDER = 0x0004;
        public const int SWP_NOREDRAW = 0x0008;
        public const int SWP_NOACTIVATE = 0x0010;
        public const int SWP_FRAMECHANGED = 0x0020; // The frame changed: send WM_NCCALCSIZE
        public const int SWP_DRAWFRAME = SWP_FRAMECHANGED;
        public const int SWP_SHOWWINDOW = 0x0040;
        public const int SWP_HIDEWINDOW = 0x0080;
        public const int SWP_NOCOPYBITS = 0x0100;
        public const int SWP_NOOWNERZORDER = 0x0200; // Don't do owner Z ordering
        public const int SWP_NOREPOSITION = SWP_NOOWNERZORDER;
        public const int SWP_NOSENDCHANGING = 0x0400; // Don't send WM_WINDOWPOSCHANGING


        public const int WM_MOUSEFIRST = 0x0200;
        public const int WM_MOUSEMOVE = 0x0200;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_LBUTTONDBLCLK = 0x0203;
        public const int WM_RBUTTONDOWN = 0x0204;
        public const int WM_RBUTTONUP = 0x0205;
        public const int WM_RBUTTONDBLCLK = 0x0206;
        public const int WM_MBUTTONDOWN = 0x0207;
        public const int WM_MBUTTONUP = 0x0208;
        public const int WM_MBUTTONDBLCLK = 0x0209;
        public const int WM_MOUSEWHEEL = 0x020A;
        public const int WM_XBUTTONDOWN = 0x020B;
        public const int WM_XBUTTONUP = 0x020C;
        public const int WM_XBUTTONDBLCLK = 0x020D;
        public const int WM_MOUSELAST = 0x020D;

        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0x101;
        public const int WM_SYSKEYDOWN = 0x104;
        public const int WM_SYSKEYUP = 0x105;

        public const byte VK_SHIFT = 0x10;
        public const byte VK_CAPITAL = 0x14;
        public const byte VK_NUMLOCK = 0x90;

        private const int DTT_COMPOSITED = (int)(1UL << 13);
        private const int DTT_GLOWSIZE = (int)(1UL << 11);

        private const int DT_SINGLELINE = 0x00000020;
        private const int DT_CENTER = 0x00000001;
        private const int DT_VCENTER = 0x00000004;
        private const int DT_NOPREFIX = 0x00000800;

        /// <summary>
        /// Enables the drop shadow effect on a window
        /// </summary>
        public const int CS_DROPSHADOW = 0x00020000;

        /// <summary>
        /// Windows NT/2000/XP: Installs a hook procedure that monitors low-level mouse input events.
        /// </summary>
        public const int WH_MOUSE_LL = 14;

        /// <summary>
        /// Windows NT/2000/XP: Installs a hook procedure that monitors low-level keyboard  input events.
        /// </summary>
        public const int WH_KEYBOARD_LL = 13;

        /// <summary>
        /// Installs a hook procedure that monitors mouse messages.
        /// </summary>
        public const int WH_MOUSE = 7;

        /// <summary>
        /// Installs a hook procedure that monitors keystroke messages.
        /// </summary>
        public const int WH_KEYBOARD = 2;

        /// <summary>
        /// The WM_NCLBUTTONDOWN message is posted when the user presses the left mouse button while the cursor is within the nonclient area of a window. 
        /// </summary>
        public const int WM_NCLBUTTONDOWN = 0x00A1;

        /// <summary>
        /// The WM_NCLBUTTONUP message is posted when the user releases the left mouse button while the cursor is within the nonclient area of a window. 
        /// </summary>
        public const int WM_NCLBUTTONUP = 0x00A2;

        internal const int WM_NCRBUTTONUP = 0x00A5;

        /// <summary>
        /// The WM_SIZE message is sent to a window after its size has changed.
        /// </summary>
        public const int WM_SIZE = 0x5;

        /// <summary>
        /// The WM_ERASEBKGND message is sent when the window background must be erased (for example, when a window is resized).
        /// </summary>
        public const int WM_ERASEBKGND = 0x14;

        /// <summary>
        /// The WM_NCCALCSIZE message is sent when the size and position of a window's client area must be calculated.
        /// </summary>
        public const int WM_NCCALCSIZE = 0x83;

        /// <summary>
        /// The WM_NCHITTEST message is sent to a window when the cursor moves, or when a mouse button is pressed or released.
        /// </summary>
        public const int WM_NCHITTEST = 0x84;

        /// <summary>
        /// The WM_NCMOUSEMOVE message is posted to a window when the cursor is moved within the nonclient area of the window. 
        /// </summary>
        public const int WM_NCMOUSEMOVE = 0x00A0;

        /// <summary>
        /// The WM_NCMOUSELEAVE message is posted to a window when the cursor leaves the nonclient area of the window specified in a prior call to TrackMouseEvent.
        /// </summary>
        public const int WM_NCMOUSELEAVE = 0x2a2;

        public const int WM_NCPAINT = 0x0085;
        public const int WM_NCACTIVATE = 0x86;
        public const int WM_SYSCOMMAND = 0x0112;
        public const int WM_WINDOWPOSCHANGING = 0x0046;
        public const int WM_WINDOWPOSCHANGED = 0x0047;
        public const int WM_PAINT = 0x000F;
        public const int WM_ACTIVATE = 0x06;
        public const int WM_THEMECHANGED = 0x31a;

        internal const int MF_BYCOMMAND = 0x00000000;
        internal const int MF_BYPOSITION = 0x00000400;

        internal const int MF_ENABLED = 0;
        internal const int MF_GRAYED = 0x00000001;
        internal const int MF_DISABLED = 0x00000002;

        /// <summary>
        /// wParam of WM_SYSCOMMAND.
        /// SC_RESTORE: Restores the window to its normal position and size.
        /// </summary>
        public const int SC_RESTORE = 0xF120;
        internal const int SC_SIZE = 0xF000;
        internal const int SC_MOVE = 0xF010;
        internal const int SC_MINIMIZE = 0xF020;
        internal const int SC_MAXIMIZE = 0xF030;
        internal const int SC_CLOSE = 0xF060;

        /// <summary>
        /// An uncompressed format.
        /// </summary>
        public const int BI_RGB = 0;

        /// <summary>
        /// The BITMAPINFO structure contains an array of literal RGB values.
        /// </summary>
        public const int DIB_RGB_COLORS = 0;

        /// <summary>
        /// Copies the source rectangle directly to the destination rectangle.
        /// </summary>
        public const int SRCCOPY = 0x00CC0020;

        /// <summary>
        /// For TrackPopupMenuEx API
        /// </summary>
        public const uint TPM_LEFTBUTTON = 0x0000;
        public const uint TPM_RETURNCMD = 0x0100;

        #endregion

        #region Dll Imports
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RedrawWindow(IntPtr hWnd, [In] ref RECT lprcUpdate,
           IntPtr hrgnUpdate, uint flags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate,
                          IntPtr hrgnUpdate, uint flags);

        [DllImport("user32.dll")]
        internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr
           hWndInsertAfter, int X,
           int Y, int cx, int cy, uint uFlags);

        [DllImport("user32")]
        internal static extern bool GetCursorPos(out POINT lpPoint);

        /// <summary>
        /// The ToAscii function translates the specified virtual-key code and keyboard state to the corresponding character or characters.
        /// </summary>
        /// <param name="uVirtKey"></param>
        /// <param name="uScanCode"></param>
        /// <param name="lpbKeyState"></param>
        /// <param name="lpwTransKey"></param>
        /// <param name="fuState"></param>
        /// <returns></returns>
        [DllImport("user32")]
        internal static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);

        /// <summary>
        /// The GetKeyboardState function copies the status of the 256 virtual keys to the specified buffer.
        /// </summary>
        /// <param name="pbKeyState"></param>
        /// <returns></returns>
        [DllImport("user32")]
        internal static extern int GetKeyboardState(byte[] pbKeyState);

        /// <summary>
        /// This function retrieves the status of the specified virtual key. The status specifies whether the key is up, down, or toggled on or off — alternating each time the key is pressed. 
        /// </summary>
        /// <param name="vKey"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        internal static extern short GetKeyState(int vKey);

        [DllImport("user32.dll")]
        internal static extern int GetWindowRect(IntPtr hwnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, uint fdwOptions);

        /// <summary>
        /// Installs an application-defined hook procedure into a hook chain
        /// </summary>
        /// <param name="idHook"></param>
        /// <param name="lpfn"></param>
        /// <param name="hInstance"></param>
        /// <param name="threadId"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        internal static extern IntPtr SetWindowsHookEx(int idHook, GlobalHook.HookProcCallBack lpfn, IntPtr hInstance, int threadId);

        /// <summary>
        /// Removes a hook procedure installed in a hook chain by the SetWindowsHookEx function. 
        /// </summary>
        /// <param name="idHook"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        internal static extern bool UnhookWindowsHookEx(IntPtr idHook);

        /// <summary>
        /// Passes the hook information to the next hook procedure in the current hook chain
        /// </summary>
        /// <param name="idHook"></param>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        internal static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// This function retrieves a handle to a display device context (DC) for the client area of the specified window.
        /// </summary>
        /// <param name="hdc"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        internal static extern IntPtr GetDC(IntPtr hdc);

        /// <summary>
        /// The SaveDC function saves the current state of the specified device context (DC) by copying data describing selected objects and graphic modes
        /// </summary>
        /// <param name="hdc"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        internal static extern int SaveDC(IntPtr hdc);

        /// <summary>
        /// This function releases a device context (DC), freeing it for use by other applications. The effect of ReleaseDC depends on the type of device context.
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        internal static extern int ReleaseDC(IntPtr hdc, IntPtr state);

        /// <summary>
        /// Draws text using the color and font defined by the visual style. Extends DrawThemeText by allowing additional text format options.
        /// </summary>
        /// <param name="hTheme"></param>
        /// <param name="hdc"></param>
        /// <param name="iPartId"></param>
        /// <param name="iStateId"></param>
        /// <param name="text"></param>
        /// <param name="iCharCount"></param>
        /// <param name="dwFlags"></param>
        /// <param name="pRect"></param>
        /// <param name="pOptions"></param>
        /// <returns></returns>
        [DllImport("UxTheme.dll", CharSet = CharSet.Unicode)]
        private static extern int DrawThemeTextEx(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string text, int iCharCount, int dwFlags, ref RECT pRect, ref DTTOPTS pOptions);

        /// <summary>
        /// Draws text using the color and font defined by the visual style.
        /// </summary>
        /// <param name="hTheme"></param>
        /// <param name="hdc"></param>
        /// <param name="iPartId"></param>
        /// <param name="iStateId"></param>
        /// <param name="text"></param>
        /// <param name="iCharCount"></param>
        /// <param name="dwFlags1"></param>
        /// <param name="dwFlags2"></param>
        /// <param name="pRect"></param>
        /// <returns></returns>
        [DllImport("UxTheme.dll", CharSet = CharSet.Unicode)]
        internal static extern int DrawThemeText(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string text, int iCharCount, int dwFlags1, int dwFlags2, ref RECT pRect);

        /// <summary>
        /// The CreateDIBSection function creates a DIB that applications can write to directly.
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="pbmi"></param>
        /// <param name="iUsage"></param>
        /// <param name="ppvBits"></param>
        /// <param name="hSection"></param>
        /// <param name="dwOffset"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO pbmi, uint iUsage, IntPtr ppvBits, IntPtr hSection, uint dwOffset);

        /// <summary>
        /// This function transfers pixels from a specified source rectangle to a specified destination rectangle, altering the pixels according to the selected raster operation (ROP) code.
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="nXDest"></param>
        /// <param name="nYDest"></param>
        /// <param name="nWidth"></param>
        /// <param name="nHeight"></param>
        /// <param name="hdcSrc"></param>
        /// <param name="nXSrc"></param>
        /// <param name="nYSrc"></param>
        /// <param name="dwRop"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        internal static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);

        /// <summary>
        /// This function creates a memory device context (DC) compatible with the specified device.
        /// </summary>
        /// <param name="hDC"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        internal static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        /// <summary>
        /// This function selects an object into a specified device context. The new object replaces the previous object of the same type.
        /// </summary>
        /// <param name="hDC"></param>
        /// <param name="hObject"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        internal static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        /// <summary>
        /// The DeleteObject function deletes a logical pen, brush, font, bitmap, region, or palette, freeing all system resources associated with the object. After the object is deleted, the specified handle is no longer valid.
        /// </summary>
        /// <param name="hObject"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        internal static extern bool DeleteObject(IntPtr hObject);

        /// <summary>
        /// The DeleteDC function deletes the specified device context (DC).
        /// </summary>
        /// <param name="hdc"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        internal static extern bool DeleteDC(IntPtr hdc);

        /// <summary>
        /// Sends the specified message to a window or windows
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Sends the specified message to a window or windows
        /// </summary>
        /// <param name="hWnd">handle to destination window</param>
        /// <param name="msg">message</param>
        /// <param name="wParam">first message parameter</param>
        /// <param name="lParam">second message parameter</param>
        /// <returns>none</returns>
        [DllImport("user32.dll")]
        internal static extern bool PostMessage(IntPtr hWnd, UInt32 msg, UIntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Gets the system (windows) menu for a window (the menu that appears when clicking the application icon on the top left of the window).
        /// </summary>
        /// <param name="hWnd">Handle of the Window to get the menu from.</param>
        /// <param name="bRevert">True=Clear any custom menu items and revert to Windows default.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        internal static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        /// <summary>
        /// Displays a shortcut menu at the specified location and tracks the selection of items on the shortcut menu.
        /// The shortcut menu can appear anywhere on the screen.
        /// </summary>
        /// <param name="hmenu">A handle to the shortcut menu to be displayed.</param>
        /// <param name="fuFlags">Specifies function options.</param>
        /// <param name="x">The horizontal location of the shortcut menu, in screen coordinates. </param>
        /// <param name="y">The vertical location of the shortcut menu, in screen coordinates. </param>
        /// <param name="hwnd">A handle to the window that owns the shortcut menu. This window receives all messages from the menu. </param>
        /// <param name="lptpm">A pointer to a TPMPARAMS structure that specifies an area of the screen the menu should not overlap. This parameter can be NULL. </param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        internal static extern uint TrackPopupMenuEx(IntPtr hmenu, uint fuFlags, int x, int y, IntPtr hwnd, IntPtr lptpm);

        [DllImport("user32.dll")]
        internal static extern bool SetMenuDefaultItem(IntPtr hMenu, uint uItem, uint fByPos);

        [DllImport("user32.dll")]
        internal static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        [DllImport("user32.dll")]
        internal static extern int GetSystemMetrics(SystemMetric smIndex);

        #endregion

        #region Structs

        /// <summary>
        /// Contains information about a mouse event passed to a WH_MOUSE hook procedure
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal class MouseLLHookStruct
        {
            public POINT pt;
            public int mouseData;
            public int flags;
            public int time;
            public int extraInfo;
        }

        /// <summary>
        /// Contains information about a low-level keyboard input event.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal class KeyboardLLHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        /// <summary>
        /// Contains information about a mouse event passed to a WH_MOUSE hook procedure
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal class MouseHookStruct
        {
            public POINT pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        /// <summary>
        /// Represents a point
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct POINT
        {
            public int x;
            public int y;

            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        /// <summary>
        /// Defines the options for the DrawThemeTextEx function.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct DTTOPTS
        {
            public uint dwSize;
            public uint dwFlags;
            public uint crText;
            public uint crBorder;
            public uint crShadow;
            public int iTextShadowType;
            public POINT ptShadowOffset;
            public int iBorderSize;
            public int iFontPropId;
            public int iColorPropId;
            public int iStateId;
            public int fApplyOverlay;
            public int iGlowSize;
            public IntPtr pfnDrawTextCallback;
            public int lParam;
        }

        /// <summary>
        /// This structure describes a color consisting of relative intensities of red, green, and blue.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct RGBQUAD
        {
            public readonly byte rgbBlue;
            public readonly byte rgbGreen;
            public readonly byte rgbRed;
            public readonly byte rgbReserved;
        }


        /// <summary>
        /// This structure contains information about the dimensions and color format of a device-independent bitmap (DIB).
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct BITMAPINFOHEADER
        {
            public int biSize;
            public int biWidth;
            public int biHeight;
            public short biPlanes;
            public short biBitCount;
            public int biCompression;
            public readonly int biSizeImage;
            public readonly int biXPelsPerMeter;
            public readonly int biYPelsPerMeter;
            public readonly int biClrUsed;
            public readonly int biClrImportant;
        }

        /// <summary>
        /// This structure defines the dimensions and color information of a Windows-based device-independent bitmap (DIB).
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct BITMAPINFO
        {
            public BITMAPINFOHEADER bmiHeader;
            public readonly RGBQUAD bmiColors;
        }

        /// <summary>
        /// Describes the width, height, and location of a rectangle.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public RECT(Rectangle rectangle)
            {
                Left = rectangle.X;
                Top = rectangle.Y;
                Right = rectangle.Right;
                Bottom = rectangle.Bottom;
            }
        }

        /// <summary>
        /// The NCCALCSIZE_PARAMS structure contains information that an application can use 
        /// while processing the WM_NCCALCSIZE message to calculate the size, position, and 
        /// valid contents of the client area of a window. 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct NCCALCSIZE_PARAMS
        {
            public RECT rect0, rect1, rect2;                    // Can't use an array here so simulate one
            public IntPtr lppos;
        }

        /// <summary>
        /// Used to specify margins of a window
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct MARGINS
        {
            public int cxLeftWidth;
            public int cxRightWidth;
            public int cyTopHeight;
            public int cyBottomHeight;

            public MARGINS(int Left, int Right, int Top, int Bottom)
            {
                cxLeftWidth = Left;
                cxRightWidth = Right;
                cyTopHeight = Top;
                cyBottomHeight = Bottom;
            }
        }
        #endregion

        #region Enums
        [Flags]
        internal enum DCX
        {
            DCX_CACHE = 0x2,
            DCX_CLIPCHILDREN = 0x8,
            DCX_CLIPSIBLINGS = 0x10,
            DCX_EXCLUDERGN = 0x40,
            DCX_EXCLUDEUPDATE = 0x100,
            DCX_INTERSECTRGN = 0x80,
            DCX_INTERSECTUPDATE = 0x200,
            DCX_LOCKWINDOWUPDATE = 0x400,
            DCX_NORECOMPUTE = 0x100000,
            DCX_NORESETATTRS = 0x4,
            DCX_PARENTCLIP = 0x20,
            DCX_VALIDATE = 0x200000,
            DCX_WINDOW = 0x1
        }

        /// <summary>
        /// Flags used with the Windows API (User32.dll):GetSystemMetrics(SystemMetric smIndex)
        ///   
        /// This Enum and declaration signature was written by Gabriel T. Sharp
        /// ai_productions@verizon.net or osirisgothra@hotmail.com
        /// Obtained on pinvoke.net, please contribute your code to support the wiki!
        /// </summary>
        public enum SystemMetric : int
        {
            /// <summary>
            /// The flags that specify how the system arranged minimized windows. For more information, see the Remarks section in this topic.
            /// </summary>
            SM_ARRANGE = 56,

            /// <summary>
            /// The value that specifies how the system is started: 
            /// 0 Normal boot
            /// 1 Fail-safe boot
            /// 2 Fail-safe with network boot
            /// A fail-safe boot (also called SafeBoot, Safe Mode, or Clean Boot) bypasses the user startup files.
            /// </summary>
            SM_CLEANBOOT = 67,

            /// <summary>
            /// The number of display monitors on a desktop. For more information, see the Remarks section in this topic.
            /// </summary>
            SM_CMONITORS = 80,

            /// <summary>
            /// The number of buttons on a mouse, or zero if no mouse is installed.
            /// </summary>
            SM_CMOUSEBUTTONS = 43,

            /// <summary>
            /// The width of a window border, in pixels. This is equivalent to the SM_CXEDGE value for windows with the 3-D look.
            /// </summary>
            SM_CXBORDER = 5,

            /// <summary>
            /// The width of a cursor, in pixels. The system cannot create cursors of other sizes.
            /// </summary>
            SM_CXCURSOR = 13,

            /// <summary>
            /// This value is the same as SM_CXFIXEDFRAME.
            /// </summary>
            SM_CXDLGFRAME = 7,

            /// <summary>
            /// The width of the rectangle around the location of a first click in a double-click sequence, in pixels. ,
            /// The second click must occur within the rectangle that is defined by SM_CXDOUBLECLK and SM_CYDOUBLECLK for the system
            /// to consider the two clicks a double-click. The two clicks must also occur within a specified time.
            /// To set the width of the double-click rectangle, call SystemParametersInfo with SPI_SETDOUBLECLKWIDTH.
            /// </summary>
            SM_CXDOUBLECLK = 36,

            /// <summary>
            /// The number of pixels on either side of a mouse-down point that the mouse pointer can move before a drag operation begins. 
            /// This allows the user to click and release the mouse button easily without unintentionally starting a drag operation. 
            /// If this value is negative, it is subtracted from the left of the mouse-down point and added to the right of it.
            /// </summary>
            SM_CXDRAG = 68,

            /// <summary>
            /// The width of a 3-D border, in pixels. This metric is the 3-D counterpart of SM_CXBORDER.
            /// </summary>
            SM_CXEDGE = 45,

            /// <summary>
            /// The thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels.
            /// SM_CXFIXEDFRAME is the height of the horizontal border, and SM_CYFIXEDFRAME is the width of the vertical border.
            /// This value is the same as SM_CXDLGFRAME.
            /// </summary>
            SM_CXFIXEDFRAME = 7,

            /// <summary>
            /// The width of the left and right edges of the focus rectangle that the DrawFocusRectdraws. 
            /// This value is in pixels. 
            /// Windows 2000:  This value is not supported.
            /// </summary>
            SM_CXFOCUSBORDER = 83,

            /// <summary>
            /// This value is the same as SM_CXSIZEFRAME.
            /// </summary>
            SM_CXFRAME = 32,

            /// <summary>
            /// The width of the client area for a full-screen window on the primary display monitor, in pixels. 
            /// To get the coordinates of the portion of the screen that is not obscured by the system taskbar or by application desktop toolbars, 
            /// call the SystemParametersInfofunction with the SPI_GETWORKAREA value.
            /// </summary>
            SM_CXFULLSCREEN = 16,

            /// <summary>
            /// The width of the arrow bitmap on a horizontal scroll bar, in pixels.
            /// </summary>
            SM_CXHSCROLL = 21,

            /// <summary>
            /// The width of the thumb box in a horizontal scroll bar, in pixels.
            /// </summary>
            SM_CXHTHUMB = 10,

            /// <summary>
            /// The default width of an icon, in pixels. The LoadIcon function can load only icons with the dimensions 
            /// that SM_CXICON and SM_CYICON specifies.
            /// </summary>
            SM_CXICON = 11,

            /// <summary>
            /// The width of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size 
            /// SM_CXICONSPACING by SM_CYICONSPACING when arranged. This value is always greater than or equal to SM_CXICON.
            /// </summary>
            SM_CXICONSPACING = 38,

            /// <summary>
            /// The default width, in pixels, of a maximized top-level window on the primary display monitor.
            /// </summary>
            SM_CXMAXIMIZED = 61,

            /// <summary>
            /// The default maximum width of a window that has a caption and sizing borders, in pixels. 
            /// This metric refers to the entire desktop. The user cannot drag the window frame to a size larger than these dimensions. 
            /// A window can override this value by processing the WM_GETMINMAXINFO message.
            /// </summary>
            SM_CXMAXTRACK = 59,

            /// <summary>
            /// The width of the default menu check-mark bitmap, in pixels.
            /// </summary>
            SM_CXMENUCHECK = 71,

            /// <summary>
            /// The width of menu bar buttons, such as the child window close button that is used in the multiple document interface, in pixels.
            /// </summary>
            SM_CXMENUSIZE = 54,

            /// <summary>
            /// The minimum width of a window, in pixels.
            /// </summary>
            SM_CXMIN = 28,

            /// <summary>
            /// The width of a minimized window, in pixels.
            /// </summary>
            SM_CXMINIMIZED = 57,

            /// <summary>
            /// The width of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when arranged. 
            /// This value is always greater than or equal to SM_CXMINIMIZED.
            /// </summary>
            SM_CXMINSPACING = 47,

            /// <summary>
            /// The minimum tracking width of a window, in pixels. The user cannot drag the window frame to a size smaller than these dimensions. 
            /// A window can override this value by processing the WM_GETMINMAXINFO message.
            /// </summary>
            SM_CXMINTRACK = 34,

            /// <summary>
            /// The amount of border padding for captioned windows, in pixels. Windows XP/2000:  This value is not supported.
            /// </summary>
            SM_CXPADDEDBORDER = 92,

            /// <summary>
            /// The width of the screen of the primary display monitor, in pixels. This is the same value obtained by calling 
            /// GetDeviceCaps as follows: GetDeviceCaps( hdcPrimaryMonitor, HORZRES).
            /// </summary>
            SM_CXSCREEN = 0,

            /// <summary>
            /// The width of a button in a window caption or title bar, in pixels.
            /// </summary>
            SM_CXSIZE = 30,

            /// <summary>
            /// The thickness of the sizing border around the perimeter of a window that can be resized, in pixels. 
            /// SM_CXSIZEFRAME is the width of the horizontal border, and SM_CYSIZEFRAME is the height of the vertical border. 
            /// This value is the same as SM_CXFRAME.
            /// </summary>
            SM_CXSIZEFRAME = 32,

            /// <summary>
            /// The recommended width of a small icon, in pixels. Small icons typically appear in window captions and in small icon view.
            /// </summary>
            SM_CXSMICON = 49,

            /// <summary>
            /// The width of small caption buttons, in pixels.
            /// </summary>
            SM_CXSMSIZE = 52,

            /// <summary>
            /// The width of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors. 
            /// The SM_XVIRTUALSCREEN metric is the coordinates for the left side of the virtual screen.
            /// </summary>
            SM_CXVIRTUALSCREEN = 78,

            /// <summary>
            /// The width of a vertical scroll bar, in pixels.
            /// </summary>
            SM_CXVSCROLL = 2,

            /// <summary>
            /// The height of a window border, in pixels. This is equivalent to the SM_CYEDGE value for windows with the 3-D look.
            /// </summary>
            SM_CYBORDER = 6,

            /// <summary>
            /// The height of a caption area, in pixels.
            /// </summary>
            SM_CYCAPTION = 4,

            /// <summary>
            /// The height of a cursor, in pixels. The system cannot create cursors of other sizes.
            /// </summary>
            SM_CYCURSOR = 14,

            /// <summary>
            /// This value is the same as SM_CYFIXEDFRAME.
            /// </summary>
            SM_CYDLGFRAME = 8,

            /// <summary>
            /// The height of the rectangle around the location of a first click in a double-click sequence, in pixels. 
            /// The second click must occur within the rectangle defined by SM_CXDOUBLECLK and SM_CYDOUBLECLK for the system to consider 
            /// the two clicks a double-click. The two clicks must also occur within a specified time. To set the height of the double-click 
            /// rectangle, call SystemParametersInfo with SPI_SETDOUBLECLKHEIGHT.
            /// </summary>
            SM_CYDOUBLECLK = 37,

            /// <summary>
            /// The number of pixels above and below a mouse-down point that the mouse pointer can move before a drag operation begins. 
            /// This allows the user to click and release the mouse button easily without unintentionally starting a drag operation. 
            /// If this value is negative, it is subtracted from above the mouse-down point and added below it.
            /// </summary>
            SM_CYDRAG = 69,

            /// <summary>
            /// The height of a 3-D border, in pixels. This is the 3-D counterpart of SM_CYBORDER.
            /// </summary>
            SM_CYEDGE = 46,

            /// <summary>
            /// The thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels. 
            /// SM_CXFIXEDFRAME is the height of the horizontal border, and SM_CYFIXEDFRAME is the width of the vertical border. 
            /// This value is the same as SM_CYDLGFRAME.
            /// </summary>
            SM_CYFIXEDFRAME = 8,

            /// <summary>
            /// The height of the top and bottom edges of the focus rectangle drawn byDrawFocusRect. 
            /// This value is in pixels. 
            /// Windows 2000:  This value is not supported.
            /// </summary>
            SM_CYFOCUSBORDER = 84,

            /// <summary>
            /// This value is the same as SM_CYSIZEFRAME.
            /// </summary>
            SM_CYFRAME = 33,

            /// <summary>
            /// The height of the client area for a full-screen window on the primary display monitor, in pixels. 
            /// To get the coordinates of the portion of the screen not obscured by the system taskbar or by application desktop toolbars,
            /// call the SystemParametersInfo function with the SPI_GETWORKAREA value.
            /// </summary>
            SM_CYFULLSCREEN = 17,

            /// <summary>
            /// The height of a horizontal scroll bar, in pixels.
            /// </summary>
            SM_CYHSCROLL = 3,

            /// <summary>
            /// The default height of an icon, in pixels. The LoadIcon function can load only icons with the dimensions SM_CXICON and SM_CYICON.
            /// </summary>
            SM_CYICON = 12,

            /// <summary>
            /// The height of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size 
            /// SM_CXICONSPACING by SM_CYICONSPACING when arranged. This value is always greater than or equal to SM_CYICON.
            /// </summary>
            SM_CYICONSPACING = 39,

            /// <summary>
            /// For double byte character set versions of the system, this is the height of the Kanji window at the bottom of the screen, in pixels.
            /// </summary>
            SM_CYKANJIWINDOW = 18,

            /// <summary>
            /// The default height, in pixels, of a maximized top-level window on the primary display monitor.
            /// </summary>
            SM_CYMAXIMIZED = 62,

            /// <summary>
            /// The default maximum height of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop. 
            /// The user cannot drag the window frame to a size larger than these dimensions. A window can override this value by processing 
            /// the WM_GETMINMAXINFO message.
            /// </summary>
            SM_CYMAXTRACK = 60,

            /// <summary>
            /// The height of a single-line menu bar, in pixels.
            /// </summary>
            SM_CYMENU = 15,

            /// <summary>
            /// The height of the default menu check-mark bitmap, in pixels.
            /// </summary>
            SM_CYMENUCHECK = 72,

            /// <summary>
            /// The height of menu bar buttons, such as the child window close button that is used in the multiple document interface, in pixels.
            /// </summary>
            SM_CYMENUSIZE = 55,

            /// <summary>
            /// The minimum height of a window, in pixels.
            /// </summary>
            SM_CYMIN = 29,

            /// <summary>
            /// The height of a minimized window, in pixels.
            /// </summary>
            SM_CYMINIMIZED = 58,

            /// <summary>
            /// The height of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when arranged. 
            /// This value is always greater than or equal to SM_CYMINIMIZED.
            /// </summary>
            SM_CYMINSPACING = 48,

            /// <summary>
            /// The minimum tracking height of a window, in pixels. The user cannot drag the window frame to a size smaller than these dimensions. 
            /// A window can override this value by processing the WM_GETMINMAXINFO message.
            /// </summary>
            SM_CYMINTRACK = 35,

            /// <summary>
            /// The height of the screen of the primary display monitor, in pixels. This is the same value obtained by calling 
            /// GetDeviceCaps as follows: GetDeviceCaps( hdcPrimaryMonitor, VERTRES).
            /// </summary>
            SM_CYSCREEN = 1,

            /// <summary>
            /// The height of a button in a window caption or title bar, in pixels.
            /// </summary>
            SM_CYSIZE = 31,

            /// <summary>
            /// The thickness of the sizing border around the perimeter of a window that can be resized, in pixels. 
            /// SM_CXSIZEFRAME is the width of the horizontal border, and SM_CYSIZEFRAME is the height of the vertical border. 
            /// This value is the same as SM_CYFRAME.
            /// </summary>
            SM_CYSIZEFRAME = 33,

            /// <summary>
            /// The height of a small caption, in pixels.
            /// </summary>
            SM_CYSMCAPTION = 51,

            /// <summary>
            /// The recommended height of a small icon, in pixels. Small icons typically appear in window captions and in small icon view.
            /// </summary>
            SM_CYSMICON = 50,

            /// <summary>
            /// The height of small caption buttons, in pixels.
            /// </summary>
            SM_CYSMSIZE = 53,

            /// <summary>
            /// The height of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors. 
            /// The SM_YVIRTUALSCREEN metric is the coordinates for the top of the virtual screen.
            /// </summary>
            SM_CYVIRTUALSCREEN = 79,

            /// <summary>
            /// The height of the arrow bitmap on a vertical scroll bar, in pixels.
            /// </summary>
            SM_CYVSCROLL = 20,

            /// <summary>
            /// The height of the thumb box in a vertical scroll bar, in pixels.
            /// </summary>
            SM_CYVTHUMB = 9,

            /// <summary>
            /// Nonzero if User32.dll supports DBCS; otherwise, 0.
            /// </summary>
            SM_DBCSENABLED = 42,

            /// <summary>
            /// Nonzero if the debug version of User.exe is installed; otherwise, 0.
            /// </summary>
            SM_DEBUG = 22,

            /// <summary>
            /// Nonzero if the current operating system is Windows 7 or Windows Server 2008 R2 and the Tablet PC Input 
            /// service is started; otherwise, 0. The return value is a bitmask that specifies the type of digitizer input supported by the device. 
            /// For more information, see Remarks. 
            /// Windows Server 2008, Windows Vista, and Windows XP/2000:  This value is not supported.
            /// </summary>
            SM_DIGITIZER = 94,

            /// <summary>
            /// Nonzero if Input Method Manager/Input Method Editor features are enabled; otherwise, 0. 
            /// SM_IMMENABLED indicates whether the system is ready to use a Unicode-based IME on a Unicode application. 
            /// To ensure that a language-dependent IME works, check SM_DBCSENABLED and the system ANSI code page.
            /// Otherwise the ANSI-to-Unicode conversion may not be performed correctly, or some components like fonts
            /// or registry settings may not be present.
            /// </summary>
            SM_IMMENABLED = 82,

            /// <summary>
            /// Nonzero if there are digitizers in the system; otherwise, 0. SM_MAXIMUMTOUCHES returns the aggregate maximum of the 
            /// maximum number of contacts supported by every digitizer in the system. If the system has only single-touch digitizers, 
            /// the return value is 1. If the system has multi-touch digitizers, the return value is the number of simultaneous contacts 
            /// the hardware can provide. Windows Server 2008, Windows Vista, and Windows XP/2000:  This value is not supported.
            /// </summary>
            SM_MAXIMUMTOUCHES = 95,

            /// <summary>
            /// Nonzero if the current operating system is the Windows XP, Media Center Edition, 0 if not.
            /// </summary>
            SM_MEDIACENTER = 87,

            /// <summary>
            /// Nonzero if drop-down menus are right-aligned with the corresponding menu-bar item; 0 if the menus are left-aligned.
            /// </summary>
            SM_MENUDROPALIGNMENT = 40,

            /// <summary>
            /// Nonzero if the system is enabled for Hebrew and Arabic languages, 0 if not.
            /// </summary>
            SM_MIDEASTENABLED = 74,

            /// <summary>
            /// Nonzero if a mouse is installed; otherwise, 0. This value is rarely zero, because of support for virtual mice and because 
            /// some systems detect the presence of the port instead of the presence of a mouse.
            /// </summary>
            SM_MOUSEPRESENT = 19,

            /// <summary>
            /// Nonzero if a mouse with a horizontal scroll wheel is installed; otherwise 0.
            /// </summary>
            SM_MOUSEHORIZONTALWHEELPRESENT = 91,

            /// <summary>
            /// Nonzero if a mouse with a vertical scroll wheel is installed; otherwise 0.
            /// </summary>
            SM_MOUSEWHEELPRESENT = 75,

            /// <summary>
            /// The least significant bit is set if a network is present; otherwise, it is cleared. The other bits are reserved for future use.
            /// </summary>
            SM_NETWORK = 63,

            /// <summary>
            /// Nonzero if the Microsoft Windows for Pen computing extensions are installed; zero otherwise.
            /// </summary>
            SM_PENWINDOWS = 41,

            /// <summary>
            /// This system metric is used in a Terminal Services environment to determine if the current Terminal Server session is 
            /// being remotely controlled. Its value is nonzero if the current session is remotely controlled; otherwise, 0. 
            /// You can use terminal services management tools such as Terminal Services Manager (tsadmin.msc) and shadow.exe to 
            /// control a remote session. When a session is being remotely controlled, another user can view the contents of that session 
            /// and potentially interact with it.
            /// </summary>
            SM_REMOTECONTROL = 0x2001,

            /// <summary>
            /// This system metric is used in a Terminal Services environment. If the calling process is associated with a Terminal Services 
            /// client session, the return value is nonzero. If the calling process is associated with the Terminal Services console session, 
            /// the return value is 0. 
            /// Windows Server 2003 and Windows XP:  The console session is not necessarily the physical console. 
            /// For more information, seeWTSGetActiveConsoleSessionId.
            /// </summary>
            SM_REMOTESESSION = 0x1000,

            /// <summary>
            /// Nonzero if all the display monitors have the same color format, otherwise, 0. Two displays can have the same bit depth, 
            /// but different color formats. For example, the red, green, and blue pixels can be encoded with different numbers of bits, 
            /// or those bits can be located in different places in a pixel color value.
            /// </summary>
            SM_SAMEDISPLAYFORMAT = 81,

            /// <summary>
            /// This system metric should be ignored; it always returns 0.
            /// </summary>
            SM_SECURE = 44,

            /// <summary>
            /// The build number if the system is Windows Server 2003 R2; otherwise, 0.
            /// </summary>
            SM_SERVERR2 = 89,

            /// <summary>
            /// Nonzero if the user requires an application to present information visually in situations where it would otherwise present 
            /// the information only in audible form; otherwise, 0.
            /// </summary>
            SM_SHOWSOUNDS = 70,

            /// <summary>
            /// Nonzero if the current session is shutting down; otherwise, 0. Windows 2000:  This value is not supported.
            /// </summary>
            SM_SHUTTINGDOWN = 0x2000,

            /// <summary>
            /// Nonzero if the computer has a low-end (slow) processor; otherwise, 0.
            /// </summary>
            SM_SLOWMACHINE = 73,

            /// <summary>
            /// Nonzero if the current operating system is Windows 7 Starter Edition, Windows Vista Starter, or Windows XP Starter Edition; otherwise, 0.
            /// </summary>
            SM_STARTER = 88,

            /// <summary>
            /// Nonzero if the meanings of the left and right mouse buttons are swapped; otherwise, 0.
            /// </summary>
            SM_SWAPBUTTON = 23,

            /// <summary>
            /// Nonzero if the current operating system is the Windows XP Tablet PC edition or if the current operating system is Windows Vista
            /// or Windows 7 and the Tablet PC Input service is started; otherwise, 0. The SM_DIGITIZER setting indicates the type of digitizer 
            /// input supported by a device running Windows 7 or Windows Server 2008 R2. For more information, see Remarks.
            /// </summary>
            SM_TABLETPC = 86,

            /// <summary>
            /// The coordinates for the left side of the virtual screen. The virtual screen is the bounding rectangle of all display monitors. 
            /// The SM_CXVIRTUALSCREEN metric is the width of the virtual screen.
            /// </summary>
            SM_XVIRTUALSCREEN = 76,

            /// <summary>
            /// The coordinates for the top of the virtual screen. The virtual screen is the bounding rectangle of all display monitors. 
            /// The SM_CYVIRTUALSCREEN metric is the height of the virtual screen.
            /// </summary>
            SM_YVIRTUALSCREEN = 77,
        }

        public enum HitTest
        {
            HTBORDER = 18,
            //In the border of a window that does not have a sizing border.
            HTBOTTOM = 15,
            //In the lower-horizontal border of a resizable window (the user can click the mouse to resize the window vertically).
            HTBOTTOMLEFT = 16,
            //In the lower-left corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).
            HTBOTTOMRIGHT = 17,
            //In the lower-right corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).
            HTCAPTION = 2,
            //In a title bar.
            HTCLIENT = 1,
            //In a client area.
            HTCLOSE = 20,
            //In a Close button.
            HTERROR = -2,
            //On the screen background or on a dividing line between windows (same as HTNOWHERE, except that the DefWindowProc function produces a system beep to indicate an error).
            HTGROWBOX = 4,
            //In a size box (same as HTSIZE).
            HTHELP = 21,
            //In a Help button.
            HTHSCROLL = 6,
            //In a horizontal scroll bar.
            HTLEFT = 10,
            //In the left border of a resizable window (the user can click the mouse to resize the window horizontally).
            HTMENU = 5,
            //In a menu.
            HTMAXBUTTON = 9,
            //In a Maximize button.
            HTMINBUTTON = 8,
            //In a Minimize button.
            HTNOWHERE = 0,
            //On the screen background or on a dividing line between windows.
            HTREDUCE = 8,
            //In a Minimize button.
            HTRIGHT = 11,
            //In the right border of a resizable window (the user can click the mouse to resize the window horizontally).
            HTSIZE = 4,
            //In a size box (same as HTGROWBOX).
            HTSYSMENU = 3,
            //In a window menu or in a Close button in a child window.
            HTTOP = 12,
            //In the upper-horizontal border of a window.
            HTTOPLEFT = 13,
            //In the upper-left corner of a window border.
            HTTOPRIGHT = 14,
            //In the upper-right corner of a window border.
            HTTRANSPARENT = -1,
            //In a window currently covered by another window in the same thread (the message will be sent to underlying windows in the same thread until one of them returns a code that is not HTTRANSPARENT).
            HTVSCROLL = 7,
            //In the vertical scroll bar.
            HTZOOM = 9,
            //In a Maximize button.
        }
        #endregion

        #region Methods
        public static void InvalidateWindow(IntPtr hDC)
        {
            RedrawWindow(hDC, IntPtr.Zero, IntPtr.Zero,
                 0x0400/*RDW_FRAME*/ | 0x0100/*RDW_UPDATENOW*/
                 | 0x0001/*RDW_INVALIDATE*/);
        }

        /// <summary>
        /// Invalidates non-client area
        /// </summary>
        public static void InvalidateNC(IntPtr hDC)
        {
            SetWindowPos(hDC, IntPtr.Zero, 0, 0, 0, 0,
            SWP_NOMOVE |
            SWP_NOSIZE |
            SWP_NOZORDER |
            SWP_NOACTIVATE |
            SWP_DRAWFRAME
            );
        }

        /// <summary>
        /// Equivalent to the HiWord C Macro
        /// </summary>
        /// <param name="dwValue"></param>
        /// <returns></returns>
        public static short HiWord(int dwValue)
        {
            return (short)((dwValue >> 16) & 0xFFFF);
        }

        /// <summary>
        /// Equivalent to the LoWord C Macro
        /// </summary>
        /// <param name="dwValue"></param>
        /// <returns></returns>
        public static short LoWord(int dwValue)
        {
            return (short)(dwValue & 0xFFFF);
        }

        /// <summary>
        /// Equivalent to the MakeLParam C Macro
        /// </summary>
        /// <param name="LoWord"></param>
        /// <param name="HiWord"></param>
        /// <returns></returns>
        public static IntPtr MakeLParam(int LoWord, int HiWord)
        {
            return new IntPtr((HiWord << 16) | (LoWord & 0xffff));
        }

        /// <summary>
        /// Equivalent to the Get_X_LParam C Macro
        /// </summary>
        /// <param name="dwValue"></param>
        /// <returns></returns>
        internal static int Get_X_LParam(int dwValue)
        {
            return (int)(short)(dwValue & 0xFFFF);
        }

        /// <summary>
        /// Equivalent to the Get_Y_LParam C Macro
        /// </summary>
        /// <param name="dwValue"></param>
        /// <returns></returns>
        internal static int Get_Y_LParam(int dwValue)
        {
            return (int)(short)((dwValue >> 16) & 0xFFFF);
        }

        private static readonly int[] mfFlags = { MF_GRAYED, MF_ENABLED };

        public static void ShowSystemMenu(Form form, int xMouse, int yMouse)
        {
            UIntPtr cmd;
            IntPtr menu;

            void UpdateItem(uint ID, bool enable, bool makeDefaultIfEnabled = false)
            {
                int flagsIndex = 0;
                if (enable)
                {
                    flagsIndex = 1;
                }
                EnableMenuItem(menu, ID, (uint)(MF_BYCOMMAND | mfFlags[flagsIndex]));
                if (makeDefaultIfEnabled && enable)
                {
                    SetMenuDefaultItem(menu, ID, MF_BYCOMMAND);
                }
            }

            menu = GetSystemMenu(form.Handle, false);

            FormBorderStyle formBorderStyle = form.FormBorderStyle;
            FormWindowState windowState = form.WindowState;

            if (formBorderStyle == FormBorderStyle.FixedSingle ||
                formBorderStyle == FormBorderStyle.Sizable ||
                formBorderStyle == FormBorderStyle.FixedToolWindow ||
                formBorderStyle == FormBorderStyle.SizableToolWindow)
            {
                UpdateItem(SC_RESTORE, windowState != FormWindowState.Normal, true);
                UpdateItem(SC_MOVE, windowState != FormWindowState.Maximized);
                UpdateItem(SC_SIZE, (windowState != FormWindowState.Maximized) &&
                    (formBorderStyle == FormBorderStyle.Sizable || formBorderStyle == FormBorderStyle.SizableToolWindow));
                UpdateItem(SC_MINIMIZE, form.MinimizeBox && 
                    (formBorderStyle == FormBorderStyle.FixedSingle || formBorderStyle == FormBorderStyle.Sizable));
                UpdateItem(SC_MAXIMIZE, form.MaximizeBox &&
                    (formBorderStyle == FormBorderStyle.FixedSingle || formBorderStyle == FormBorderStyle.Sizable) && (windowState != FormWindowState.Maximized), true);
            }

            SetMenuDefaultItem(menu, SC_CLOSE, MF_BYCOMMAND);

            cmd = (UIntPtr)TrackPopupMenuEx(menu, (uint)(TPM_RETURNCMD | GetSystemMetrics(SystemMetric.SM_MENUDROPALIGNMENT)), xMouse, yMouse, form.Handle, IntPtr.Zero);

            if (cmd == UIntPtr.Zero)
                return;

            PostMessage(form.Handle, WinApi.WM_SYSCOMMAND, cmd, IntPtr.Zero);
        }

        public static void ShowSystemMenu(Form form)
        {
            if (GetCursorPos(out POINT mousePos))
            {
                ShowSystemMenu(form, mousePos.x, mousePos.y);
            }
        }

        #endregion
    }
}