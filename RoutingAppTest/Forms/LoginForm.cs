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
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RoutingAppTest
{
    public partial class FormLogin : Form
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private O2G.Application _routingApplication = new("SimpleRouting");


        public FormLogin()
        {
            InitializeComponent();
            buttonLogin.Enabled = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            LoginFormData data = JsonConfigFile.Load();
            if (data != null)
            {
                tbServer.Text = data.ServerAddress;
                tbLogin.Text = data.Login;
                tbPassword.Text = data.Password;
                checkBoxRememberMe.Checked = data.RememberMe;

                EnableLoginButton();
            }
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            labelMessage.Text = "Connecting ... please wait";
            labelMessage.ForeColor = Color.Blue;
            labelMessage.Visible = true;

            JsonConfigFile.Save(new()
            {
                ServerAddress = tbServer.Text,
                Login = tbLogin.Text,
                Password = tbPassword.Text,
                RememberMe = checkBoxRememberMe.Checked
            });

            try
            {
                _routingApplication.SetHost(new()
                {
                    PrivateAddress = tbServer.Text
                }, null);

                // Login to the O2G server
                await _routingApplication.LoginAsync(tbLogin.Text, tbPassword.Text);

                RoutingForm routingForm = new(_routingApplication);

                routingForm.Visible = true;
                Visible = false;
            }
            catch (O2GAuthenticationException)
            {
                labelMessage.Text = "Unable to authenticate";
                labelMessage.Visible = true;
            }
        }

        private static void HandleEvent(O2GEvent o2gEvent)
        {
            logger.Trace("HandleEvent " + o2gEvent.EventName);
        }

        private void tbServer_TextChanged(object sender, EventArgs e)
        {
            EnableLoginButton();
        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            EnableLoginButton();
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            EnableLoginButton();
        }

        private void EnableLoginButton()
        {
            buttonLogin.Enabled = (tbServer.Text != "") && (tbLogin.Text != "") && (tbPassword.Text != "");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
