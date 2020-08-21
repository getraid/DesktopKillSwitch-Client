# DesktopKillSwitch-Client

![img](docs/icon.png)

A Windows service that upon shutdown sends a network http request to a [server](https://github.com/getraid/DesktopKillSwitch) to kill the electricity after a certain time.

# Requirements

- [DesktopKillSwitch Server](https://github.com/getraid/DesktopKillSwitch)
- Microsoft Windows Operating System (tested on Windows 10 v.1909)
- Hue-Bridge with Hue compatible SmartPlug (see more / the setup on the server page)
- Must be in the same network as the server (resolvable from the OS)
- .NET Framework 4.7.2 (should be included in current Windows updates)

# Install

Download the latest installer from the **[Releases](https://github.com/getraid/DesktopKillSwitch-Client/releases)**  
Make sure to follow through the instructions mentioned in the installer.

Since newer Windows versions a Windows service can only detect a shutdown, when the device is rebooting.  
To allow the service to catch a shutdown, you need to go into the **power plan settings** and disable `Turn on fast startup`.  
This is further described in the installer inself.

In the installation process you will be asked to enter the ip adress and port of the server.

If you leave it empty or write a non-ip/port into it, the service will stop upon starting and leave an error in the Windows event log.

# Info

- Only the http protocol is used.

Feel free to fork and modify the project.

# Remove

You can remove this service with the standard windows app removal panel.

If the program isn't listed, go into you install directory and click the `uninstall.bat`  
This will launch a window that guides you through the removal of the service.

All previously made registy entrys of the program will also be deleted.
