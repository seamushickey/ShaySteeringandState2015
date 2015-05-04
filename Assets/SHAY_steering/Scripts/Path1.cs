using UnityEngine;
using System.Collections.Generic;

public class Path1 : MonoBehaviour {

	List<Vector3> waypoints = new List<Vector3>();
	public int next = 0;
	public bool looped = true;
	
	public void CreatePath()
	{
		for(int i = 0; i < 10; i++)
		{
			waypoints.Add ((Random.insideUnitSphere * 25f) + new Vector3(0f, 40f, 0f));
			
			
			
		}
	}
	
	public Vector3 NextWaypoint()
	{
		return waypoints[next];
	}
	
	public bool IsLastCheckpoint()
	{
		return(next == waypoints.Count-1);
	}
	
	public void AdvanceWaypoint()
	{
		if(looped)
		{
			next = (next + 1) % waypoints.Count;
		}
		else
		{
			if(!IsLastCheckpoint())
			{
				next = next + 1;
			}
		}
	}
}