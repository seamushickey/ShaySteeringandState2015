using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

public GameObject player, target;

private Vector3 offset;


	// Use this for initialization
	void Start () 
	{
	offset = transform.position; //sets the offset for our camera
	target = GameObject.Find ("Pollen"); 
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	transform.position = player.transform.position + offset;
		transform.LookAt(target.transform.position); //set camera to look at target
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			target = GameObject.Find("Buzzer");//if space presssed, buzzer becomes target
			player = GameObject.Find("Pollen");
		
		}
		else if(Input.GetKeyUp(KeyCode.Space))
		{
			target = GameObject.Find("Pollen");//if space released pollen is the target
			player = GameObject.Find("FlyLeader");
		}
		
		
	}
	
	
}
