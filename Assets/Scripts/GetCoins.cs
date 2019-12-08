using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetCoins : MonoBehaviour {

	public int counter;
	// Use this for initialization
	void Start () {
		counter = 0 ;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		}




    void OnControllerColliderHit(ControllerColliderHit hit)
	{
		Destroy (hit.gameObject);
		Debug.Log("counter = "+counter);
		//GUI.Label(new Rect(10,10,100,20), "score : " + counter);
        
    }
    
}
