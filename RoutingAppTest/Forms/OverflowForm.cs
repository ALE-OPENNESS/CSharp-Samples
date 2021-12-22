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
    public partial class OverflowForm : Form
    {
        public Overflow Overflow { get; private set; }

        public OverflowForm(Overflow overflow)
        {
            this.Overflow = overflow;
            InitializeComponent();
        }

        private void ActivateAssociate()
        {
            cbCondition.Enabled = true;
        }

        private void ActivateVoiceMail()
        {
            cbCondition.Enabled = true;
        }

        private void ActivateNone()
        {
            cbCondition.Enabled = false;
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
        private void rbAssociate_CheckedChanged(object sender, EventArgs e)
        {
            ActivateAssociate();
            EnableApplyButton();
        }

        private void EnableApplyButton()
        {
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (rbNone.Checked)
            {
                Overflow = new()
                {
                    Destination = Destination.None,
                    Condition = null
                };
            }
            else if (rbVoiceMail.Checked)
            {
                Overflow = new()
                {
                    Destination = Destination.VoiceMail,
                    Condition = EnumUtil.GetOverflowCondition(cbCondition.SelectedIndex)
                };
            }
            else
            {
                Overflow = new()
                {
                    Destination = Destination.Associate,
                    Condition = EnumUtil.GetOverflowCondition(cbCondition.SelectedIndex)
                };
            }
        }

        private void OverflowForm_Load(object sender, EventArgs e)
        {
            if (Overflow != null)
            {
                if (Overflow.Destination == Destination.VoiceMail)
                {
                    rbVoiceMail.Checked = true;
                }
                else if (Overflow.Destination == Destination.Associate)
                {
                    rbAssociate.Checked = true;
                }
                else
                {
                    rbNone.Checked = true;
                }

                cbCondition.SelectedIndex = EnumUtil.IndexOf(Overflow.Condition);
            }
            else
            {
                cbCondition.SelectedIndex = 0;
            }
        }

    }
}
