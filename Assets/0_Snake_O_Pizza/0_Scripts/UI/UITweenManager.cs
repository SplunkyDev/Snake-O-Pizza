﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using GameUtility.Base;
using UnityEngine.Events;

public class UITweenManager : MonoBehaviour
{
	[Header("Add in the order of which UI needs to appear")]
	public UIElementTween[] m_arrChildGameObject;

	[Tooltip("Delay between each UI tween")]
	public float m_fDelay;

	[Tooltip("The ease effect")]
	public Ease m_easeType;

	[Tooltip("UI state")]
	public eGameUIState m_eGameUIState;

	private eGameState m_eGameState;
	public eGameState GameState { get => m_eGameState; }

	public UnityEvent m_unityEventTweenIn, m_unityEventTweenOut;

	void Awake()
	{
		DOTween.Init(true, true, LogBehaviour.Verbose);
		//for (int i = 0; i < m_arrChildGameObject.Length; i++)
		//{
		//	m_arrChildGameObject[i].transform.localScale = Vector3.zero;
		//}
	}

	private void OnEnable()
	{
		switch (m_eGameUIState)
		{
			case eGameUIState.None:
				Debug.LogWarning("[UITweenManager] No UI State set: " + gameObject.name);
				break;
			case eGameUIState.MenuUI:
				EventManager.Instance.RegisterEvent<EventShowMenuUI>(AnimateUI);
				break;
			case eGameUIState.InGameUI:
				EventManager.Instance.RegisterEvent<EventShowInGameUI>(AnimateUI);
				break;
			case eGameUIState.GameComplete:
				EventManager.Instance.RegisterEvent<EventShowGameCompleteUI>(AnimateUI);
				break;
			case eGameUIState.InitializeUI:
				break;
			case eGameUIState.ErrorInConnection:
				EventManager.Instance.RegisterEvent<EventShowConnectionErrorUI>(AnimateUI);
				break;
			case eGameUIState.WaitingForPlayers:
				EventManager.Instance.RegisterEvent<EventShowWaitingForPlayersUI>(AnimateUI);
				break;
			default:
				break;
		}
	}

	private void OnDisable()
	{
		if (EventManager.Instance == null)
			return;

		switch (m_eGameUIState)
		{
			case eGameUIState.None:
				Debug.LogWarning("[UITweenManager] No UI State set: " + gameObject.name);
				break;

			case eGameUIState.InGameUI:
				EventManager.Instance.DeRegisterEvent<EventShowInGameUI>(AnimateUI);
				break;
			case eGameUIState.MenuUI:
				EventManager.Instance.DeRegisterEvent<EventShowMenuUI>(AnimateUI);
				break;
			case eGameUIState.GameComplete:
				EventManager.Instance.DeRegisterEvent<EventShowGameCompleteUI>(AnimateUI);
				break;
			case eGameUIState.InitializeUI:
				break;
			case eGameUIState.ErrorInConnection:
				EventManager.Instance.DeRegisterEvent<EventShowConnectionErrorUI>(AnimateUI);
				break;
			case eGameUIState.WaitingForPlayers:
				EventManager.Instance.DeRegisterEvent<EventShowWaitingForPlayersUI>(AnimateUI);
				break;
			default:
				break;
		}
	}


	private void AnimateUI(IEventBase a_Event)
	{
		switch (m_eGameUIState)
		{
			case eGameUIState.None:
				Debug.LogWarning("[UITweenManager] No UI State set: " + gameObject.name);
				break;
			case eGameUIState.MenuUI:
				EventShowMenuUI d0;
				d0 = a_Event as EventShowMenuUI;
				if (d0 != null)
				{
					m_eGameState = d0.EGameState;
					if (d0.BShowUI)
					{
						StartCoroutine(UITweenIn());
					}
					else
					{
						StartCoroutine(UITweenOut());
					}
				}
				break;
			case eGameUIState.InGameUI:
				EventShowInGameUI d1;
				d1 = a_Event as EventShowInGameUI;
				if (d1 != null)
				{
					m_eGameState = d1.EGameState;
					if (d1.BShowUI)
					{
						StartCoroutine(UITweenIn());
					}
					else
					{
						StartCoroutine(UITweenOut());
					}
				}
				break;
			case eGameUIState.GameComplete:
				EventShowGameCompleteUI d2;
				d2 = a_Event as EventShowGameCompleteUI;
				if (d2 != null)
				{
					m_eGameState = d2.EGameState;
					if (d2.BShowUI)
					{
						StartCoroutine(UITweenIn());
					}
					else
					{
						StartCoroutine(UITweenOut());
					}
				}
				break;
			case eGameUIState.InitializeUI:
				break;
			case eGameUIState.ErrorInConnection:
				EventShowConnectionErrorUI d3;
				d3 = a_Event as EventShowConnectionErrorUI;
				if (d3 != null)
				{
					m_eGameState = d3.EGameState;
					if (d3.BShowUI)
					{
						StartCoroutine(UITweenIn());
					}
					else
					{
						StartCoroutine(UITweenOut());
					}
				}
				break;
			case eGameUIState.WaitingForPlayers:
				EventShowWaitingForPlayersUI d4;
				d4 = a_Event as EventShowWaitingForPlayersUI;
				if (d4 != null)
				{
					m_eGameState = d4.EGameState;
					if (d4.BShowUI)
					{
						StartCoroutine(UITweenIn());
					}
					else
					{
						StartCoroutine(UITweenOut());
					}
				}
				break;
			default:
				break;
		}
	}

	IEnumerator UITweenIn()
	{
		for (int i = 0; i < m_arrChildGameObject.Length; i++)
		{			
			m_arrChildGameObject[i].ElementTweenIn(0.25f);
			yield return new WaitForSeconds(m_fDelay);
		}

		//yield return new WaitForSeconds(1);
		Debug.Log("[UITweenManager] TweenIn Change GameState: " + m_eGameState);
		if(m_eGameState !=  eGameState.None)
			GameManager.Instance.EnumGameState = m_eGameState;

		if (m_unityEventTweenIn != null)
		{
			m_unityEventTweenIn.Invoke();
		}

	}


	IEnumerator UITweenOut()
	{
		for (int i = 0; i < m_arrChildGameObject.Length; i++)
		{	
			m_arrChildGameObject[i].ElementTweenOut(0.15f);
			yield return new WaitForSeconds(0.05f);
		}
		Debug.Log("[UITweenManager] TweenOut Change GameState: " + m_eGameState);

		yield return new WaitForSeconds(0.05f);
		GameManager.Instance.EnumGameState = m_eGameState;


		if (m_unityEventTweenOut != null)
		{
			m_unityEventTweenOut.Invoke();
		}


	}



}
