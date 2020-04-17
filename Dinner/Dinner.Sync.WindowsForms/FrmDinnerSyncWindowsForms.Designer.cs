namespace Dinner.Sync.WindowsForms
{
    partial class FrmDinnerSyncWindowsForms
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
            this.btnMakeDinner = new System.Windows.Forms.Button();
            this.btnWachingTV = new System.Windows.Forms.Button();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMakeDinner
            // 
            this.btnMakeDinner.Location = new System.Drawing.Point(65, 25);
            this.btnMakeDinner.Name = "btnMakeDinner";
            this.btnMakeDinner.Size = new System.Drawing.Size(75, 23);
            this.btnMakeDinner.TabIndex = 0;
            this.btnMakeDinner.Text = "식사 준비";
            this.btnMakeDinner.UseVisualStyleBackColor = true;
            this.btnMakeDinner.Click += new System.EventHandler(this.btnMakeDinner_Click);
            // 
            // btnWachingTV
            // 
            this.btnWachingTV.Location = new System.Drawing.Point(248, 24);
            this.btnWachingTV.Name = "btnWachingTV";
            this.btnWachingTV.Size = new System.Drawing.Size(75, 23);
            this.btnWachingTV.TabIndex = 1;
            this.btnWachingTV.Text = "TV 보기";
            this.btnWachingTV.UseVisualStyleBackColor = true;
            this.btnWachingTV.Click += new System.EventHandler(this.btnWachingTV_Click);
            // 
            // lblDisplay
            // 
            this.lblDisplay.AutoSize = true;
            this.lblDisplay.Location = new System.Drawing.Point(63, 67);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(0, 12);
            this.lblDisplay.TabIndex = 2;
            // 
            // FrmDinnerSyncWindowsForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 118);
            this.Controls.Add(this.lblDisplay);
            this.Controls.Add(this.btnWachingTV);
            this.Controls.Add(this.btnMakeDinner);
            this.Name = "FrmDinnerSyncWindowsForms";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMakeDinner;
        private System.Windows.Forms.Button btnWachingTV;
        private System.Windows.Forms.Label lblDisplay;
    }
}

