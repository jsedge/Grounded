using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GameObject levelSelect;
	public GameObject hud;
	public static GameManager instance;

	void Start(){
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(gameObject);
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
		var player = GameObject.FindGameObjectWithTag("Player");
		if(player != null)
			player.SetActive(!player.activeSelf);
	}

	public void OpenLevel(string levelName){
		SceneManager.LoadScene(levelName);
	}
}
