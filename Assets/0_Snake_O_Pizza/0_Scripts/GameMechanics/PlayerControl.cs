using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerControl : MonoBehaviour, IPlayerInput
{

	private IGetInputValue m_refGetInputvalues;

	[Inject]
	void Construct(IGetInputValue a_refGetInputValue)
	{
		Debug.Log("[PlayerControl] Injecting IGetInputValue");
		m_refGetInputvalues = a_refGetInputValue;
	}

	public float UserInputs()
	{
		return m_refGetInputvalues.GetClampedValue();
	}
}
