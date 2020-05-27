using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour, IAnimation
{
	public Animator AnimPlayer { get; private set; }
	private IPlayerInput m_refPlayerInput;

	void Start()
    {
		AnimPlayer = GetComponent<Animator>();
		m_refPlayerInput = GetComponent<IPlayerInput>();

	}

    void Update()
    {
		SetVelue();
    }

	public void SetVelue()
	{
		AnimPlayer.SetFloat("TurnBlend", m_refPlayerInput.UserInputs());
	}
}
