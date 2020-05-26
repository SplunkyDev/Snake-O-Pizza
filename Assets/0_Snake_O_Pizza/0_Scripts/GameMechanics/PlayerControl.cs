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
		m_refGetInputvalues = a_refGetInputValue;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void UserInputs()
	{
		throw new System.NotImplementedException();
	}
}
