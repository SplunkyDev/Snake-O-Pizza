using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour, IScore
{
	private int m_iScore;
	public int IScore { get => m_iScore; }

	public void UpdateScore(int a_iScore)
	{
		m_iScore += a_iScore;
	}

	void Start()
    {
        
    }

}
