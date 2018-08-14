namespace TaskQueueDemo
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Enqueuebutton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Enqueuebutton
            // 
            this.Enqueuebutton.Location = new System.Drawing.Point(22, 134);
            this.Enqueuebutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Enqueuebutton.Name = "Enqueuebutton";
            this.Enqueuebutton.Size = new System.Drawing.Size(180, 50);
            this.Enqueuebutton.TabIndex = 2;
            this.Enqueuebutton.Text = "入队 10 个任务";
            this.Enqueuebutton.UseVisualStyleBackColor = true;
            this.Enqueuebutton.Click += new System.EventHandler(this.Enqueuebutton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(22, 14);
            this.StartButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(180, 50);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "队列启动";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(22, 74);
            this.StopButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(180, 50);
            this.StopButton.TabIndex = 4;
            this.StopButton.Text = "队列停止";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(228, 295);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.Enqueuebutton);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "开始";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Enqueuebutton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
    }
}

