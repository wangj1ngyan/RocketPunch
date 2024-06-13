@echo off
setlocal

:: Set the executable name
set EXECUTABLE=PokerShuffle.exe

:: List of source files
set SOURCES=main.cpp Deck.cpp Player.cpp PokerCard.cpp JokerCard.cpp

:: Compile the source files
echo Compiling source files...
g++ -o %EXECUTABLE% %SOURCES%

:: Check if compilation was successful
if %ERRORLEVEL% equ 0 (
    echo Compilation successful.
    echo Running the program...
    :: Run the compiled program
    .\%EXECUTABLE%
) else (
    echo Compilation failed.
)

endlocal
pause
