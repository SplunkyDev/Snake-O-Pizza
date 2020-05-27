using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerManagement : MonoBehaviour, IPlayerSetup
{

	private Player.PlayerFactory m_refPlayerFactory;
	private IPlayer m_refPlayer;


	[Inject]
	public void Construct(Player.PlayerFactory a_refPlayerFactory)
	{
		Debug.Log("[PlayerManagement] Initialize");
		m_refPlayerFactory = a_refPlayerFactory;
	}

	public void InitializePlayer(Vector3 a_vec3PointA, Vector3 a_vec3PointB)
	{

		Vector3 vec3SpawnPoint = new Vector3((a_vec3PointA.x + a_vec3PointB.x) / 2, ((a_vec3PointA.y + a_vec3PointB.y) / 2) +0.5f, (a_vec3PointA.z + a_vec3PointB.x) / 2);
		Debug.Log("[PlayerManagerMent] Mid Point: "+ vec3SpawnPoint);
		
		m_refPlayer = m_refPlayerFactory.Create(vec3SpawnPoint);
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

}
