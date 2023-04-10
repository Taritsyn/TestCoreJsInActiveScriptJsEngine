@echo off
setlocal

::--------------------------------------------------------------------------------
:: Build
::--------------------------------------------------------------------------------

echo Installing Node.js packages ...
echo.
call npm install
if errorlevel 1 goto error
echo.

echo Resolving modules ...
echo.
call npx rollup -c modules-resolution.config.js --bundleConfigAsCjs
if errorlevel 1 goto error
echo.

::--------------------------------------------------------------------------------
:: Exit
::--------------------------------------------------------------------------------

echo Succeeded!
goto exit

:error
echo *** Error: The previous step failed!

:exit
cd ../../
endlocal