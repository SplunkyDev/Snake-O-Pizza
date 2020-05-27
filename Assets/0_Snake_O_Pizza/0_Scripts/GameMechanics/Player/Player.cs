using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IPlayer
{
	public GameObject GPlayer { get => gameObject; }

	[Inject]
	private void Construct(Vector3 a_vec3Posi)
	{
		transform.position = a_vec3Posi;
	}

	void Start()
    {
        
    }

	public void CollectibleEaten()
	{
		//TODO: Update score
	}

	private void OnTriggerEnter(Collider a_col)
	{
		if(a_col.gameObject.CompareTag("Collectible"))
		{
			CollectibleEaten();

		}
	}

	public class PlayerFactory : PlaceholderFactory<Vector3, Player> { }
}
