namespace _008
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bee = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pp = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pp)).BeginInit();
            this.SuspendLayout();
            // 
            // bee
            // 
            this.bee.BackColor = System.Drawing.Color.Transparent;
            this.bee.Image = global::_008.Properties.Resources.bee;
            this.bee.Location = new System.Drawing.Point(390, 535);
            this.bee.Name = "bee";
            this.bee.Size = new System.Drawing.Size(120, 125);
            this.bee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bee.TabIndex = 0;
            this.bee.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pp
            // 
            this.pp.BackColor = System.Drawing.Color.Transparent;
            this.pp.Image = global::_008.Properties.Resources.background;
            this.pp.Location = new System.Drawing.Point(0, 0);
            this.pp.Name = "pp";
            this.pp.Size = new System.Drawing.Size(909, 660);
            this.pp.TabIndex = 1;
            this.pp.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::_008.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(904, 661);
            this.Controls.Add(this.pp);
            this.Controls.Add(this.bee);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bee;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pp;


    }
}

