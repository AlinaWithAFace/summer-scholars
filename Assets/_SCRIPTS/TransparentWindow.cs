using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class TransparentWindow : MonoBehaviour
{
    [SerializeField] private Material m_Material;

    private struct MARGINS
    {
        public int cxLeftWidth;
        public int cxRightWidth;
        public int cyTopHeight;
        public int cyBottomHeight;
    }

    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll")]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

    [DllImport("user32.dll")]
    static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll", EntryPoint = "SetLayeredWindowAttributes")]
    static extern int SetLayeredWindowAttributes(IntPtr hwnd, int crKey, byte bAlpha, int dwFlags);

    [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
    private static extern int SetWindowPos(IntPtr hwnd, int hwndInsertAfter, int x, int y, int cx, int cy, int uFlags);

    [DllImport("Dwmapi.dll")]
    private static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins);

    const int GWL_STYLE = -16;
    const uint WS_POPUP = 0x80000000;
    const uint WS_VISIBLE = 0x10000000;
    const int HWND_TOPMOST = -1;

    void Start()
    {
#if !UNITY_EDITOR // You really don't want to enable this in the editor..
        int fWidth = Screen.width;
        int fHeight = Screen.height;
        var margins = new MARGINS() {cxLeftWidth = -1};
        var hwnd = GetActiveWindow();

        SetWindowLong(hwnd, GWL_STYLE, WS_POPUP | WS_VISIBLE);

        // Transparent windows with click through
        var GWL_EXSTYLE = -20;
        uint WS_EX_LAYERED = 524288; //=&h80000
        uint WS_EX_TRANSPARENT = 32; //=0x00000020L
        SetWindowLong(hwnd, GWL_EXSTYLE, WS_EX_LAYERED | WS_EX_TRANSPARENT);

        var Transparency = 51; //=20%
        var LWA_ALPHA = 2;
        SetLayeredWindowAttributes(hwnd, 0, 255, LWA_ALPHA);

        var SWP_FRAMECHANGED = 32; //0x0020
        var SWP_SHOWWINDOW = 64; //0x0040
        SetWindowPos(hwnd, HWND_TOPMOST, 0, 0, fWidth, fHeight, SWP_FRAMECHANGED | SWP_SHOWWINDOW);

        DwmExtendFrameIntoClientArea(hwnd, ref margins);

#endif
    }

    void OnRenderImage(RenderTexture from, RenderTexture to)
    {
        Graphics.Blit(from, to, m_Material);
    }
}