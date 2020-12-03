# Final Project
## References
- www.google.com : explaination
- www.stackoverflow.com : explaination

# November 12 2020

## Collectables and Scoring
1. Add two new text fields to the Canvas
2. Name them CoinsText and ScoreText
	1. Change the text field to Coins = ? or Score = ? respectfully 
1. Reposition Score and Coins at the top of the screen 
1. Open the GameManager Script and add the following code under `lives`
	``` cs
		[SerializeField]
		private int score;

		[SerializeField]
		private int coins;
	```
1. Add the following code under `getLives()`

	```cs
		public int getScore()
		{
			return this.score;
		}

		public int getCoins()
		{
			return this.coins;
		}

		public void addLife()
		{
			lives++;
		}

		public void addCoin()
		{
			coins++;
			if (coins > 99)
			{
				addLife(); // add an extra life
				coins = 0; // reset coins to zero
			}

		}

		public void addScore(int points)
		{
			score += points;
		}
	```
1. Open the UIText script and add the following under `gameManager`
	```cs
	private int lives;
	private int coins;
	private int score;
	```

1. Add the following after `livesText`
	```cs
	public Text scoreText;
    public Text coinsText;
	```

1. Add the following after `lives = gameManager.GetComponent<GameManager>().getLives();`
	```cs
	coins = gameManager.GetComponent<GameManager>().getCoins();
	score = gameManager.GetComponent<GameManager>().getCoins();
	```

1. Add the following after `livesText.text = "Lives = " + lives;`
	```cs
	coins = gameManager.GetComponent<GameManager>().getCoins();
	coinsText.text = "Coins = " + coins;

	score = gameManager.GetComponent<GameManager>().getScore();
	scoreText.text = "Score = " + score;
	```

1. Back in the Unity inspector highlight the GameManager and drag ScoreText and GameText to the inspector from the hierarcy panel. Your score and coins should now be wired to the UI

1. Add coins to our scene
	1. Got to the sprites folder and bring our square back into the scene
	1. Reduce the size
	1. Change the color
	1. Add a Box Collider 2D
		1. Check Is Trigger
	1. Create a Coin Tag
	1. Add the Coin Tag to the Coin
	1. Create Coin Script in the Scripts folder
	1. Add Coin Script as a components on the coin Game Object
	1. Open the Coin script
		1. Remove `void Start()` and `void Update()` functions
		1. Add the Following inside of `public class Coin : Monobehavior`
			```cs
			// Create a reference for the Game Manager
			private GameManager gameManager;

			// Create a standard score for coins
			[SerializeField]
			int coinPoints = 100;

			// Do these actions when this item is awakened in the scene
			private void Awake()
			{
				// Assign the GameManger in this scene to the gameManager variable
				gameManager = FindObjectOfType<GameManager>(); 
			}

			// Do these actions when the trigger on this item is entered
			private void OnTriggerEnter2D(Collider2D collision)
			{
				Debug.Log("The player is touching " + GetComponent<Collider2D>().tag);

				// Increase Coin counter
				gameManager.addCoin();

				// Increase Score
				gameManager.addScore(coinPoints);

				// Set Coin to inactive, visibly removing the item from the screen but not destroying it completely.
				gameObject.SetActive(false);
			}
			```
	1. Highlight the Coin GameObject and drag the GameManager into the Coin(script) Game Manager space
	1. Drag Coin GameObject to the prefabs folder
	1. Delete the Coin GameObject
	1. Place Coin prefabs into the scene

### Other collectibles
Other collectibles will use a similar pattern as what we used above.  For instance if we wanted to do a power up we will first need to create variables to track what the powerup affects.  

In Super Mario Bros we have two powerups that are actually dependent on each other.  The first powerup is the mushroom, having this powerup give the player one additional hit point but it also has some additional effects. Can you think of what they are? One effect is obvious, changing the Player Sprite to double the original height.  But the other effect happens in the background.  All of the mushroom blocks now grow stationary fire flowers instead of mobile mushrooms.

By keeping track of the players powerup status using variables you can ensure that each of these events is accounted for.

Other powerups include the fire flower the 1UP mushroom and the invincibility star. 

#### Collecting Mushrooms
	
1. Create Mushroom
	1.

1. Add Mushroom GameManager Logic
	1.

1. Add Mushroom Script & Logic
	1.

#### Implementing Player Growth

#### Mushroom Blocks
We haven't even implemented a mushroom block yet, but we have completed most of the elements to create one.  For homework I would like to see you try to implement a mushroom block. It should:

1. When hit by the player instantiate a mushroom sprite (doesn't need to look like a mushroom unless you want it to)
	1. **Stretch Goal:** see if you can set it up to where only if the players head touches the bottom of the block it generates a mushroom.  We will cover this when we work on destroying enemies but see if you can figure it out.  

1. Should never create a second mushroom if hit a second time
1. The mushroom created should move to the right first and bounce off of and obstacles but pass through any enemies


## Killing the Player

### First some cleanup
We will no longer need the Hitbox that is on the Enemy because we will implement what the hitbox does a little differently going forward. 
1. Remove Hitbox from the Enemy
	1. This will require opening the prefab and deleting the asset

2. In the Player Movement Script we will need to check if the player is interacting with the Enemy and if it is we need to check if the player has any hit points and if they don't we should destroy the player and reduce the number of lives and respawn the player.
	1. Lets add hitpoints to the player.  We will use this to deterimine if our player should be alive or dead. 
		1. Add the following to the GameManger Script under `private int lives = 3`
		```cs
			[SerializeField]
			private int hitPoints = 1;
			private int maxHitPoints = 2;
		```
		2. Then add the following after the `public in getLives(){}` method
		```cs
			public int getHitPoints()
			{
				return this.hitPoints;
			}
			// Add a hitpoint
			public void addHitPoint()
			{
				if(hitPoints < maxHitPoints)
				{
					hitPoints++;
				}
			}

			// Remove a hitpoint
			public void removeHitPoint()
			{
				hitPoints--;
				if (hitPoints <= 0)
				{
					//kill player
					
				}
			}
		```
		3. Then in the PlayerMovement script add the following code into the if statement within `OnTriggerEnter2D(Collider2D collider)`
		```cs
			removeHitPoint();
		```

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