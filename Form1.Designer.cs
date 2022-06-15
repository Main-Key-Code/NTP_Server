
namespace Working_With_NTP_Server
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Run = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tBx_timeserver = new System.Windows.Forms.TextBox();
            this.tBx_TimeLine = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Run
            // 
            this.btn_Run.Location = new System.Drawing.Point(13, 13);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_Run.Size = new System.Drawing.Size(153, 23);
            this.btn_Run.TabIndex = 0;
            this.btn_Run.Text = "Synchronization";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(13, 81);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(776, 357);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // tBx_timeserver
            // 
            this.tBx_timeserver.Location = new System.Drawing.Point(198, 12);
            this.tBx_timeserver.Name = "tBx_timeserver";
            this.tBx_timeserver.Size = new System.Drawing.Size(197, 21);
            this.tBx_timeserver.TabIndex = 2;
            this.tBx_timeserver.Text = "time.windows.com";
            // 
            // tBx_TimeLine
            // 
            this.tBx_TimeLine.Location = new System.Drawing.Point(198, 44);
            this.tBx_TimeLine.Name = "tBx_TimeLine";
            this.tBx_TimeLine.Size = new System.Drawing.Size(100, 21);
            this.tBx_TimeLine.TabIndex = 3;
            this.tBx_TimeLine.Text = "8";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "TimeLine";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBx_TimeLine);
            this.Controls.Add(this.tBx_timeserver);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btn_Run);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox tBx_timeserver;
        private System.Windows.Forms.TextBox tBx_TimeLine;
        private System.Windows.Forms.Label label1;
    }
}

