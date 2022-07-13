using System;
using System.Windows.Forms;

public class MoveWindow
{
    private Form form;
    private Control panel;

    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_CAPTION = 0x2;

    [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
    public static extern bool ReleaseCapture();


    public bool Active = true;

    public MoveWindow(Form _form, Control _panel)
    {
        form = _form;
        panel = _panel;

        panel.MouseMove += new MouseEventHandler(MouseMove);
    }

    private void MouseMove(object sender, MouseEventArgs e)
    {
        if (Active)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(form.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }

}

