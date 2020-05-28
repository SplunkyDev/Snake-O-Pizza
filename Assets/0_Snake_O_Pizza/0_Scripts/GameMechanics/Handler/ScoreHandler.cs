using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtility.Base;

public class ScoreHandler : MonoBehaviour, IScore
{
	private int m_iScore;
	public int IScore { get => m_iScore; }

	//Updates the score and the calls event to update UI
	public void UpdateScore(int a_iScore)
	{
		m_iScore += a_iScore;
		EventManager.Instance.TriggerEvent<EventUpdateScore>(new EventUpdateScore(m_iScore));
	}

	

}
