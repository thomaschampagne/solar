using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	
	#region variables
	public static GameManager Instance { get; set; } // Provide public static access of GameManager
	public GameState State { get; set; }

	protected bool gamePaused;
	public Texture startImg = (Texture)Resources.Load ("main/images/back_1");
	#endregion
	
	void Awake ()
	{

		if (Instance != null) {
			throw new UnityException ("GameManager Instance already exist !");
		} else {
			Instance = this;        
		}
		
		DontDestroyOnLoad (this); // keep running as a singleton-like
		
		setGameStateTo (GameState.WelcomeMenu); // GameManager Ready setting first state and load scene
		
	}
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void OnGUI ()
	{

		if (State == GameState.WelcomeMenu) {
		
			if (GUI.Button (new Rect (Screen.width - 100,
                                        Screen.height - 100, 75, 30), "Start")) {
				setGameStateTo (GameState.SolarSystem);
			}
		}
		
	}

	public void setGameStateTo (GameState state)
	{
		this.State = state;
		Application.LoadLevel (this.State.ToString ());
	}
}
