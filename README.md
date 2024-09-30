# TO INSTALL
1. Ensure IIS is enabled. Go to Control Panel > Programs > Turn Windows features on or off. Select "Internet Information Services" and click OK
2. Open IIS from the Windows Start Menu
3. In the navigation tree on the left, expand the menu for your PC. Right click Sites and click Add New Website.
4. Create a unique identifying name for the website and point the path to TechnologyOne_Number_To_Text\bin\Release\net8.0\publish
5. Change the binding to https and adjust the port to an unused port
6. Under SSL Certificate, select IIS Express Development Certificate
7. Check the Start Website Immediately box and click OK.
8. Using the navigation bar on the right, click "Browse *:(port_you_selected)", the website should open in your default web browser

# Troubleshooting
- If you have the error ASP.NET: HTTP Error 500.19 – Internal Server Error 0x8007000d, you may need to install the .NET Core Hosting Bundle from https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/hosting-bundle?view=aspnetcore-8.0
- 
