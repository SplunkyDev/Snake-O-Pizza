using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtility.Base;

public class MenuUIManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {	
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void InputButton(string a_strButton)
	{
		switch (a_strButton)
		{
			case "Start":
				StartCoroutine(GameManager.Instance.LoadScene(0.2f,1));
				break;
			case "Quit":
				Application.Quit();
				break;
		}

	}
}
