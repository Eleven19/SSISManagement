@echo off
cls

IF EXIST deployables\SSISConsole\SSISConsole.exe (
	echo "Executing from deployables folder"
	.\deployables\SSISConsole\SSISConsole.exe %*		
) else (
	IF EXIST src\SSISConsole\bin\Debug\SSISConsole.exe (
		echo "Executing from Debug folder"
		.\src\SSISConsole\bin\Debug\SSISConsole.exe %*		
	) else (
		echo "Executing from Release folder"
		.\src\SSISConsole\bin\Release\SSISConsole.exe %*		
	)
)
if errorlevel 1 (
  exit /b %errorlevel%
)