using System.Collections;
using GameUtility.Base;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameManager : MBSingleton<GameManager>
{

	private eGameState m_enumGameState;
	public eGameState EnumGameState { get => m_enumGameState; set => m_enumGameState = value; }

	void RegisterToEVents()
	{

	}

	void DeregisterToEvents()
	{
		if (EventManager.Instance == null) return;

	}


	private void OnEnable()
	{
		RegisterToEVents();
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnDisable()
	{
		DeregisterToEvents();
		SceneManager.sceneLoaded -= OnSceneLoaded;	
	}


	private void OnSceneLoaded(Scene a_scene, LoadSceneMode a_loadMode)
	{
		switch(a_scene.buildIndex)
		{
			case 0:
				EventManager.Instance.TriggerEvent<EventShowMenuUI>(new EventShowMenuUI(true, eGameState.Menu));
				break;
			case 1:				
				break;
		}
	}

	public IEnumerator LoadScene(int a_iBuildIndex)
	{
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene(a_iBuildIndex,LoadSceneMode.Single);
	}



}