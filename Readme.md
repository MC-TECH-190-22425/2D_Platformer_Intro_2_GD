# October 22th 2020

## Giving Enemies AI
1. Add a rigidbody 2D to the enemy
2. Add a BoxCollider2D to the enemy
2. In the rigidbody property
	1. Expand `Constraints` by clicking the triangle to the right
	2. Check the box next to Freeze Rotation
		1. This will make sure the Enemy doesn't rotate unexpectedly
4. Create a new Tag called `Enviornment`
2. Create a new C# script named `Enemy`
3. Open the Enemy script and remove the Start and Update methods
4. Paste this code:
	```cs
    private Rigidbody2D body;

    [SerializeField]
    private float speed;
    private Vector2 movementDirection;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        movementDirection = Vector2.left; // starts this enemy off moving right
    }

    // Update is called once per frame
    void Update()
    {
        Move(movementDirection);
    }

    public void Move(Vector2 direction)
    {
        movementDirection = direction;
        body.velocity = new Vector2(direction.x * speed, body.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Environment"))
        {
            movementDirection *= -1f;
        }
    }
	```

## Killing the player

## Respawning the player and Restarting the Level

## Adding PowerUps

## Adding Scene Transitions

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
1. From sprites lets bring out another square
2. Change the color of the sprite
3. Change the name from square to Enemy
4. Add an empty gameObject as a child of Enemy
5. Name the gameObject Hitbox
6. Add a BoxCollider2D to the Hitbox
	1. Reduce it's size to .08 on all sides
	2. Make sure that Is Trigger is checked
7. Add a BoxCollider2D to the Enemy
8. With the Hitbox selected click the dropdown next to Tag in the inspector and select "add tag"
9. Add ```Enemy``` to the tag list
10. Select the Enemy tag
11. Open the PlayerMovement Script
12. After IsGrounded() Add
	- ```cs
		void OnTriggerEnter2D(Collider2D collider)
		{
			// Check to see if the player is touching the enemy
			if(collider.CompareTag("Enemy"))
			{
				Debug.Log("The player is touching " + collider.tag );
			}
		}
		```

## Adding UI Elements and introducing the Game Manager
1. Right click in the Hierarchy and add UI -> Text
	1. In the inspector change ```New Text``` to ```Lives = 0```  
2. Create a new script called ```GameManager```
3. Open the GameManager Script
4. Remove the Start() and Update() Methods
5. Add a public lives variable and default it to 3 lives;
	- ```cs
		public int lives = 3;
		```
6. Add an Empty GameObject to the scene and name it GameManager
7. Drag the GameManager Script into the GameManger GameObject
8. Create a new script called UIText
9. Drag the UIText script to the GameManager 
10. Drag ```Text``` from underneath Canvas to the ```Lives Text`` in the GameManager Inspector
11. Open the UIText Script
12. Add
	- ```cs
		public Text livesText;
		private GameObject gameManager;
		private int lives;
		
		void Start()
		{
			gameManager = this.gameObject;
			lives = gameManager.GetComponent<GameManager>().getLives(); 
		}

		void Update()
		{
			lives = gameManager.GetComponent<GameManager>().getLives();
			livesText.text = "Lives = " + lives;
		}
		```

## Killing the player

## Respawning the player and Restarting the Level

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