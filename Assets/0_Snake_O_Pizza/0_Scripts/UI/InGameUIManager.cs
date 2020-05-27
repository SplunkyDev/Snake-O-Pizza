using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtility.Base;
using UnityEngine.UI;
using DG.Tweening;


public class InGameUIManager : MonoBehaviour
{
	private static InGameUIManager m_instance;
	public static InGameUIManager Instance
	{
		get
		{
			if(m_instance == null)
			{
				m_instance = FindObjectOfType<InGameUIManager>();
			}
			return m_instance;
		}
	}

	public Text m_textInGameScore, m_textGCScore;

	private void RegisterToEvent()
	{
		if(EventManager.Instance == null)
		{
			Debug.LogError("[InGameUIManager] EventManager is null");
			return;
		}

	}

	private void DeregisterToEvent()
	{
		if (EventManager.Instance == null)
		{
			return;
		}

	}

	private  void Awake()
	{
		if(m_instance == null)
		{
			m_instance = this;
		}
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

    private void Update()
    {
        
    }

	public void InputButton(string a_strButton)
	{
		switch (a_strButton)
		{
			case "GamePause":
				break;
			case "GameResume":				
				break;
			case "Home":
				break;
			case "OK":
				break;
		}

	}


}