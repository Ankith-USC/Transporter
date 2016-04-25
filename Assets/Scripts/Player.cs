using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	private static string UPLADDER = "UpLadder";
	private static string DOWNLADDER = "DownLadder";
	private BoxCollider boxCol;

	Dictionary<string,string> ladderStatus = new Dictionary<string, string> ();
	public GameObject[] ladders;


	//life count
	public static int lifeCount = 2;

	// movement
	public static float moveSpeed = 5;
	private int moveDirX;
	private int moveDirY;
	private Vector3 movement;
	private Transform thisTransform;

	private float yValAtEntry;

	public Sprite[] HeartSprites;
	public Image HeartsUI;
	private string ladderName = "";

	private string temp = "";

	//sounds
	//public AudioSource stairs;
	public AudioSource background;

	//PLAYER MOVEMENT	
	public static bool blockedRight = false;
	public static bool blockedLeft = false;
	public static bool blockedUp = false;
	public static bool blockedDown = false;
	public static bool onLadder = false;
	public static bool isLeft;
	public static bool isRight;
	public static bool isUp;
	public static bool isDown;
	public static float playerHitboxX = 0.225f; // player x = 0.45
	public static float playerHitboxY = 0.15f;
	public static bool alive;
	public static bool onTop = false;
	public static bool onBottom = false;
	public static bool onAir = false;
	public static bool ColliderLeft = false;
	public static bool ColliderRight = false;
	Animator myAnimator;

	//CAMERA
	public static float orthSize;
	public static float orthSizeX;
	public static float orthSizeY;
	public static float camRatio;
	private Vector3 ladderHitbox;
	private static bool isGameGravityOn = false;


	//PLAYER DIR
	public static int facingDir = 1; // 1 = left, 2 = right, 3 = up, 4 = down
	public static bool facingRight;
	private Vector3 playerDir;
	public enum anim { None, WalkLeft, WalkRight, Climb, ClimbStop, StandLeft, StandRight }

	public static Vector3 glx;


	//JUMP
	private Vector3 jumpMovement;
	private Vector3 center;
	public float xaxis;
	public float yaxis;

	float maxJumpHeight = 2f;
	float Jheight = 0f;
	Vector3 groundPos;
	Vector3 ladderpos;
	float jumpSpeed = 5.0f;
	float fallSpeed = 5.0f;
	public bool inputJump = false;
	public  static bool grounded = true;
	public bool isJumpOn = false;
	Camera cam;

	public static int coinCount;
	public static int keyCount;
	public static GameObject[] keys;

	void Awake() 
	{
		thisTransform = transform;
	}

	void Start()
	{
		gameObject.name = "player";
		coinCount = GameObject.FindGameObjectsWithTag ("Coin").Count();
		keyCount = GameObject.FindGameObjectsWithTag ("Key").Count();
		ladders = GameObject.FindGameObjectsWithTag ("Ladder");
		if (xa.levelNumber == 3) {
			GameObject.Find ("superanim").GetComponent<Animator> ().enabled = false;
			GameObject.Find ("superanim").GetComponent<SpriteRenderer> ().enabled = false;
		}
	
		foreach (GameObject lad in ladders) {
			ladderStatus.Add (lad.name, UPLADDER);
		}
		alive = true;
		lifeCount = 2;

		//sounds

		//stairs.Stop();
		background.Play();

		//set ground position for jump
		groundPos = transform.position;
		facingDir = 1;
		blockedLeft = false;
		blockedRight = false;
		blockedUp = false;
		blockedDown = false;
		onLadder = false;
		isJumpOn = false;
		isLeft = false;
		isRight = false;
		isUp = false;
		isDown = false;
		isGameGravityOn = false;
		onTop = false;
		onBottom = false;
		playerDir = transform.localScale;
		facingRight = true;
		myAnimator = GetComponent<Animator> ();
		cam=Camera.main;
		xa.gPower = false;
		onAir = false;
		ColliderLeft = false;
		ColliderRight = false;
	}

	//CONTROLS

	public void Update ()
	{	
		if (xa.levelNumber == 3) {
			if (!grounded || (isLeft || isRight))
				cam.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -4f, 0f), Mathf.Clamp(this.transform.position.y, 3.5f, 15f), Mathf.Clamp(this.transform.position.z, -1000f, 1000f));
			else
			{
				if (grounded || (onLadder && !isJumpOn))
					cam.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -4f, 0f), Mathf.Clamp(this.transform.position.y, 3.5f, 15f), Mathf.Clamp(this.transform.position.z, -1000f, 1000f));
			}
		}
		if (xa.levelNumber == 2 ) {
			if(!grounded || (isLeft || isRight))
				cam.transform.position = new Vector3 (Mathf.Clamp (this.transform.position.x, -33.5f, 2f), Mathf.Clamp (this.transform.position.y, 3.5f, 10f), Mathf.Clamp (this.transform.position.z, -1000f, 1000f));

			else if(grounded || onLadder)
				cam.transform.position = new Vector3 (Mathf.Clamp (this.transform.position.x, -33.5f, 2f), Mathf.Clamp (this.transform.position.y, 3.5f, 10f), Mathf.Clamp (this.transform.position.z, -1000f, 1000f));	
		}
			


		if (!alive) 
		{
			if (lifeCount > 0) 
			{
				lifeCount--;
				alive = true;
				gameObject.SetActive (false);
				Invoke ("activatePlayer", 0.5f);
			} else {
				if(myAnimator.GetBool("trapdead")==false)
					myAnimator.SetBool ("dead", true);
				onRelease ();
				onJumpRelease ();
				endGravity ();
				Invoke ("playerDeath", 2f);
			}


		}
		HeartsUI.sprite = HeartSprites[lifeCount];

		if (!background.isPlaying && alive)
			background.Play();	

		if (xa.levelNumber == 1) {

			if (isGameGravityOn) 
			{
				transform.Translate (Input.acceleration.x, 0, 0);

				if (this.transform.position.x < -21.5f)
				{
					this.transform.position = new Vector3(16.5f, this.transform.position.y, this.transform.position.z);
				}

				if (this.transform.position.x > 16.5f)
				{
					this.transform.position = new Vector3(-21.5f, this.transform.position.y, this.transform.position.z);
				}

			}
		}
			
		//boundaries

		if (xa.levelNumber == 2) {

			if (!onLadder) {
				if (thisTransform.position.x < -47.5f)
					blockedLeft = true;
				else if (ColliderLeft)
					blockedLeft = true;
				else
					blockedLeft = false;

				if (thisTransform.position.x > 17f)
					blockedRight = true;
				else if (ColliderRight)
					blockedRight = true;
				else
					blockedRight = false;

			}
		} else if (xa.levelNumber == 1) {
			
			if (!onLadder && !isGameGravityOn) {
				if (thisTransform.position.x < -19f)
					blockedLeft = true;
				else
					blockedLeft = false;

				if (thisTransform.position.x > 15f)
					blockedRight = true;
				else
					blockedRight = false;

			}
		}


		if (countDownTimer.timeOver)
		{
			onRelease ();
			Destroy (gameObject);
			end ();
		}

		if (xa.prisonDoor) 
			blockedRight = true;

		if (xa.exitDoor) 
			blockedLeft = true;


		moveDirX = 0;
		moveDirY = 0;


		// move left
		if(isLeft && !blockedLeft) 
		{
			moveDirX = -1;
			facingDir = 1;

		}

		// move right
		if(isRight && !blockedRight) 
		{
			moveDirX = 1;
			facingDir = 2;
		}

		// move up on ladder
		if(isUp && !blockedUp && onLadder && !onAir)
		{
			moveDirY = 1;
			facingDir = 3;

		}

		// move down on ladder
		if(isDown && !blockedDown && onLadder) 
		{
			moveDirY = -1;
			facingDir = 4;

		}
			
		/*
			//sounds  BACKGROUND MUSIC
		if(!((isLeft && !blockedLeft) || (isDown && !blockedDown && onLadder) || (isUp && !blockedUp && onLadder) || (isRight && !blockedRight)))
		{
			stairs.Play();
		}
		*/

		//FLIP player 
		if (!facingRight && moveDirX == 1 || facingRight && moveDirX == -1) 
		{
			facingRight = !facingRight;
			playerDir = transform.localScale;
			playerDir.x *= -1;
			transform.localScale = playerDir;
		}

		//TRANSLATE PLAYER MOVEMENT

		if (Input.GetKeyDown (KeyCode.Space) || isJumpOn)
		{
			if (grounded && !isGameGravityOn) 
			{
				onAir = true;
				groundPos = transform.position;
				inputJump = true;
				StartCoroutine ("Jump");
			}
			isJumpOn = false;
		}  else
		{
			movement = new Vector3(moveDirX, moveDirY,0f) * Time.deltaTime*moveSpeed;
			if (onLadder && (isUp == true || isDown == true))
				this.transform.position = new Vector3(center.x, this.transform.position.y, this.transform.position.z);
			thisTransform.Translate(movement.x,movement.y, 0f);
			if(!onAir)
				myAnimator.SetFloat ("speed", Mathf.Abs(movement.x));
		}

		yaxis = Mathf.Round(transform.position.y * 1f) / 1f;
		xaxis = Mathf.Round(groundPos.y * 1f) / 1f;

		if(yaxis == xaxis && (Mathf.Abs(Mathf.Abs(transform.position.y) - Mathf.Abs(groundPos.y)) < 0.05f))
			grounded = true;
		else
			grounded = false;

		yaxis = Mathf.Round (transform.position.y * 10f) / 10f;

		// Only applies for mid ladder change of grounding. only for this level
		if (xa.levelNumber == 1) {
			if (grounded == true && ( yaxis== 0.2f || yaxis== 0.3f) )
				grounded = false;
		}


		if (!onAir && !onLadder && groundPos.y != transform.position.y) {
			thisTransform.Translate (thisTransform.position.x, groundPos.y, thisTransform.position.z);
		}

	}

	//TRIGGERS

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pickup") || other.gameObject.CompareTag("Coin") || other.gameObject.CompareTag("Key") )
		{
			if (other.GetComponent<Pickup>())
			{
				other.GetComponent<Pickup>().PickMeUp();

			}
		}

		if (xa.levelNumber == 3) 
		{
			if (other.gameObject.CompareTag("BlockLeft"))
			{
				Debug.Log("blockleft");
				ColliderLeft = true;
				blockedLeft = true;
			}
			if (other.gameObject.CompareTag("BlockRight"))
			{
				Debug.Log("blockright");
				ColliderRight = true;
				blockedRight = true;
			}
		}

		//WALL COLLIDERS
		if (xa.levelNumber == 2) 
		{
			if (other.gameObject.CompareTag("BrickCollider"))
			{
				Debug.Log("1");
				ColliderLeft = true;
				blockedLeft = false;
			}
			if (other.gameObject.CompareTag("BrickCollider2"))
			{
				Debug.Log("2");
				ColliderRight = true;
				blockedRight = false;
			}
		}
			
		//LADDER COLLIDER
		if (other.gameObject.CompareTag ("Ladder"))
		{
			ladderName = other.name;
			if (ladderStatus [other.name] == UPLADDER && !onAir) {
				onBottom = true;
				onTop = false;
			} else if (ladderStatus [other.name] == DOWNLADDER && !onAir) {
				onBottom = false;
				onTop = true;
			} else if (ladderStatus [other.name] == DOWNLADDER && onAir) {
				onBottom = false;
				onTop = true;
			} else {
				onBottom = false;
				onTop = false;
			}
			center = new Vector3(other.transform.position.x,0f,0f);
			if (!onAir)
				yValAtEntry = thisTransform.position.y;
			else
				yValAtEntry = groundPos.y;
			onLadder = true;

			ladderpos = new Vector3 (center.x, transform.position.y, transform.position.z);
		}

		if (other.gameObject.CompareTag ("Goal1")) {
			GameObject.Find ("Midway Message").GetComponent<Canvas> ().enabled = true;
			onRelease ();
			Invoke ("Goal1Delay", 0.07f);
			pause();
		}

		if (other.gameObject.CompareTag("Flame") && gameObject.name == "player")
		{
			Player.alive = false;
		}
	}

	void OnTriggerStay(Collider other)
	{

		// is the player overlapping a ladder?
		if(other.gameObject.CompareTag("Ladder") && !onAir)
		{
			
			onLadder = true;
			blockedUp = false;
			blockedDown = false;
			blockedLeft = true;
			blockedRight = true;

			myAnimator.SetBool ("climb", false);

			myAnimator.SetBool ("climbStay", false);

			if ( thisTransform.position.y > yValAtEntry)
			{
				onTop = false;
				onBottom = false;
				if(isUp || isDown)
					myAnimator.SetBool ("climb", true);
				else
					myAnimator.SetBool ("climbStay", true);
			}
			if (thisTransform.position.y < yValAtEntry)
			{
			    {
					onTop = false;
					onBottom = false;
				}
				if (!grounded) 
				{

					if (isUp || isDown)
						myAnimator.SetBool ("climb", true);
					else
						myAnimator.SetBool ("climbStay", true);
				} 
				else 
				{
					blockedLeft = false;
					blockedRight = false;
					onBottom = true;
				}
			}

			ladderHitbox.y = other.transform.localScale.y * 0.5f; // get half the ladders Y height

			if ((thisTransform.position.y + Player.playerHitboxY) >= (ladderHitbox.y + other.transform.position.y) && isUp) {

				Player.glx = thisTransform.position;
				Player.glx.y = (ladderHitbox.y + other.transform.position.y) - Player.playerHitboxY;
				thisTransform.position = Player.glx;
				onTop = true;
				myAnimator.SetBool ("climb", false);
				myAnimator.SetBool ("climbStay", false);
				groundPos = thisTransform.position;
				yValAtEntry = thisTransform.position.y;
			} 

			if ((thisTransform.position.y - Player.playerHitboxY*4.7f) <= (-ladderHitbox.y + other.transform.position.y )) 
			{
				Player.glx = thisTransform.position;
				Player.glx.y = (-ladderHitbox.y + other.transform.position.y) + Player.playerHitboxY*5.2f;
				thisTransform.position = Player.glx;

				myAnimator.SetBool ("climb", false);
				myAnimator.SetBool ("climbStay", false);

				groundPos = thisTransform.position;
				onBottom = true;
			} 

			if (onTop || onBottom) 
			{
				blockedLeft = false;
				blockedRight = false;

				if (onTop)
					blockedUp = true;
				else if (onBottom)
					blockedDown = true;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Ladder")) 
		{
			ladderName = "";

			if (onTop == true || onBottom == true) {
				if (onTop == true)
					ladderStatus [other.name] = DOWNLADDER;
				else if (onBottom == true)
					ladderStatus [other.name] = UPLADDER;
			} else {
				ladderStatus [other.name] = UPLADDER;
			}

			onLadder = false;
			blockedLeft = false;
			blockedRight = false;
			blockedDown = true;
			blockedUp = true;
			onTop = false;
			onBottom = false;

			for(int i = 0; i<ladderStatus.Count;i++) 
			{
				var item = ladderStatus.ElementAt(i);
				if (item.Key != other.name) 
				{
					if (GameObject.Find (item.Key).GetComponent<BoxCollider>().transform.position.y == other.transform.position.y) 
					{
						ladderStatus [item.Key] = ladderStatus [other.name];
					}
				}
			}

			if(!onAir)
				groundPos = transform.position;
 			myAnimator.SetBool ("climb", false);
			myAnimator.SetBool ("climbStay", false);
		}
		if (xa.levelNumber == 2) 
		{
			if (other.gameObject.CompareTag("BrickCollider"))
			{
				Debug.Log("1-2");
				ColliderLeft = false;
				blockedLeft = true;
			}
			if (other.gameObject.CompareTag("BrickCollider2"))
			{
				Debug.Log("2-1");
				ColliderRight = false;
				blockedRight = true;
			}
		}
			
		if (xa.levelNumber == 3) 
		{
			if (other.gameObject.CompareTag("BlockLeft"))
			{
				Debug.Log("1-2");
				ColliderLeft = false;
				blockedLeft = false;
			}
			if (other.gameObject.CompareTag("BlockRight"))
			{
				Debug.Log("2-1");
				ColliderRight = false;
				blockedRight = false;
			}
		}

	}

	IEnumerator Jump()
	{
		Jheight = transform.position.y + maxJumpHeight;
		while(true)
		{
			if(transform.position.y >= Jheight)
				inputJump = false;
			if(inputJump){
				myAnimator.SetBool ("takeoff", true);
				myAnimator.SetBool ("land", false);
				Vector3 tempup = new Vector3 (movement.x*5, 1, 0);
				transform.Translate (tempup * jumpSpeed * Time.smoothDeltaTime);

				if(onLadder && !onTop && !onBottom && ladderStatus[ladderName]!= DOWNLADDER)
				{
					Debug.Log ("Ascent ladder stick");
					myAnimator.SetBool ("climbStay", true);
					myAnimator.SetBool ("land", true);
					myAnimator.SetBool ("takeoff", false);
					thisTransform.position =ladderpos;
					StopAllCoroutines();
					onAir = false;
					break;
				}

			}


			else if(!inputJump)
			{
				Vector3 tempdown = new Vector3 (movement.x*3, -1, 0);
				transform.Translate(tempdown * fallSpeed * Time.smoothDeltaTime);
				myAnimator.SetBool ("land", true);
				myAnimator.SetBool ("takeoff", false);	
				jumpMovement = new Vector3(transform.position.x, groundPos.y,transform.position.z);


				if(onLadder && !onTop && !onBottom && ladderStatus[ladderName]!= DOWNLADDER)
				{
					Debug.Log ("Descent ladder stick");
					myAnimator.SetBool ("climbStay", true);
					thisTransform.position =ladderpos;
					StopAllCoroutines();
					onAir = false;
					break;
				}
				else if(transform.position.y < groundPos.y)
				{
					thisTransform.position =jumpMovement;
					StopAllCoroutines();
					onAir = false;
				}
			}
			yield return new WaitForEndOfFrame();
		}
	}


	//---------ONSCREEN BUTTONS-----------------

	//JUMP

	public void onJump()
	{
		if(lifeCount > 0)
		isJumpOn = true;
	}


	//LEFT
	public void onLeft()
	{
		isLeft = true;
	}

	//RIGHT
	public void onRight()
	{
		isRight = true;
	}

	//UP
	public void onUp()
	{
		isUp = true;
	}

	//DOWN
	public void onDown()
	{
		isDown = true;
	}

	//BUTTON RELEASE
	public void onRelease()
	{
		isLeft = false;
		isRight = false;
		isUp = false;
		isDown = false;
	}
	// JUMP RELEASE
	public void onJumpRelease()
	{
		isJumpOn = false;
	}

	public void onGravity()
	{
		if (xa.gPower && grounded)
		{
			foreach (GameObject lad in ladders) 
			{
				lad.GetComponent<BoxCollider> ().enabled = false;
			}
			isGameGravityOn = true;
			Invoke ("endGravity", 8);
		}
	}

	private void endGravity()
	{
		isGameGravityOn = false;

		foreach (GameObject lad in ladders) 
		{
			lad.GetComponent<BoxCollider> ().enabled = true;
		}
	}

	public static void end()
	{
		isGameGravityOn = false;
		xa.gPower = false;
	}

	private void activatePlayer()
	{
		onRelease ();
		onJumpRelease ();
		onAir = false;
		this.transform.position = new Vector3(this.transform.position.x, groundPos.y, this.transform.position.z);
		temp = gameObject.name;
		gameObject.name = "Empty"; 
		gameObject.SetActive (true);
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (255f, 255f, 255f, 0.5f);
		Invoke ("Wait", 4);
	}

	private void playerDeath(){
		end ();
		onRelease ();
		Destroy (gameObject);
		background.Stop ();
	}


	void Wait()
	{
		gameObject.name = temp; 
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (255f, 255f, 255f, 1f);
	}

	private void Goal1Delay()
	{
		pause ();
		GameObject.Find ("Midway Message").GetComponent<Canvas> ().enabled = false;
		countDownTimer.startTimer ();

	}

	public void pause(){
		if(Time.timeScale == 1){
			Time.timeScale = 0.01f;
		}
		else if(Time.timeScale == 0.01f){
			Time.timeScale = 1;
		}

	}
}
