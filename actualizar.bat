@echo off
echo Hola buen dia!
title Terminal
cd C:\Users\vtore\source\repos\AurocoPublicidad\AurocoPublicidad\AurocoPublicidad.csproj
del C:\Users\vtore\source\repos\AurocoPublicidad\\AurocoPublicidad.sln
rmdir C:\Users\vtore\source\repos\AurocoPublicidad\AurocoPublicidad\obj
git pull origin main
echo Sistema Actualizado corectamente!
pause