using System.Collections;
using System.Collections.Generic;
using GameUtility.Base;
using UnityEngine;
using Zenject;

public class TileData : MonoBehaviour, ITile
{
	[SerializeField] private Color m_colorMaterial;
	public Color TileColor { get => m_colorMaterial; }
	public GameObject GTile => gameObject;
	private int m_iTileID;
	public int ITileID => m_iTileID;

	private Renderer m_renderer;
	private GameUtility.Base.eTileState m_enumTileState;
	public eTileState ETileState { get => m_enumTileState; }

	private ICollectible m_refCollectible;


	//TODO: Inject Collectible Manager
	[Inject]
	private void Construct(int a_iTileID,Vector3 a_Vec3Posi, ICollectible a_refCollectible)
	{
		m_iTileID = a_iTileID;
		transform.position = a_Vec3Posi;
		m_refCollectible = a_refCollectible;
	}

	[ContextMenu("ChangeTileState")]
	public void ChangeTileState()
	{
		m_enumTileState = GameUtility.Base.eTileState.Conquered;
		m_renderer.sharedMaterial.color = Color.green;
		m_refCollectible.UpdateAvailableTile(this);
	}

	private void OnTriggerEnter(Collider a_col)
	{
		if(a_col.gameObject.CompareTag("Player"))
		{
			if (m_enumTileState == eTileState.Conquered)
				return;

			ChangeTileState();
		}
	}

	// Start is called before the first frame update
	void Awake()
	{
		m_enumTileState = GameUtility.Base.eTileState.Unconquered;
		m_renderer = GetComponent<Renderer>();
		m_renderer.sharedMaterial = new Material(Shader.Find("Diffuse"));
		m_renderer.sharedMaterial.color = m_colorMaterial;
	}

	public class TileFactory : PlaceholderFactory<int,Vector3, TileData>{}

}
