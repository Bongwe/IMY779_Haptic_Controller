using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Platformer : MonoBehaviour {

	private Rigidbody rigidBody;

	bool movingLeft;
	bool movingRight;

	private float playerSpeed = 0.1f;
	private float jumpForce = 350f;

	private bool isActivatedSphere1 = false;
	private bool isActivatedSphere2 = false;

	private Camera m_MainCamera;

	public GameObject groundObject;

	private int deathCount = 0;
	public Text m_MyText;
	public GameObject movingPlatform1;
	public GameObject movingPlatform2;
	private bool canJump = false;

	private void Start (){
		m_MyText = GameObject.Find("DeathCountText").GetComponent<Text>();
		movingPlatform1 = GameObject.FindGameObjectWithTag("MovingPlatform1");
		movingPlatform2 = GameObject.FindGameObjectWithTag("MovingPlatform2");
		rigidBody = GetComponent<Rigidbody> ();
		m_MainCamera = Camera.main;
		m_MainCamera.transform.parent = rigidBody.transform;
	}

	public void ButtonInput (string input){
		GroundObject other = (GroundObject)groundObject.GetComponent(typeof(GroundObject));


		switch (input) {
		case "right":
			movingRight = true;
			break;
		case "left":
			movingLeft = true;
			break;
		case "right-up":
			movingRight = false;
			break;
		case "left-up":
			movingLeft = false;
			break;
		case "jump":
				//if (other.canJumpFunction())
				if (canJump)
				{
					rigidBody.AddForce(transform.up * jumpForce);

				}
				break;
		case "interact":
			if (isActivatedSphere1) {
					movingPlatform1.transform.position = new Vector3(movingPlatform1.transform.position.x, movingPlatform1.transform.position.y - 3, movingPlatform1.transform.position.z);
			}
			if (isActivatedSphere2)
			{
				movingPlatform2.transform.position = new Vector3(movingPlatform2.transform.position.x, movingPlatform2.transform.position.y - 3, movingPlatform2.transform.position.z);
			}
			break;
		}
	}

	private void FixedUpdate(){
		if (movingLeft && !movingRight) {
			rigidBody.MovePosition(rigidBody.position + new Vector3 (-playerSpeed, 0, 0));
		} else if (!movingLeft && movingRight) {
			rigidBody.MovePosition(rigidBody.position + new Vector3 (playerSpeed, 0, 0)); 
		}
	}

	//Track if the player capsule is currently inside the transparent sphere or not
	void OnTriggerEnter(Collider trigger){
		if (trigger.tag == "InteractiveSphere1") {
			isActivatedSphere1 = true;
			Debug.Log("isActivatedSphere1: " + isActivatedSphere1);
		}
		
		if (trigger.tag == "InteractiveSphere2")
		{
			isActivatedSphere2 = true;
			Debug.Log("InteractiveSphere2: " + isActivatedSphere2);
		}
		Debug.Log("OnTriggerEnter: " + trigger);
	}

	/*void OnTriggerExit(Collider trigger){
		if (trigger.tag == "PlatformSphere") {
			isInSphere = false;
		}
	}*/

	private void OnCollisionStay()
	{
		canJump = true;
	}

	void OnCollisionEnter(Collision other)
    {
		Debug.Log(other.gameObject.tag);
		if (other.gameObject.tag == "EnemyPlayer")
		{
			Vector3 startPosition = new Vector3(-3.63f, -2.912115f, 1.92f);
			rigidBody.position = startPosition;
			updateDeaths();
		}
		if (other.gameObject.tag == "DeathTrigger")
		{
			Vector3 startPosition = new Vector3(-3.63f, -2.912115f, 1.92f);
			rigidBody.position = startPosition;
			updateDeaths();
		}
		if (other.gameObject.tag != "EnemyPlayer")
		{
			canJump = true;
			Debug.Log("jump: " + canJump);
		}

    }

	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag != "EnemyPlayer")
		{
			canJump = false;
		}
	}

	private void updateDeaths()
    {
		deathCount++;
		m_MyText.text = "Deaths: " + deathCount;
	}
}
