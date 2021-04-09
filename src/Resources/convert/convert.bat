@echo off
echo [*] Creating dir `out`
mkdir out
echo [*] Starting Convert...
for %%v in (*.png) do magick convert "%%v" "out\%%v.ico"
echo [*] Complete!
pause
