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
using RoutingAppTest.Util;
using o2g.Types.RoutingNS;
using System;
using System.Windows.Forms;

namespace RoutingAppTest
{
    public partial class ForwardForm : Form
    {
        public Forward Forward { get; private set; }

        public ForwardForm(Forward forward)
        {
            this.Forward = forward;
            InitializeComponent();
        }

        private void ActivateNumber()
        {
            cbCondition.Enabled = true;
            tbNumber.Enabled = true;
        }

        private void ActivateVoiceMail()
        {
            cbCondition.Enabled = true;
            tbNumber.Enabled = false;
        }

        private void ActivateNone()
        {
            cbCondition.Enabled = false;
            tbNumber.Enabled = false;
        }

        private void rbNone_CheckedChanged(object sender, EventArgs e)
        {
            ActivateNone();
            EnableApplyButton();
        }

        private void rbVoiceMail_CheckedChanged(object sender, EventArgs e)
        {
            ActivateVoiceMail();
            EnableApplyButton();
        }

        private void rbNumber_CheckedChanged(object sender, EventArgs e)
        {
            ActivateNumber();
            EnableApplyButton();
        }

        private void tbNumber_TextChanged(object sender, EventArgs e)
        {
            EnableApplyButton();
        }

        private void EnableApplyButton()
        {
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (rbNone.Checked)
            {
                Forward = new()
                {
                    Destination = Destination.None,
                    Number = null,
                    Condition = null
                };
            }
            else if (rbVoiceMail.Checked)
            {
                Forward = new()
                {
                    Destination = Destination.VoiceMail,
                    Number = null,
                    Condition = EnumUtil.GetForwardCondition(cbCondition.SelectedIndex)
                };
            }
            else
            {
                Forward = new()
                {
                    Destination = Destination.Number,
                    Number = tbNumber.Text,
                    Condition = EnumUtil.GetForwardCondition(cbCondition.SelectedIndex)
                };
            }
        }

        private void ForwardForm_Load(object sender, EventArgs e)
        {
            if (Forward != null)
            {
                if (Forward.Destination == Destination.VoiceMail)
                {
                    rbVoiceMail.Checked = true;
                }
                else if (Forward.Destination == Destination.Number)
                {
                    rbNumber.Checked = true;
                }
                else
                {
                    rbNone.Checked = true;
                }

                cbCondition.SelectedIndex = EnumUtil.IndexOf(Forward.Condition);
                tbNumber.Text = Forward.Number;
            }
            else
            {
                cbCondition.SelectedIndex = 0;
            }
        }
    }
}
