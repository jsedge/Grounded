using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GameObject levelSelect;
	public GameObject hud;
	public static GameManager instance;
	public bool useJoystick;
	private HashSet<string> levelsComplete;

	void Start(){
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(gameObject);
			levelsComplete = new HashSet<string>();
		}else{
			Destroy(gameObject);
			return;
		}
	}
	
	/*
	Switches between the HUD and the LevelSelect being visible
	 */
	public void ToggleLevelSelect(){
		levelSelect.SetActive(!levelSelect.activeSelf);
		hud.SetActive(!hud.activeSelf);
		var player = SquadManager.instance.GetPlayer(); 
		if(player != null)
			player.SetActive(!player.activeSelf);
	}

	public void CompleteLevel(string levelName){
		// Keep a distinct list of levels complete, cant get rewarded for finishing a level twice
		levelsComplete.Add(levelName);
		OpenLevel("CrashSite");

		// If we completed enough levels we win
		if(levelsComplete.Count >= 2){
			Debug.Log(UIManager.instance.gameObject);
			UIManager.instance.gameObject.SetActive(false);	
			Destroy(SquadManager.instance.gameObject);
				
			OpenLevel("Finale");	
		}
	}

	public void OpenLevel(string levelName){
		Debug.Log("Opening " + levelName);
		SceneManager.LoadScene(levelName);
		Debug.Log("Done loading");
	}

	public void GameOver(){
		UIManager.instance.UpdateInformation("Game over");

		// Completely destroy the squad (even through they're all dead)
		Destroy(SquadManager.instance.gameObject);
	}
}
