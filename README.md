# WeatherConsoleApp

Clone the Project in C drive.

Installation:-

1) Go to the file explorer and open C:/WeatherConsoleApp/WeatherConsoleApp folder.
2) Open cmd from that folder.
3) Run command- dotnet pack
4) Run command- dotnet tool install --global --add-source ./nupkg WeatherConsoleApp

Installation finised.

note: for uninstallation run- dotnet tool uninstall -g WeatherConsoleApp

Run:-

1) Without Installing the Package
    1) Go to the file explorer and open C:/WeatherConsoleApp/WeatherConsoleApp folder.
    2) Open cmd from that folder.
    3) Run command- dotnet run or dotnet run cityname
    
2) After Installing the Package
    1) Open cmd from anywhere.
    2) Run Command- weatherapp or weatherapp cityname
