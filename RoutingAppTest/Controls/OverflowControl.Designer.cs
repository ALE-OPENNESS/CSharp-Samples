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
    partial class OverflowControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelNoForward = new System.Windows.Forms.Label();
            this.forwardIcon = new System.Windows.Forms.PictureBox();
            this.labelCondition = new System.Windows.Forms.Label();
            this.buttonCancel = new RoutingAppTest.ReactiveButtonImage();
            this.buttonConfigure = new RoutingAppTest.ReactiveButtonImage();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.forwardIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelTitle);
            this.flowLayoutPanel1.Controls.Add(this.labelNoForward);
            this.flowLayoutPanel1.Controls.Add(this.forwardIcon);
            this.flowLayoutPanel1.Controls.Add(this.labelCondition);
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Controls.Add(this.buttonConfigure);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(519, 32);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(0, 5);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(72, 20);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "Overflow:";
            // 
            // labelNoForward
            // 
            this.labelNoForward.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelNoForward.AutoSize = true;
            this.labelNoForward.Location = new System.Drawing.Point(75, 5);
            this.labelNoForward.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.labelNoForward.Name = "labelNoForward";
            this.labelNoForward.Size = new System.Drawing.Size(91, 20);
            this.labelNoForward.TabIndex = 2;
            this.labelNoForward.Text = "No overflow";
            // 
            // forwardIcon
            // 
            this.forwardIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.forwardIcon.Image = global::RoutingAppTest.Properties.Resources.forward_number;
            this.forwardIcon.Location = new System.Drawing.Point(166, 3);
            this.forwardIcon.Margin = new System.Windows.Forms.Padding(0);
            this.forwardIcon.Name = "forwardIcon";
            this.forwardIcon.Size = new System.Drawing.Size(44, 25);
            this.forwardIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.forwardIcon.TabIndex = 0;
            this.forwardIcon.TabStop = false;
            // 
            // labelCondition
            // 
            this.labelCondition.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCondition.AutoSize = true;
            this.labelCondition.Location = new System.Drawing.Point(215, 5);
            this.labelCondition.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelCondition.Name = "labelCondition";
            this.labelCondition.Size = new System.Drawing.Size(149, 20);
            this.labelCondition.TabIndex = 1;
            this.labelCondition.Text = "on busy or no answer";
            this.labelCondition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Image = global::RoutingAppTest.Properties.Resources.cross_cancel_normal;
            this.buttonCancel.ImageActive = global::RoutingAppTest.Properties.Resources.cross_cancel_active;
            this.buttonCancel.ImageDisabled = global::RoutingAppTest.Properties.Resources.cross_cancel_disabled;
            this.buttonCancel.ImageNormal = global::RoutingAppTest.Properties.Resources.cross_cancel_normal;
            this.buttonCancel.Location = new System.Drawing.Point(372, 3);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(25, 25);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonConfigure
            // 
            this.buttonConfigure.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonConfigure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConfigure.FlatAppearance.BorderSize = 0;
            this.buttonConfigure.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.buttonConfigure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfigure.Image = RoutingAppTest.Properties.Resources.config_normal;
            this.buttonConfigure.ImageActive = RoutingAppTest.Properties.Resources.config_active;
            this.buttonConfigure.ImageDisabled = RoutingAppTest.Properties.Resources.config_disabled;
            this.buttonConfigure.ImageNormal = RoutingAppTest.Properties.Resources.config_normal;
            this.buttonConfigure.Location = new System.Drawing.Point(400, 3);
            this.buttonConfigure.Name = "buttonConfigure";
            this.buttonConfigure.Size = new System.Drawing.Size(25, 25);
            this.buttonConfigure.TabIndex = 6;
            this.buttonConfigure.UseVisualStyleBackColor = true;
            this.buttonConfigure.Click += new System.EventHandler(this.buttonConfigure_Click);
            // 
            // OverflowControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "OverflowControl";
            this.Size = new System.Drawing.Size(528, 41);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.forwardIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox forwardIcon;
        private System.Windows.Forms.Label labelCondition;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelNoForward;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label labelTitle;
        private ReactiveButtonImage buttonConfigure;
        private ReactiveButtonImage buttonCancel;
    }
}
