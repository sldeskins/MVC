setlocal 
cd %~dp0

@echo off

SET curPath=%CD%


@REM  -------------------------------------------------------------
@REM  You can change server and database name here.
@REM  -------------------------------------------------------------
SET sqlServer=%1%
if "%1%"=="" set sqlServer=default

SET databaseName=%2%
if "%2%"=="" set databaseName=AdventureWorksLT

SET alias=%3%
if "%3%"=="" set alias=AspNetMvcLabs

SET msbuild=%WINDIR%\Microsoft.NET\Framework\v2.0.50727\msbuild.exe
if exist "%msbuild%" goto compileok

SET msbuild=%WINDIR%\Microsoft.NET\Framework\v3.5\msbuild.exe
if exist "%msbuild%" goto compileok
goto error

:compileok

echo.
echo ========================================
echo Building tools
echo ========================================
echo.

%msbuild% /verbosity:quiet ..\..\Util\Tools.sln

echo.
echo ========================================
echo Creating database alias 
echo   Database: %databaseName%
echo   Server: %sqlServer%
echo   Alias: %alias%
echo ========================================
echo.

echo IN PROGRESS: Creating database alias
..\..\Util\bin\AliasDatabaseServer %sqlServer% %alias%
IF NOT ERRORLEVEL 0 GOTO error
echo SUCCESS: database alias created successfully!

GOTO FINISH

:error
echo.
echo ======================================
echo An error occured. 
echo Please review messages above.
echo ======================================

:FINISH
