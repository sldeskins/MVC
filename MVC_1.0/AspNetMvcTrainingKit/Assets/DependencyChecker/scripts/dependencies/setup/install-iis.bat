@ECHO OFF
ECHO Installing IIS 7, please wait...

REM ServerManagerCmd -install web-server -allsubfeatures

start /w pkgmgr /iu:IIS-WebServerRole;WAS-WindowsActivationService;WAS-ProcessModel