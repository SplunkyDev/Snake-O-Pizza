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
				EventManager.Instance.TriggerEvent<EventShowInGameUI>(new EventShowInGameUI(true, eGameState.InGame));
				break;
		}
	}

	public IEnumerator LoadScene(float a_fDelay, int a_iBuildIndex)
	{
		yield return new WaitForSeconds(a_fDelay);
		SceneManager.LoadScene(a_iBuildIndex,LoadSceneMode.Single);
	}

	public void GamePaused()
	{
		EventManager.Instance.TriggerEvent<EventShowInPauseUI>(new EventShowInPauseUI(true, eGameState.Pause));
	}

	public void GameResumed()
	{
		EventManager.Instance.TriggerEvent<EventShowInPauseUI>(new EventShowInPauseUI(false, eGameState.InGame));
	}

	public void GoHome()
	{
		EventManager.Instance.TriggerEvent<EventShowInPauseUI>(new EventShowInPauseUI(false, eGameState.None));
		EventManager.Instance.TriggerEvent<EventShowInGameUI>(new EventShowInGameUI(false, eGameState.None));
		EventManager.Instance.TriggerEvent<EventShowGameCompleteUI>(new EventShowGameCompleteUI(false, eGameState.None));

		StartCoroutine(LoadScene(0.25f,0));
	}

	public void TimeScaleChange()
	{
		Time.timeScale = Time.timeScale == 1 ? 0:1;
		Debug.Log("[GameManager] TimeScale: "+Time.timeScale);
	}

	public void GameComplete()
	{
		EventManager.Instance.TriggerEvent<EventShowGameCompleteUI>(new EventShowGameCompleteUI(true, eGameState.GameComplete));
	}

}