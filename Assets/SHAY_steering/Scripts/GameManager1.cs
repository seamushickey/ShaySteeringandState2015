using UnityEngine;
using System.Collections;

public class GameManager1 : MonoBehaviour {
	
	GameObject[] boids;
	GameObject leader;
	
	void Start () 
	{
		leader = GameObject.Find ("FlyLeader");
		FindBoids();
		GiveBoidsStartState();
	}
	
	void FindBoids()
	{
		boids = GameObject.FindGameObjectsWithTag("Boid");
	}
	
	void GiveBoidsStartState()
	{
		foreach(GameObject boid in boids)
		{
			boid.GetComponent<StateMachine1>().SwitchState (new PatrolState1(boid));
		}
		leader.GetComponent<StateMachine1>().SwitchState (new PatrolState1(leader));
	}
}