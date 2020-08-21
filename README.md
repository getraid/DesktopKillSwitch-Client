# DesktopKillSwitch-Client
## How to install
1. Open project in vs and compile
1. Open Developer Command Prompt for VS 2019 in administator mode
2. `cd` into the debug dir (move dir before in place that you like e.g. appdata)
3. `installutil DesktopKillSwitch-Client.exe`
4. Open Services and search for *Desktop Kill Switch* (Remote Node.js) or *DKSC*
5. Rightclick -> Properties -> start type: "automatic" and start service
6. Windows Energie settings -> "Choose what happens when on/off button has been touched" -> Admin icon -> disable fast start
