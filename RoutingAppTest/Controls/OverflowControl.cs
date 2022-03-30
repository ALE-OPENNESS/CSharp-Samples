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
    public partial class OverflowControl : UserControl
    {
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks the cancel button")]
        public event EventHandler Cancel;

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks the configure button")]
        public event EventHandler Configure;


        public OverflowControl()
        {
            InitializeComponent();
            Visible = false;
        }

        internal void Set(Overflow overflow)
        {
            Visible = true;
            if ((overflow == null) || (overflow.Destination == Destination.None))
            {
                labelNoForward.Visible = true;
                forwardIcon.Visible = false;
                labelCondition.Visible = false;
                buttonCancel.Visible = false;
            }
            else
            {
                labelNoForward.Visible = false;
                buttonCancel.Visible = true;
                forwardIcon.Image = RoutingAppTest.Properties.Resources.forward_voicemail;
                /*
                if (overflow.Destination == Destination.Associate)
                {
                    forwardIcon.Image = RoutingAppTest.Properties.Resources.forward_associate;
                }
                else
                {
                    
                }
                */
                forwardIcon.Visible = true;

                labelCondition.Text = FormatCondition(overflow.Condition.Value);
                labelCondition.Visible = true;
            }

            buttonConfigure.Visible = true;
        }

        private static string FormatCondition(Overflow.OverflowCondition condition)
        {
            if (condition == Overflow.OverflowCondition.Busy)
            {
                return "on busy";
            }
            else if (condition == Overflow.OverflowCondition.NoAnswer)
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
