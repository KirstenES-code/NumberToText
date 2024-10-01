# TO INSTALL
1. Ensure IIS is enabled. Go to Control Panel > Programs > Turn Windows features on or off. Select "Internet Information Services"
2. Expand Internet Information Services > World Wide Web Services > Application Development Features and select ASP.NET 4.8. Click OK
3. Open IIS from the Windows Start Menu
4. In the navigation tree on the left, expand the menu for your PC. Right click Sites and click Add New Website.
5. Create a unique identifying name for the website and point the path to TechnologyOne_Number_To_Text\bin\Release\net8.0\publish
6. Change the binding to https and adjust the port to an unused port
7. Under SSL Certificate, select IIS Express Development Certificate
8. Check the Start Website Immediately box and click OK.
9. Using the navigation bar on the right, click "Browse *:(port_you_selected)", the website should open in your default web browser

# Troubleshooting
- If you have the error ASP.NET: HTTP Error 500.19 – Internal Server Error 0x8007000d, you may need to install the .NET Core Hosting Bundle from https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/hosting-bundle?view=aspnetcore-8.0
- If there is a file permission error (HTTP Error 500.19 - Internal Server Error 0x80070005) you will need to add permission for the IIS user to access the folder requested. In IIS, navigate to the website and click "Edit Permissions..." on the right. Under Security click Edit... then Add... and put "IIS_IUSRS" in the object names to select. Click Check Names then OK, OK, OK
