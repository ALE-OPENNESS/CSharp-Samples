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
using o2g.Types.AnalyticsNS;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Incidents
{
    public partial class Main : Form
    {
        private O2G.Application myApplication = new("Incidents");

        public Main()
        {
            InitializeComponent();
        }

        private async void LoadDataFromOXE()
        {
            IAnalytics analyticService = myApplication.AnalyticsService;

            List<Incident> incidents = await analyticService.GetIncidentsAsync(7);
            if (incidents != null)
            {
                foreach (Incident incident in incidents)
                {
                    dataGridView1.Rows.Add(new Object[]
                    {
                        incident.Id,
                        incident.Date,
                        incident.Severity,
                        incident.Description
                    });
                }
            }
            else
            {
                MessageBox.Show("Unable to retrieve incidents, maybe the OmniPCX Enterprise is not secured. Please check O2G configuration and preequisites to use the Analytics service", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void Main_Load(object sender, EventArgs e)
        {
            myApplication.SetHost(new()
            {
                PrivateAddress = "enter_the_o2g_server_address"
            });

            try
            {
                await myApplication.LoginAsync("_admin_login_name", "_admin_login_paswword");


                dataGridView1.ColumnCount = 4;
                dataGridView1.Columns[0].Name = "Incident";
                dataGridView1.Columns[0].ValueType = typeof(int);

                dataGridView1.Columns[1].Name = "Date";
                dataGridView1.Columns[1].ValueType = typeof(DateTime);

                dataGridView1.Columns[2].Name = "Severity";
                dataGridView1.Columns[2].ValueType = typeof(int);

                dataGridView1.Columns[3].Name = "Description";

                LoadDataFromOXE();
            }
            catch (O2GException ex)
            {
                MessageBox.Show("Unable to connect. Please check O2G configuration",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
        private async void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            await myApplication.ShutdownAsync();
        }
        */
    }
}
