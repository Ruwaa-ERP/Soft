namespace RuwaaSoft.Desktop.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblWelcome;
        private System.Windows.Forms.ToolStripStatusLabel lblRole;
        private System.Windows.Forms.ToolStripStatusLabel lblDateTime;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Timer timer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblWelcome = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblWelcome,
            this.lblRole,
            this.lblDateTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 728);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1284, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip";
            
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(100, 17);
            this.lblWelcome.Text = "مرحباً";
            
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(100, 17);
            this.lblRole.Text = "الصلاحية";
            
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(1069, 17);
            this.lblDateTime.Spring = true;
            this.lblDateTime.Text = "التاريخ والوقت";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            this.panelMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelMain.Controls.Add(this.lblMainTitle);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 24);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1284, 704);
            this.panelMain.TabIndex = 1;
            
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblMainTitle.ForeColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.lblMainTitle.Location = new System.Drawing.Point(400, 300);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(484, 45);
            this.lblMainTitle.TabIndex = 0;
            this.lblMainTitle.Text = "نظام مبيعات رؤى سوفت";
            this.lblMainTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 750);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.statusStrip);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نظام مبيعات رؤى سوفت";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
