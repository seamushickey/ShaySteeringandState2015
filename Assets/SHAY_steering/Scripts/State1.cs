using UnityEngine;
using System.Collections;

public abstract class State1 {
	
	protected GameObject myGameObject;//protected means you inheriting classes can access the variable
	public State1(GameObject gameobject) //constructor which assigns myGameObject
	{
		this.myGameObject = gameobject;
	}
	public abstract void Update(); //abstract methods must appear in class/states that inherit from this class
	public abstract void Enter();
	public abstract void Exit();
}
