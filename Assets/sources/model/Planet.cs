using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{
	
	public GameObject anchorPlanet;
	public float anglePerSeconds;
	public bool canRotate;
	public float selfRotateSpeed;
	
	private float radius;
	private float radPerSecond = 0, radianGoal = 0;

	// Use this for initialization
	void Start ()
	{
		Application.targetFrameRate = 120; // TODO Move into singleton
		
		// Calcualte current radius from edotir
		radius = Vector3.Distance(anchorPlanet.transform.position, transform.position);
		
		radPerSecond = Mathf.Deg2Rad * anglePerSeconds;
		transform.position = anchorPlanet.transform.position + computePlanetPosition (ref radianGoal, ref radPerSecond, ref radius);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 positionFromAnchorPlanet = computePlanetPosition (ref radianGoal, ref radPerSecond, ref radius);
		transform.position = anchorPlanet.transform.position + positionFromAnchorPlanet;		
		if(canRotate) {
			transform.Rotate(transform.up, selfRotateSpeed * Time.deltaTime);
		}
	}

	public Vector3 computePlanetPosition (ref float radianGoal, ref float radPerSecond, ref float radius)
	{
		radianGoal += radPerSecond * Time.deltaTime;
		float x = Mathf.Cos (radianGoal) * radius;
		float z = Mathf.Sin (radianGoal) * radius;
		return new Vector3 (x, 0, z);
	}
}
