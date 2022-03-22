# Shell

## Before GUI (BG)
Before the days of pretty icons but after the days of feeding cards to the machine, we used a text based system called terminal or command line interpreter (CLI) to interact with the computers. 

Instead of pointing and clicking on icons to tell the computer to get to this folder or to open a file, we used text based commands to execute same actions. 

GUI, graphical user interface, was introduced in 1970's and since then, overtook command line and became the default user interface because it was much easier to learn and use. GUI accelerated the adoption of computers to the general population because it sharply reduced the learning curve.

However, command line interface, or terminal, is still alive and well because it offers much more robust feature set and allow better control than GUI. Also there are certain softwares that does not have GUI and you can only interact with them via cli!

## What is Shell?

Shell is a command line interface built for Unix/Linux system. Unix was one of the first operating system to be developed and many modern OS's derive from it, such as macOS and Linux.

Shell allows Unix based OS users to interact with their machines in very powerful way. Knowledge of shell is essential for linux users because many softwares built for linux does not have GUI or even if they do, it is rather lackluster compared to the GUI's of macOS or Windows.

## What is Bash?
Bash stands for bourne again shell, and it is one of the most popular flavors of shell currently in use. By utilizing bash cli commands, we can do everyday computing tasks and more without the GUI! 

### Bash Vocabulary
- directory: This is equivalent to folder
- ```/```: Root directory. The top most directory is always ```/```
- ```~```: Home directory. This is usually the one with your account name. Note that you can change this in your profile setting.
- ```.```: Current directory
- ```..```: Parent directory to where you're currently at. (One level up)
- path: another way of saying how do you get to that directory? There are two types of path, relative and absolute
    - relative path: how to get to that directory from where you're at right now.
    - absolute path: how to get to that directory from the root directory

### Commonly Used Bash Commands
- ```cd```
    - **C**hange **D**irectory
    - use this command to navigate from one directory (or folder) to another.
- ```echo```
    - *Echoes* whatever it's been given to the console. Similar to println in Java or Console.WriteLine in C#
- ```nano```
    - One of the most popular text editors in bash. Use this command with an existing file to edit the file or without a file name to open an empty text editor
- ```grep```
    - searches for pattern in each file
- ```touch```
    - *Touches* the file such that the access and modification time is updated to the current time.
    - Though this is more often used for creating an empty file.
- ```ls```
    - **L**i**s**ts content of a directory
    - By default (without any arguments), it lists the content of the current directory)
- ```which```
    - Writes the full path of command(s) to the console (which bash is this??)
- ```find```
    - ```ls``` on a steroid
    - Lists absolute paths of files and folders, recursively. This is particularly powerful when paired with filter to selectively display the result.
- ```pwd```
    - **P**resent **W**orking **D**irectory
    - Displays the absolute path of the current directory you're at
- ```mkdir```
    - **M**a**k**e **Dir**ectory
    - Creates one or more new directory if they do not exist already
- ```cat```
    - Con**cat**enates files to the console, aka, displays the content of the file on the console. Very handy if you want to quickly view the content of the file without opening up a text editor
- ```rm```
    - **R**e**m**oves selected files/directories. Note that this does not move the file to Recycle Bin, so this is not reversible by normal means.

## Flags (or Options)
Cli commands often times accept additional optional parameters. We use flags, or options, to specify these optional behaviors.
    
### Examples of options
- ```-help```: Displays the help message of how to use the command. Very handy.
- ```ls```
    - ```-a```: Displays all files and directories, including hidden ones
    - ```-l```: Display the content of a folder in long form (which includes)
- ```rm```
    - ```-r```: Recursively deletes all contents. This is required if you want to delete a directory.

## Emulators
Bash is a shell. Shell is a terminal interface for Linux. Since we want to use Bash in Windows, we tap into other softwares to emulate Bash in other non-Unix operating system. There are multiple ways to do this, the most robust one being using WSL (Windows Subsystem Linux), but we will use Git for Windows' git-bash as our primary bash emulator.  

## Tips and Tricks
- Use the autocomplete! Bash's autocomplete is very powerful and will save you a lot of typing. Use it to...
    - Complete the file name for you
    - Display the content of the folder if you're in the middle of typing out a path
    - and way more...
