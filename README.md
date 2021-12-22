

# CSharp-Samples
This repository contains sample applications built with the CSharp SDK.

## RoutingAppTest
This test application use the routing service and listen events. 
The user enters his login, password and the O2G server address and a routing application is displayed.

![enter image description here](https://github.com/ALE-OPENNESS/CSharp-Samples/blob/main/RoutingAppTest/RoutingApp.png?raw=true)

The user can then:
 - Activate a forward
 - Configure the overflow
 - Activate the Do Not Disturb

## Incidents
Incidents is a sample application that loads an OmniPCX Enterprise incidents. It requires an administrative O2G account.

![enter image description here](https://github.com/ALE-OPENNESS/CSharp-Samples/blob/main/Incidents/Incident.png?raw=true)

You have to specify the O2G server address and the account credential in Main.cs
```c#
        private async void Main_Load(object sender, EventArgs e)
        {
            myApplication.SetHost(new()
            {
                PrivateAddress = _o2g_server_address_
            });
            await myApplication.LoginAsync(_o2g_admin_login_, _o2g_admin_password_);
```
