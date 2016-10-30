@ECHO	OFF
REM  	UPDATE NUGET PACKAGE

SET	MSB="C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe"

MKDIR 	nuget\build>nul
MKDIR	nuget\lib\portable-net45+netcore45+win8+wp8+MonoAndroid+Xamarin.iOS10+MonoTouch>nul

%MSB%	Insider\Insider.csproj /property:Configuration=Release;OutDir=..\nuget>nul
%MSB%	Insider.Portable\Insider.Portable.csproj /property:Configuration=Release;OutDir=..\nuget\lib>nul

COPY	Insider.nuspec nuget>nul
COPY	Insider.targets nuget\build>nul
COPY	nuget\lib\Insider.Portable\*.* "nuget\lib\portable-net45+netcore45+win8+wp8+MonoAndroid+Xamarin.iOS10+MonoTouch">nul
RMDIR	nuget\lib\Insider.Portable /S /Q>nul

NUGET	pack nuget\Insider.nuspec  -OutputDirectory .>nul
RMDIR	nuget /S /Q>nul