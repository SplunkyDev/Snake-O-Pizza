using System.Collections;
using System.Collections.Generic;
using GameUtility.Base;
using UnityEngine;
using Zenject;

public class TileData : MonoBehaviour, ITile
{
	[SerializeField] private Color m_colorMaterial;
	public Color TileColor { get => m_colorMaterial; }

	private Renderer m_renderer;
	private GameUtility.Base.eTileState m_enumTileState;
	public eTileState ETileState { get => m_enumTileState; }

	//TODO: Inject Collectible Manager
	//[Inject]
	//private void Construct()
	//{

	//}

	public void ChangeTileState()
	{
		m_enumTileState = GameUtility.Base.eTileState.Conquered;
		m_renderer.sharedMaterial.color = m_colorMaterial;
	}

	// Start is called before the first frame update
	void Start()
	{
		m_enumTileState = GameUtility.Base.eTileState.Unconquered;
		m_renderer = GetComponent<Renderer>();
		m_renderer.sharedMaterial = new Material(Shader.Find("Diffuse"));
		m_renderer.sharedMaterial.color = m_colorMaterial;
	}

	public class TileFactory : PlaceholderFactory<Vector3, TileData>{}

}
