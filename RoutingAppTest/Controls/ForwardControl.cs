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
using o2g.Types.RoutingNS;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace RoutingAppTest
{
    public partial class ForwardControl : UserControl
    {
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks the cancel button")]
        public event EventHandler Cancel;

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks the configure button")]
        public event EventHandler Configure;


        public ForwardControl()
        {
            InitializeComponent();
            Visible = false;
        }

        internal void Set(Forward forward)
        {
            Visible = true;
            if ((forward == null) || (forward.Destination == Destination.None))
            {
                labelNoForward.Visible = true;
                forwardIcon.Visible = false;
                labelNumber.Visible = false;
                labelCondition.Visible = false;
                buttonCancel.Visible = false;
                labelNumber.Text = "";
            }
            else
            {
                labelNoForward.Visible = false;
                buttonCancel.Visible = true;
                if (forward.Destination == Destination.Number)
                {
                    forwardIcon.Image = RoutingAppTest.Properties.Resources.forward_number;

                    labelNumber.Text = forward.Number;
                    labelNumber.Visible = true;
                }
                else
                {
                    forwardIcon.Image = RoutingAppTest.Properties.Resources.forward_voicemail;

                    labelNumber.Text = "";
                    labelNumber.Visible = false;
                }
                forwardIcon.Visible = true;

                labelCondition.Text = FormatCondition(forward.Condition.Value);
                labelCondition.Visible = true;
            }

            buttonConfigure.Visible = true;
        }

        private static string FormatCondition(Forward.ForwardCondition condition)
        {
            if (condition == Forward.ForwardCondition.Immediate)
            {
                return "Immediate";
            }
            else if (condition == Forward.ForwardCondition.Busy)
            {
                return "on busy";
            }
            else if (condition == Forward.ForwardCondition.NoAnswer)
            {
                return "on no answer";
            }
            else
            {
                return "on busy or no answer";
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Cancel?.Invoke(this, e);
        }

        private void buttonConfigure_Click(object sender, EventArgs e)
        {
            Configure?.Invoke(this, e);
        }
    }
}
