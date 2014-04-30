using UnityEngine;
using System.Collections;


public class Bootstrap : MonoBehaviour
{

	private GameObject gameManager;
	
	void Start ()
	{
        
		Debug.Log ("Bootstrap");
		
		Application.targetFrameRate = 120;
		Object gameManagerPrefab = (Object) Resources.Load("prefabs/GameManager");
		gameManager = (GameObject) Instantiate (gameManagerPrefab);
		gameManager.name = "GameManager";
		Destroy (gameObject);
	}
}
