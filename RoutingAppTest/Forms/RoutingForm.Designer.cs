/*
* Copyright 2021 ALE International
*
* Permission is hereby granted, free of charge, to any person obtaining a copy of this 
* software and associated documentation files (the "Software"), to deal in the Software 
* without restriction, including without limitation the rights to use, copy, modify, merge, 
* publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons 
* to whom the Software is furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in all copies or 
* substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING 
* BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
* NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
* DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

namespace RoutingAppTest
{
    partial class RoutingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.labelCompanyPhone = new System.Windows.Forms.Label();
            this.labelVoiceMail = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.forwardControl = new RoutingAppTest.ForwardControl();
            this.overflowControl = new RoutingAppTest.OverflowControl();
            this.cbDnd = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelName.Location = new System.Drawing.Point(15, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(219, 46);
            this.labelName.TabIndex = 13;
            this.labelName.Text = "SIP Ext 1001";
            // 
            // labelCompanyPhone
            // 
            this.labelCompanyPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCompanyPhone.AutoSize = true;
            this.labelCompanyPhone.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCompanyPhone.Location = new System.Drawing.Point(3, 0);
            this.labelCompanyPhone.Name = "labelCompanyPhone";
            this.labelCompanyPhone.Size = new System.Drawing.Size(92, 46);
            this.labelCompanyPhone.TabIndex = 14;
            this.labelCompanyPhone.Text = "1001";
            this.labelCompanyPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVoiceMail
            // 
            this.labelVoiceMail.AutoSize = true;
            this.labelVoiceMail.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelVoiceMail.Location = new System.Drawing.Point(18, 110);
            this.labelVoiceMail.Name = "labelVoiceMail";
            this.labelVoiceMail.Size = new System.Drawing.Size(162, 32);
            this.labelVoiceMail.TabIndex = 15;
            this.labelVoiceMail.Text = "No Voice mail";
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelStatus.Location = new System.Drawing.Point(101, 10);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(93, 25);
            this.labelStatus.TabIndex = 17;
            this.labelStatus.Text = "In Service";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelCompanyPhone);
            this.flowLayoutPanel1.Controls.Add(this.labelStatus);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 58);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(332, 52);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // forwardControl
            // 
            this.forwardControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.forwardControl.Location = new System.Drawing.Point(14, 155);
            this.forwardControl.Name = "forwardControl";
            this.forwardControl.Size = new System.Drawing.Size(496, 41);
            this.forwardControl.TabIndex = 19;
            this.forwardControl.Visible = false;
            this.forwardControl.Cancel += new System.EventHandler(this.forwardControl_Cancel);
            this.forwardControl.Configure += new System.EventHandler(this.forwardControl_Configure);
            // 
            // overflowControl
            // 
            this.overflowControl.Location = new System.Drawing.Point(14, 193);
            this.overflowControl.Name = "overflowControl";
            this.overflowControl.Size = new System.Drawing.Size(444, 39);
            this.overflowControl.TabIndex = 21;
            this.overflowControl.Visible = false;
            this.overflowControl.Cancel += new System.EventHandler(this.overflowControl_Cancel);
            this.overflowControl.Configure += new System.EventHandler(this.overflowControl_Configure);
            // 
            // cbDnd
            // 
            this.cbDnd.AutoSize = true;
            this.cbDnd.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbDnd.Location = new System.Drawing.Point(18, 238);
            this.cbDnd.Name = "cbDnd";
            this.cbDnd.Size = new System.Drawing.Size(127, 24);
            this.cbDnd.TabIndex = 22;
            this.cbDnd.Text = "Do not disturb";
            this.cbDnd.UseVisualStyleBackColor = true;
            this.cbDnd.Visible = false;
            this.cbDnd.CheckedChanged += new System.EventHandler(this.cbDnd_CheckedChanged);
            // 
            // RoutingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 334);
            this.Controls.Add(this.cbDnd);
            this.Controls.Add(this.overflowControl);
            this.Controls.Add(this.forwardControl);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labelVoiceMail);
            this.Controls.Add(this.labelName);
            this.Name = "RoutingForm";
            this.Text = "TelephonyHelperForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoutingForm_FormClosing);
            this.Load += new System.EventHandler(this.RoutingForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelCompanyPhone;
        private System.Windows.Forms.Label labelVoiceMail;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ForwardControl forwardControl;
        private OverflowControl overflowControl;
        private System.Windows.Forms.CheckBox cbDnd;
    }
}