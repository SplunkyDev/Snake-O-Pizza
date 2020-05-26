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

	[Header("Player Avatar (Blue,Yellow,Red,Green)")]
	[SerializeField] private Image[] m_arrPlayerAvatar;
	[SerializeField] private Sprite[] m_arrDiceSprite;

	private Animator[] m_arrAnimController;
	private Image[] m_arrDiceImage;

	private Vector2 m_vec2ScaleValue;
	private Image m_imgPrevAvatar, m_imgCurrentAvatar, m_imgCurrentDiceRoll;


	public GameObject m_gResultPrefab;
	public GameObject m_gGridResult;
	public Text m_textGameInstruction, m_textConnectionError, m_textBluePlayer, m_textYelloPlayer, m_textRedPlayer, m_textGreenPlayer;

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

	
}