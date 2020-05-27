using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TilesGenerator : MonoBehaviour, ITileGenerator
{
	[SerializeField] private int m_iRowNumber, m_iColNumber;
	public int IRowNumber { get => m_iRowNumber; private set => m_iRowNumber = value; }
	public int IColumnNumber { get => m_iColNumber; private set => m_iColNumber = value; }


	[SerializeField]private GameObject m_gTile;
	public GameObject GTile { get => m_gTile; }

	private List<ITile> m_lstTileData = new List<ITile>();
	public List<ITile> LTileData { get => m_lstTileData;}

	private IWallGenerator m_refWallGenerator;
	private TileData.TileFactory m_refTileFactory;

	[Inject]
	private void Construct(IWallGenerator a_refWallGenerator, TileData.TileFactory a_refTileFactory)
	{
		Debug.Log("[TilesGenerator] initialize");
		m_refWallGenerator = a_refWallGenerator;
		m_refTileFactory = a_refTileFactory;
	}

	void Start()
    {


		GenerateTiles();
		
    }

	public void GenerateTiles()
	{
		int iCount = 0;
		for (int i = 0; i < m_iRowNumber; i++)
		{
			for (int j = 0; j < m_iColNumber; j++)
			{
				iCount++;
				//Instantiating using IoC, using IoC registers the Prefabs to the container and we can inject the references where ever required.
				TileData refTileData = m_refTileFactory.Create(iCount,new Vector3(j, -0.5f, i));
				refTileData.GTile.name = "Tile_" +iCount;
				m_lstTileData.Add(refTileData);

				//Taking the mid tiles, will use these mid tiles postion to male the walls
				if (i == 0 || (i == m_iRowNumber-1) )
				{				
					if(Mathf.Floor(m_iColNumber/2) == j)
					{
						m_refWallGenerator.AddTileToList(refTileData.GTile);
					}
				}
				else if (Mathf.Floor(m_iRowNumber / 2) == i)
				{
					if (j == 0 || j== (m_iColNumber-1))
					{
						m_refWallGenerator.AddTileToList(refTileData.GTile);
					}
				}			
			}
		}
	}
		
}
