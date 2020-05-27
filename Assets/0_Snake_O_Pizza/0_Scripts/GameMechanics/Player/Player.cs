using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IPlayer
{
	public GameObject GPlayer { get => gameObject; }
	private ICollectible m_refCollectible;

	[Inject]
	private void Construct(Vector3 a_vec3Posi, ICollectible a_refCollectible)
	{
		transform.position = a_vec3Posi;
		m_refCollectible = a_refCollectible;
	}

	void Start()
    {
        
    }

	public void CollectibleEaten()
	{
		m_refCollectible.CollectibleTake();
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
