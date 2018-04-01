using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public bool isPlayer2 = false, animEnabled = true;

	public int playerSpeed = 25;
	private bool facingRight = true;
	public int playerJumpPower = 100;
	private float moveX;
	private float moveY;



	//Powerups
	public float playerJumpPowerFactor = 1.0f;

	public bool chick = false;
	public bool guac = false;


	float time;

	Animator anim;

	void Start() {
		if (animEnabled)
			anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		PowerUps ();
		PlayerMove ();
	}

	void PowerUps() {
		if (chick) {
			if (Time.realtimeSinceStartup - time > 10.0f) {
				chick = false;
				time = 0.0f;
				playerJumpPowerFactor = 1;
			}
		}
	}

	void PlayerMove() {
		//Controls
		moveX = Input.GetAxis("Horizontal-" + ((isPlayer2)?"2":"1"));

		if (Input.GetButtonDown ("Jump-" + ((isPlayer2)?"2":"1")) && gameObject.GetComponent<Rigidbody2D> ().velocity.y <= 0.05 && gameObject.GetComponent<Rigidbody2D> ().velocity.y >= -0.05) {
			if (animEnabled)
				anim.SetFloat ("jump", 1);
			Jump ();
		} else if (gameObject.GetComponent<Rigidbody2D> ().velocity.y == 0){
			if (animEnabled)
				anim.SetFloat ("jump", 0);
		}
		//Animations
		if (animEnabled)
			anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal-2")));

		//Player Direction
		if (moveX > 0.0f && facingRight == false){
			FlipPlayer ();
		}else if (moveX < 0.0f && facingRight == true) {
			FlipPlayer ();
		}

		//Physics
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	void Jump() {
		//GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower * playerJumpPowerFactor);
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(rb.velocity.x, playerJumpPower * playerJumpPowerFactor);
	}

	void FlipPlayer() {
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1f;
		transform.localScale = localScale;
	}
		

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Chick")
		{
			playerJumpPowerFactor = 1.5f;
			time = Time.realtimeSinceStartup;
			chick = true;
		}

		if (other.gameObject.tag == "Water")
		{
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Water")
		{
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 5.5f;
		}
	}

	void OnCollisionExit2D(Collider2D other) {
		if (other.gameObject.tag == "Guac")
		{
			SceneManager.LoadScene(4);

			SceneManager.LoadScene(2);
		}
	}
	//0 - Main Menu
	//1 - Water
	//2 - Mole 
	//3 - Battle
	//4 - Map
	//5 - Controls
}
