using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace MgmtCopyPaste;

using Timer = System.Windows.Forms.Timer;

public partial class Form1 : Form
{



    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool UnregisterHotKey(IntPtr hWnd, int id);


    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    public delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
    private const int WH_MOUSE_LL = 14;
    private LowLevelMouseProc _proc;
    private IntPtr _hookID = IntPtr.Zero;
    private const uint MOD_WIN = 0x0008;
    private int clickCount = 0;
    private Timer clickTimer;

    List<string> clipboardItems = new List<string>();
    string lastClipboardText = "";

    public Form1()
    {
        InitializeComponent();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();



        timer.Interval = 500; // cada medio segundo
        timer.Tick += new EventHandler(timer1_Tick);
        timer.Start();

        // 2. Inicializa el Timer y sus eventos
        clickTimer = new Timer();
        clickTimer.Interval = 500;  // 500 milisegundos para contar los clics
        clickTimer.Tick += (sender, e) => { PerformClickAction(); };
        _proc = HookCallback;
        _hookID = SetHook(_proc);

        RegisterHotKey(this.Handle, 1, MOD_WIN, (uint)Keys.LButton); // Win + Click Izquierdo
    }
    public enum MouseMessages
    {
        WM_LBUTTONDOWN = 0x0201,
        WM_LBUTTONUP = 0x0202,
        WM_MOUSEMOVE = 0x0200,
        WM_MOUSEWHEEL = 0x020A,
        WM_RBUTTONDOWN = 0x0204,
        WM_RBUTTONUP = 0x0205
    }

    private IntPtr SetHook(LowLevelMouseProc proc)
    {
        using (Process curProcess = Process.GetCurrentProcess())
        using (ProcessModule curModule = curProcess.MainModule)
        {
            return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
        }
    }

    private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        /*if (Control.ModifierKeys != Keys.None)
        {
            // Imprime el estado de las teclas modificadoras en la ventana de salida si son diferentes de None
            
            Debug.WriteLine("Teclas Modificadoras: " + Control.ModifierKeys);
        }*/

        if (nCode >= 0 && MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
        {
            // Cambio de tecla Win a tecla Shift
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                clickCount++;
                clickTimer.Stop();
                clickTimer.Start();
            }
        }
        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        // Lógica del primer método OnFormClosing
        UnhookWindowsHookEx(_hookID);

        // Lógica del segundo método OnFormClosing
        UnregisterHotKey(this.Handle, 1);

        base.OnFormClosing(e);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        timer1.Interval = 1000; // Cada segundo
        timer1.Start();
        // Registra el evento de clic del mouse en el listBox1
        listBox1.MouseClick += new MouseEventHandler(OnMouseClick);
    }

    private void OnMouseClick(object sender, MouseEventArgs e)
    {
        // Cambio de tecla Win a tecla Shift
        if (Control.ModifierKeys == Keys.Shift)
        {
            clickCount++;
            clickTimer.Stop();
            clickTimer.Start();
        }
    }

    private void PerformClickAction()
    {
        clickTimer.Stop();
        if (clickCount <= listBox1.Items.Count && clickCount > 0)
        {
            // Copia el elemento correspondiente de la lista
            Clipboard.SetText(listBox1.Items[clickCount - 1].ToString());
        }
        clickCount = 0;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        if (Clipboard.ContainsText())
        {
            string clipboardText = Clipboard.GetText();
            textBoxCurrentClipboard.Text = clipboardText;

            // Añade al listBox solo si el texto es nuevo y no está ya en la lista
            if (!listBox1.Items.Contains(clipboardText))
            {
                listBox1.Items.Add(clipboardText);
            }
        }
    }


    private void listBox1_DoubleClick(object sender, EventArgs e)
    {
        if (listBox1.SelectedItem != null)
        {
            string selectedItem = listBox1.SelectedItem.ToString();
            Clipboard.SetText(selectedItem);
        }
        // Mostrar el mensaje y empezar el timer
        this.labelCopied.Visible = true;
        this.timerCopied.Start();
    }

    private void timerCopied_Tick(object sender, EventArgs e)
    {
        // Ocultar el mensaje y detener el timer
        this.labelCopied.Visible = false;
        this.timerCopied.Stop();
    }
    private void pinToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (listBox1.SelectedItem != null)
        {
            var selectedItem = listBox1.SelectedItem;
            listBox1.Items.Remove(selectedItem);
            listBox1.Items.Insert(0, selectedItem);
        }
    }

    private void clearToolStripMenuItem_Click(object sender, EventArgs e)
    {
        listBox1.Items.Clear();
    }

    private void labelCopied_Click(object sender, EventArgs e)
    {

    }

    protected override void WndProc(ref Message m)
    {
        const int WM_HOTKEY = 0x0312;
        switch (m.Msg)
        {
            case WM_HOTKEY:
                clickCount++;
                clickTimer.Stop();
                clickTimer.Start();
                break;
        }
        base.WndProc(ref m);
    }


}
