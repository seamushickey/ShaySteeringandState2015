using UnityEngine;
using System.Collections;

public class SeekState : State1 {
	
	public float changeStateTime, changeStateTimer = 15f; //A very simple change state condition!
	GameObject leader, buzzer; //a reference to the leader we want to chase!
	
	public SeekState(GameObject myGameObject):base (myGameObject) //constructor that needs the same argument as the State base class constructor. use :base(GameObject) to inherit the same myGameObject reference, so this class can access the gameobject it's refereing to
	{
		
	}
	public override void Enter() //override runs over the base class abstract method of the same name (abstract methods can't handle functionality, they are only a blueprint)
	{
		if(myGameObject.GetComponent<SteeringBehaviours1>().target == null) //if this boid hasn't already got a target (leader)
		{
			leader = GameObject.Find ("Pollen"); //then find the leader in the scene
			myGameObject.GetComponent<SteeringBehaviours1>().target = leader; //assign the leader to the target
			/*float distance = (this.transform.position - leader.position).magnitude;
			if(distance < 1f)
			{
			
				GameObject FlyBoid = GameObject.Find("CubeTrails");
				foreach (Transform child in FlyBoid.transform)
				{
					child.gameObject.SetActive(true);
					
				} 
			}*/
		}
		/*else 
		{
			leader = GameObject.Find ("FlyLeader"); //then find the leader in the scene
			myGameObject.GetComponent<SteeringBehaviours1>().target = leader;
			
			/*GameObject FlyBoid = GameObject.Find("CubeTrails");
			foreach (Transform child in FlyBoid.transform)
			{
				child.gameObject.SetActive(true);
				
			} 
		
		}*/
		
		buzzer = GameObject.Find("Buzzer");
		buzzer.GetComponent<Light>().enabled = false;
		//This is where you toggle the steering behaviours ON!
		//myGameObject.GetComponent<SteeringBehaviours1>().seekEnabled = true;
		myGameObject.GetComponent<SteeringBehaviours1>().cohesionEnabled = true;
		//myGameObject.GetComponent<SteeringBehaviours1>().seperationEnabled = true;
		myGameObject.GetComponent<SteeringBehaviours1>().arriveEnabled = true;
		
		Debug.Log("FlyBoids are seeking a target!");
	}
	
	public override void Update() //override runs over the base class abstract method of the same name (abstract methods can't handle functionality, they are only a blueprint)
	{
		//This is where we calculate stuff, like the condition to transition to the next state
		changeStateTime += Time.deltaTime;
		if(changeStateTime >= changeStateTimer)
		{
			myGameObject.GetComponent<StateMachine1>().SwitchState (new PatrolState1(myGameObject));
		}
		if(Input.GetKey(KeyCode.Space))
		{
			myGameObject.GetComponent<StateMachine1>().SwitchState (new TrackState1(myGameObject));
			buzzer = GameObject.Find("Buzzer");
			buzzer.GetComponent<Light>().enabled = true;
		}
			
			
	}
	
	public override void Exit() //override runs over the base class abstract method of the same name (abstract methods can't handle functionality, they are only a blueprint)
	{
		//this is where we turn off all steering behaviours, as the new state we transition to will enable only the ones it needs
		myGameObject.GetComponent<SteeringBehaviours1>().TurnOffAll();
	}
}