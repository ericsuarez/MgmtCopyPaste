namespace MgmtCopyPaste
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxCurrentClipboard = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelCopied = new System.Windows.Forms.Label();
            this.timerCopied = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBox1.ForeColor = System.Drawing.Color.Lime;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 23;
            this.listBox1.Location = new System.Drawing.Point(12, 50);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(760, 393);
            this.listBox1.TabIndex = 0;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pinToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(120, 52);
            // 
            // pinToolStripMenuItem
            // 
            this.pinToolStripMenuItem.Name = "pinToolStripMenuItem";
            this.pinToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.pinToolStripMenuItem.Text = "Pin";
            this.pinToolStripMenuItem.Click += new System.EventHandler(this.pinToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.clearToolStripMenuItem.Text = "Borrar";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // textBoxCurrentClipboard
            // 
            this.textBoxCurrentClipboard.BackColor = System.Drawing.Color.Black;
            this.textBoxCurrentClipboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCurrentClipboard.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxCurrentClipboard.ForeColor = System.Drawing.Color.Cyan;
            this.textBoxCurrentClipboard.Location = new System.Drawing.Point(12, 12);
            this.textBoxCurrentClipboard.Name = "textBoxCurrentClipboard";
            this.textBoxCurrentClipboard.ReadOnly = true;
            this.textBoxCurrentClipboard.Size = new System.Drawing.Size(760, 31);
            this.textBoxCurrentClipboard.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelCopied
            // 
            this.labelCopied.AutoSize = true;
            this.labelCopied.ForeColor = System.Drawing.Color.Lime;
            this.labelCopied.Location = new System.Drawing.Point(698, 445);
            this.labelCopied.Name = "labelCopied";
            this.labelCopied.Size = new System.Drawing.Size(61, 20);
            this.labelCopied.TabIndex = 2;
            this.labelCopied.Text = "Copied!";
            this.labelCopied.Visible = false;
            this.labelCopied.Click += new System.EventHandler(this.labelCopied_Click);
            // 
            // timerCopied
            // 
            this.timerCopied.Interval = 1000;
            this.timerCopied.Tick += new System.EventHandler(this.timerCopied_Tick);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(784, 474);
            this.Controls.Add(this.textBoxCurrentClipboard);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.labelCopied);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Gestor de Portapapeles";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBoxCurrentClipboard;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.Label labelCopied;
        private System.Windows.Forms.Timer timerCopied;
 
    }
}
