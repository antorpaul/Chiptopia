using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour {

	public List<Transform> targets;
	public Vector3 offset;

	void LateUpdate()
	{
		if (targets.Count == 0)
			return;
		
		Vector3 centerPoint = GetCenterPoint ();

		Vector3 newPosition = centerPoint + offset;

		transform.position = newPosition;
		// good chance we want to adjust stuff
	}

	Vector3 GetCenterPoint()
	{
		if (targets.Count == 1)
		{
			return targets [0].position;
		}

		// use bounds to encapsulate multiple objects
		var bounds = new Bounds(targets[0].position, Vector3.zero);

		for (int i = 0; i < targets.Count; i++)
		{
			bounds.Encapsulate (targets [i].position);
		}

		return bounds.center;
	}


}
