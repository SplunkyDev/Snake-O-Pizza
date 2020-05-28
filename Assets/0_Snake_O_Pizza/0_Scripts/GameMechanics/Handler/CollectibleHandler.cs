using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class CollectibleHandler : MonoBehaviour, ICollectible
{
	private Dictionary<int, ITile> m_dicTile = new Dictionary<int, ITile>();
	public Dictionary<int, ITile> DTile => m_dicTile;

	[SerializeField] private GameObject m_gCollectible;
	[Header("The length of time the collectible will remain in scene")]
	[SerializeField] private float m_fLiveTimer;
	[Header("The length of time between the next appearance of collective")]
	[SerializeField] private float m_fIntervalTimer;

	private float m_fCurentInterval;
	private GameObject m_gInGameCollectible;
	private Vector3 m_vec3OutBound, m_vec3Offset;
	private Coroutine m_coTimer, m_coInterval;

	private IScore m_RefScoreHandler;

	[Inject]
	private void Construct(IScore a_refScoreHandler)
	{
		m_RefScoreHandler = a_refScoreHandler;
	}

	//This is called the place the collectible on the tile that is available
	public void PlaceCollectibleInGame()
	{

		if (m_dicTile.Count <= 0)
		{
			Debug.Log("[CollectibleHandler] All tiles conquered");
			return;
		}

		int iRandom = Random.Range(0, m_dicTile.Count);
		int key = m_dicTile.ElementAt(iRandom).Key;

		m_gInGameCollectible.transform.position = m_dicTile[key].GTile.transform.position + m_vec3Offset;
		m_coTimer = StartCoroutine(CollectibleTimer());
	}

	//delay control for the life of collectible
	private IEnumerator CollectibleTimer()
	{
		yield return new WaitForSeconds(m_fLiveTimer);
		CollectibleNotTaken();
		if(m_coTimer != null)
		{
			StopCoroutine(m_coTimer);
			m_coTimer = null;
		}
	}

	//delay control for the interval
	private IEnumerator CollectibleInterval()
	{
		//Randomizing interval
		m_fCurentInterval = Random.Range(3, m_fIntervalTimer);
		yield return new WaitForSeconds(m_fCurentInterval);

		while (GameManager.Instance.EnumGameState != GameUtility.Base.eGameState.InGame)
		{
			yield return null;
		}

		PlaceCollectibleInGame();
		if (m_coInterval != null)
		{
			StopCoroutine(m_coInterval);
			m_coInterval = null;
		}
	}

	//This is called when the LiveTimer of the collectible ends 
	public void CollectibleNotTaken()
	{
		m_gInGameCollectible.transform.position = m_vec3OutBound;

		if (m_coInterval == null)
			m_coInterval = StartCoroutine(CollectibleInterval());

	}

	//This is called when the collectible has been picked up
	public void CollectibleTake()
	{
		if(AudioManager.Instance)
		{
			AudioManager.Instance.PlaySound("PickUp");
		}

		m_gInGameCollectible.transform.position = m_vec3OutBound;
		m_RefScoreHandler.UpdateScore(1);

		if (m_coTimer != null)
		{
			StopCoroutine(m_coTimer);
			m_coTimer = null;
		}

		if (m_coInterval == null)
			m_coInterval = StartCoroutine(CollectibleInterval());
	}

	//Initializing all tile data, after it has been generated
	public void InitializeTileData(List<ITile> a_lstTile)
	{
		for(int i =0; i<a_lstTile.Count;i++)
		{
			m_dicTile.Add(a_lstTile[i].ITileID, a_lstTile[i]);
		}

		m_coInterval = StartCoroutine(CollectibleInterval());
	}

	//Update the tile on which the collectible can be placed
	public void UpdateAvailableTile(ITile a_refTile)
	{
		m_dicTile.Remove(a_refTile.ITileID);
		if(m_dicTile.Count <=0)
		{
			if (m_coTimer != null)
			{
				StopCoroutine(m_coTimer);
				m_coTimer = null;
			}

			if (m_coInterval != null)
			{
				StopCoroutine(m_coInterval);
				m_coInterval = null;
			}
			GameManager.Instance.GameComplete();
		}
	}


	void Start()
    {
		m_vec3OutBound = new Vector3(1000, 1000, 1000);
		m_vec3Offset = new Vector3(0, 0.5f, 0);
		m_gInGameCollectible = Instantiate(m_gCollectible, m_vec3OutBound, Quaternion.identity);

	}


}


