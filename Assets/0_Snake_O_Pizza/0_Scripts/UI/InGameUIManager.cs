using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtility.Base;
using UnityEngine.UI;
using DG.Tweening;


public class InGameUIManager : MonoBehaviour
{

	public Text m_textInGameScore, m_textGCScore;
	private int m_iGameScore;

	private void RegisterToEvent()
	{
		EventManager.Instance.RegisterEvent<EventUpdateScore>(UpdateScore);
	}

	private void DeregisterToEvent()
	{
		if (EventManager.Instance == null)
		{
			return;
		}
		EventManager.Instance.DeRegisterEvent<EventUpdateScore>(UpdateScore);

	}


	private void OnEnable()
	{
		RegisterToEvent();
	}

	private void OnDisable()
	{
		DeregisterToEvent();
	}

	private void Start()
    {
		DOTween.Init(true, false, LogBehaviour.Verbose);
	}


	// This Updates the score in th UI when this event is triggered
	private void UpdateScore(IEventBase a_Event)
	{
		EventUpdateScore data = a_Event as EventUpdateScore;
		if (data == null)
			return;
		m_iGameScore = data.IScore;
		m_textGCScore.text = m_textInGameScore.text = m_iGameScore.ToString();
	}

	private void Update()
    {
        
    }

	public void InputButton(string a_strButton)
	{
		switch (a_strButton)
		{
			case "GamePause":
				GameManager.Instance.GamePaused();
				break;
			case "GameResume":
				Debug.Log("Resume Game");
				TimeScale();
				GameManager.Instance.GameResumed();
				break;
			case "Home":
				TimeScale();
				GameManager.Instance.GoHome();
				break;
			case "OK":			
				GameManager.Instance.GoHome();
				break;
		}

	}

	//change timescale
	public void TimeScale()
	{
		GameManager.Instance.TimeScaleChange();
	}


}