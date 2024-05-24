@echo off
echo Hola buen dia!
title Terminal
del C:\Users\vtore\source\repos\AurocoPublicidad\AurocoPublicidad\AurocoPublicidad.sln
rmdir /s C:\Users\vtore\source\repos\AurocoPublicidad\AurocoPublicidad\obj
S
cd C:\Users\vtore\source\repos\AurocoPublicidad\
git pull origin main
echo Sistema Actualizado corectamente!
pause