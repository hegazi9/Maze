using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MovementController : MonoBehaviour {
	public bool isGrounded;
	private float speed;
	public float rotSpeed;
	public float jumpHeight;
	private Canvas winner ; 

	//walk speed
	private float w_speed = 0.1f;
	//rotation speed
	private float rot_speed = 1.0f;
	Rigidbody rb;
	Animator anim;
	int x = 0 ;
	private Vector3 spawn;
	public int Score;
	public Text ScoreText;
	float v; //vertical movements
	float h; //horizontal movements
	float sprint;
	public GameObject menuContainer;
	private Collider other ;
	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		isGrounded = true;
		spawn = transform.position;
		Score = 0;
	
		SetScoreText ();
	
	}

	// Update is called once per frame
	void Update () {

        if (isGrounded)
        {
            //moving forward and backward
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                speed = w_speed;
                movementControl("WalkingForward");
            }
            else if (Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.DownArrow))
			{
				speed = w_speed;
				movementControl("WalkingBackward");
			}
			else
			{
				movementControl("idle");
			}
			//moving right and left
			if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
			{
				rotSpeed = rot_speed;
			}
			else if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow))
			{
				rotSpeed = rot_speed;
			}
			else
			{
				rotSpeed = 0;
			}
		}
		var z = Input.GetAxis("Vertical") * speed;
		var y = Input.GetAxis("Horizontal") * rotSpeed;
		transform.Translate(0, 0, z);
		transform.Rotate(0, y, 0);


	}
	void movementControl(string state)
	{
		switch (state)
		{
		case "WalkingForward":
			anim.SetBool("isWalkingForward", true);
			anim.SetBool("isWalkingBackward", false);
			anim.SetBool("isIdle", false);
			break;
		case "WalkingBackward":
			anim.SetBool("isWalkingForward", false);
			anim.SetBool("isWalkingBackward", true);
			anim.SetBool("isIdle", false);
			break;
		case "idle":
			anim.SetBool("isWalkingForward", false);
			anim.SetBool("isWalkingBackward", false);
			anim.SetBool("isIdle", true);
			break;
		}
	}


	void OnTriggerEnter(Collider other)
	{
		
		if(other.gameObject.CompareTag("coins")){
			other.gameObject.SetActive (false);
			Score = Score + 1;
			SetScoreText ();

	}


}


		void SetScoreText(){
		ScoreText.text = "Score: " + Score.ToString ();
		}
}
