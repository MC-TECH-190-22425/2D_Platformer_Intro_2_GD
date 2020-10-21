# October 22th 2020

## Adding Speed

To mimick Super Mario Bros we need to add a button to increase speed for our longer jumps.

1. Open the PlayerMovement Script
2. Add
	- ```public float walkingSpeed = 5f```
	- ```public float runningMultiplier = 2f```
	- and remove the 5f value from moveSpeed
3. In ```void ProcessInputs()``` add the following conditionals
	- ```cs
	    if (Input.GetButtonDown("Fire1"))  
        {
            // if the Fire1 button is pressed increase moveSpeed temporarially
            moveSpeed *= runningMultiplier;
        }
		```
	- ```cs
		if (Input.GetButtonUp("Fire1"))
        {
            // when the Fire1 button is released return moveSpeed to it's original value
            moveSpeed = walkingSpeed;
        }
		```
	- Add z as an alternate positive button for **Fire1** in the Axis Controls


## Adding Enemies

## Giving Enemies AI

## Adding PowerUps

## Adding Scene Transitions

## Starting Git from an existing Unity Project

If you start a Unity Project and would like to start GIT after getting started you will need to do a few things to ensure that you successfully implement.

1. Open your project folder
2. Open GitBash (or terminal on Mac)
3. Naviagate to your project folder
	1. `cd` changes directory
	2. `ls` list directory
	3. `dir` list directory
	4. `cd ..` navigate backwards
	5. If you start writing a filename or directory you can press tab to auto complete the name
4. In your project folder type:
	1. `git init`
5. Navigate to your folder in explorer (finder on mac)
6. Create a two new text files in this folder, rename the files to .gitignore and .gitattributes
7. Open .gitignore in notepad (textedit on Mac)
8. In a web browser Google naviagate to https://gist.github.com/SGTMcClain/c581005c613c0adc3a6ab1c060c17c89
9. Click Raw and copy all text from this website and paste into notepad (textedit on Mac)
10. Save .gitignore and close notepad (textedit on Mac)
11. Open .gitattributes in notepad (textedit on Mac)
12. In a web browser Google naviagate to https://gist.github.com/SGTMcClain/4c7c998b946e7798c674107fbe14c2d7
13. Click Raw and copy all text from this website and paste into notepad (textedit on Mac)
14. Save .gitattributes and close notepad (textedit on Mac)

### Camera Movement

Camera movement was provided by a script from unity3diy https://gist.github.com/unity3diy/5aa0b098cb06b3ccbe47 

### Ground Check Code

Ground Check Code inspired by Code Monkey https://www.youtube.com/watch?v=c3iEl5AwUF8