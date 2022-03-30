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

using o2g;
using o2g.Events;
using o2g.Events.Routing;
using o2g.Events.Telephony;
using o2g.Types.RoutingNS;
using o2g.Types.TelephonyNS.DeviceNS;
using o2g.Types.UsersNS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoutingAppTest
{
    public partial class RoutingForm : Form
    {
        private delegate void SafeSetRoutingStateDelegate(RoutingState routingState);
        private delegate void SafeSetDeviceStateDelegate(DeviceState deviceState);

        private OperationalState OperationalState;
        private RoutingState RoutingState;
        private User User;

        private O2G.Application _o2gApp;

        public RoutingForm(O2G.Application o2gApp)
        {
            this._o2gApp = o2gApp;
            InitializeComponent();
        }

        internal async Task LoadFromServer()
        {
            // Load the user information
            IUsers usersService = _o2gApp.UsersService;
            User = await usersService.GetByLoginNameAsync(_o2gApp.LoginName);

            // Initialize data
            labelName.Text = string.Format("{0} {1}", User.FirstName, User.LastName).Trim();
            labelCompanyPhone.Text = User.CompanyPhone;

            if (User.Voicemail != null)
            {
                labelVoiceMail.Text = string.Format("Voice mail : {0}", User.Voicemail.Number);
            }
            else
            {
                labelVoiceMail.Text = "No voice mail";
            }

            // Get the main device state
            ITelephony telephonyService = _o2gApp.TelephonyService;
            DeviceState deviceState = await telephonyService.GetDeviceStateAsync(User.Devices[0].Id);

            SetDeviceState(deviceState);

            IRouting routingService = _o2gApp.RoutingService;
            SetRoutingState(await routingService.GetRoutingStateAsync());

            cbDnd.Checked = RoutingState.DndState.Activate;
            cbDnd.Visible = true;
        }

        public void OnRoutingStateChanged(OnRoutingStateChangedEvent ev)
        {
            if (InvokeRequired)
            {
                var d = new SafeSetRoutingStateDelegate(SetRoutingState);
                Invoke(d, new object[] { ev.RoutingState });
            }
            else
            {
                SetRoutingState(ev.RoutingState);
            }
        }

        private void SetDeviceState(DeviceState deviceState)
        {
            OperationalState = deviceState.State;
            if (OperationalState == OperationalState.InService)
            {
                labelStatus.Text = "In Service";
                labelStatus.ForeColor = Color.Green;
            }
            else
            {
                labelStatus.Text = "Out of service";
                labelStatus.ForeColor = Color.Red;
            }
        }


        private void SetRoutingState(RoutingState routingState)
        {
            try
            {
                RoutingState = routingState;
                forwardControl.Set(RoutingState.Forward);
                overflowControl.Set(RoutingState.Overflow);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            };
        }

        private async void RoutingForm_Load(object sender, EventArgs e)
        {
            Subscription sr = Subscription.Builder.AddRoutingEvents().SetTimeout(0).Build();

            this._o2gApp.RoutingService.RoutingStateChanged += RoutingService_RoutingStateChanged;

            await this._o2gApp.SubscribeAsync(sr);
            await LoadFromServer();
        }

        private void RoutingService_RoutingStateChanged(object sender, O2GEventArgs<OnRoutingStateChangedEvent> e)
        {
            if (InvokeRequired)
            {
                var d = new SafeSetRoutingStateDelegate(SetRoutingState);
                Invoke(d, new object[] { e.Event.RoutingState });
            }
            else
            {
                SetRoutingState(e.Event.RoutingState);
            }
        }

        private async void forwardControl_Cancel(object sender, EventArgs e)
        {
            IRouting routingService = _o2gApp.RoutingService;
            await routingService.CancelForwardAsync();
        }

        private async void forwardControl_Configure(object sender, EventArgs e)
        {
            ForwardForm formForward = new ForwardForm(RoutingState.Forward);
            DialogResult result = formForward.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                Forward newForward = formForward.Forward;

                // OK apply forward
                if (newForward.Destination == Destination.VoiceMail)
                {
                    await _o2gApp.RoutingService.ForwardOnVoiceMailAsync(newForward.Condition.Value);
                }
                else if (newForward.Destination == Destination.Number)
                {
                    await _o2gApp.RoutingService.ForwardOnNumberAsync(newForward.Number, newForward.Condition.Value);
                }
                else
                {
                    await _o2gApp.RoutingService.CancelForwardAsync();
                }
            }
        }

        private async void overflowControl_Cancel(object sender, EventArgs e)
        {
            await _o2gApp.RoutingService.CancelOverflowAsync();
        }

        private async void overflowControl_Configure(object sender, EventArgs e)
        {
            OverflowForm formOverflow = new OverflowForm(RoutingState.Overflow);
            DialogResult result = formOverflow.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                Overflow newOverflow = formOverflow.Overflow;

                // OK apply Overflow
                if (newOverflow.Destination == Destination.VoiceMail)
                {
                    await _o2gApp.RoutingService.OverflowOnVoiceMailAsync(newOverflow.Condition.Value);
                }
                /*
                else if (newOverflow.Destination == Destination.Associate)
                {
                    await _o2gApp.RoutingService.OverflowOnAssociateAsync(newOverflow.Condition.Value);
                }
                */
                else
                {
                    await _o2gApp.RoutingService.CancelOverflowAsync();
                }
            }
        }

        private async void cbDnd_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDnd.Checked)
            {
                if (!await _o2gApp.RoutingService.ActivateDndAsync())
                {
                    cbDnd.Checked = false;
                }
            }
            else
            {
                if (!await _o2gApp.RoutingService.CancelDndAsync())
                {
                    cbDnd.Checked = true;
                }
            }
        }

        public void OnDeviceStateModified(OnDeviceStateModifiedEvent ev)
        {
            List<DeviceState> deviceStates = ev.DeviceStates;
            DeviceState deviceState = deviceStates[0];

            if (InvokeRequired)
            {
                var d = new SafeSetDeviceStateDelegate(SetDeviceState);
                Invoke(d, new object[] { deviceState });
            }
            else
            {
                SetDeviceState(deviceState);
            }
        }

        private async void RoutingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            await _o2gApp.ShutdownAsync();
        }
    }

}
