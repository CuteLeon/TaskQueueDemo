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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.V2StopButton = new System.Windows.Forms.Button();
            this.V2StartButton = new System.Windows.Forms.Button();
            this.V2Enqueuebutton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Enqueuebutton
            // 
            this.Enqueuebutton.Location = new System.Drawing.Point(7, 147);
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
            this.StartButton.Location = new System.Drawing.Point(7, 27);
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
            this.StopButton.Location = new System.Drawing.Point(7, 87);
            this.StopButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(180, 50);
            this.StopButton.TabIndex = 4;
            this.StopButton.Text = "队列停止";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.StopButton);
            this.groupBox1.Controls.Add(this.StartButton);
            this.groupBox1.Controls.Add(this.Enqueuebutton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 212);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "任务队列";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.V2StopButton);
            this.groupBox2.Controls.Add(this.V2StartButton);
            this.groupBox2.Controls.Add(this.V2Enqueuebutton);
            this.groupBox2.Location = new System.Drawing.Point(218, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 212);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "任务队列V2";
            // 
            // V2StopButton
            // 
            this.V2StopButton.Location = new System.Drawing.Point(7, 87);
            this.V2StopButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.V2StopButton.Name = "V2StopButton";
            this.V2StopButton.Size = new System.Drawing.Size(180, 50);
            this.V2StopButton.TabIndex = 7;
            this.V2StopButton.Text = "队列停止";
            this.V2StopButton.UseVisualStyleBackColor = true;
            this.V2StopButton.Click += new System.EventHandler(this.V2StopButton_Click);
            // 
            // V2StartButton
            // 
            this.V2StartButton.Location = new System.Drawing.Point(7, 27);
            this.V2StartButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.V2StartButton.Name = "V2StartButton";
            this.V2StartButton.Size = new System.Drawing.Size(180, 50);
            this.V2StartButton.TabIndex = 6;
            this.V2StartButton.Text = "队列启动";
            this.V2StartButton.UseVisualStyleBackColor = true;
            this.V2StartButton.Click += new System.EventHandler(this.V2StartButton_Click);
            // 
            // V2Enqueuebutton
            // 
            this.V2Enqueuebutton.Location = new System.Drawing.Point(7, 147);
            this.V2Enqueuebutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.V2Enqueuebutton.Name = "V2Enqueuebutton";
            this.V2Enqueuebutton.Size = new System.Drawing.Size(180, 50);
            this.V2Enqueuebutton.TabIndex = 5;
            this.V2Enqueuebutton.Text = "入队 10 个任务";
            this.V2Enqueuebutton.UseVisualStyleBackColor = true;
            this.V2Enqueuebutton.Click += new System.EventHandler(this.V2Enqueuebutton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(432, 233);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "开始";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Enqueuebutton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button V2StopButton;
        private System.Windows.Forms.Button V2StartButton;
        private System.Windows.Forms.Button V2Enqueuebutton;
    }
}

