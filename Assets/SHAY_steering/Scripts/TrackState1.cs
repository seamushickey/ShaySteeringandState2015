using UnityEngine;
using System.Collections;

public class TrackState1 : State1 {
	
	public float changeStateTime, changeStateTimer = 15f; //A very simple change state condition!
	GameObject buzzer;
	public TrackState1(GameObject myGameObject):base (myGameObject) //constructor that needs the same argument as the State base class constructor. use :base(GameObject) to inherit the same myGameObject reference, so this class can access the gameobject it's refereing to
	{
		
	}
	public override void Enter() //override runs over the base class abstract method of the same name (abstract methods can't handle functionality, they are only a blueprint)
	{
		//give our boids a seek target position
		//pollen = GameObject.Find ("pollen");
		buzzer = GameObject.Find("Buzzer");
		
		myGameObject.GetComponent<SteeringBehaviours1>().seekTargetPos = buzzer.transform.position; //assign the leader to the target 
		
		//This is where you toggle the steering behaviours ON!
		myGameObject.GetComponent<SteeringBehaviours1>().seekEnabled = true;
		
		myGameObject.GetComponent<SteeringBehaviours1>().seperationEnabled = true;
		myGameObject.GetComponent<SteeringBehaviours1>().cohesionEnabled = true;
		myGameObject.GetComponent<SteeringBehaviours1>().alignmentEnabled = true;
		Debug.Log("FlyBoids are tracking a target!");
	}
	
	public override void Update() //override runs over the base class abstract method of the same name (abstract methods can't handle functionality, they are only a blueprint)
	{
		//This is where we calculate stuff, like the condition to transition to the next state
		changeStateTime += Time.deltaTime;
		if(changeStateTime >= changeStateTimer)
		{
			myGameObject.GetComponent<StateMachine1>().SwitchState (new SeekState(myGameObject));
		}
		if(Input.GetKeyDown(KeyCode.Space))//turns on Buzzer light and resets state to trackstate
		{
			myGameObject.GetComponent<StateMachine1>().SwitchState (new TrackState1(myGameObject));
			buzzer = GameObject.Find("Buzzer");
			buzzer.GetComponent<Light>().enabled = true;
			
		}
		else if (Input.GetKeyUp(KeyCode.Space))	
		{
			myGameObject.GetComponent<StateMachine1>().SwitchState (new SeekState(myGameObject));
			buzzer = GameObject.Find("Buzzer");
			buzzer.GetComponent<Light>().enabled = false;
		}
	}
	
	public override void Exit() //override runs over the base class abstract method of the same name (abstract methods can't handle functionality, they are only a blueprint)
	{
		//this is where we turn off all steering behaviours, as the new state we transition to will enable only the ones it needs
		myGameObject.GetComponent<SteeringBehaviours1>().TurnOffAll();
	}
}
