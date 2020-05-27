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
	
	private GameObject m_gParent;
	private IWallGenerator m_refWallGenerator;

	[Inject]
	private void Construct(IWallGenerator a_refWallGenerator)
	{
		Debug.Log("[TilesGenerator] initialize WallGenerator");
		m_refWallGenerator = a_refWallGenerator;
	}

	void Start()
    {
		if(m_gParent == null)
		{
			m_gParent = new GameObject("TileParent");
			m_gParent.transform.position = Vector3.zero;
		}

		GenerateTiles();
		
    }

	public void GenerateTiles()
	{
		int iCount = 0;
		for (int i = 0; i < m_iRowNumber; i++)
		{
			for (int j = 0; j < m_iColNumber; j++)
			{
				GameObject gTile = Instantiate(m_gTile, new Vector3(j, -0.5f, i), Quaternion.identity, m_gParent.transform);
				gTile.name = "Tile_" + (++iCount);


				//Taking the mid tiles, will use these mid tiles postion to male the walls
				if (i == 0 || (i == m_iRowNumber-1) )
				{				
					if(Mathf.Floor(m_iColNumber/2) == j)
					{
						m_refWallGenerator.AddTileToList(gTile);
					}
				}
				else if (Mathf.Floor(m_iRowNumber / 2) == i)
				{
					if (j == 0 || j== (m_iColNumber-1))
					{
						m_refWallGenerator.AddTileToList(gTile);
					}
				}			
			}
		}
	}
		
}
