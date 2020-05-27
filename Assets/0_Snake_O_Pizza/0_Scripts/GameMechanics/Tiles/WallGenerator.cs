using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WallGenerator : MonoBehaviour, IWallGenerator
{
	private const int WALLS = 4;
	
	[SerializeField] private List<GameObject> m_lstTileData = new List<GameObject>();
	public List<GameObject> LTileData { get => m_lstTileData; }
	private ITileGenerator m_refTileGenerator;
	private GameObject m_gWallParent;
	[Inject]
	private void Construct(ITileGenerator a_refTileGenerator)
	{
		Debug.Log("[WallGenerator] initialize TileGenerator");
		m_refTileGenerator = a_refTileGenerator;
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void GenerateWalls()
	{
		
	}

	public void AddTileToList(GameObject a_gTile)
	{

		if(m_gWallParent == null)
		{
			m_gWallParent = new GameObject("Wall_Parent");
			m_gWallParent.transform.position = Vector3.zero;
		}

		m_lstTileData.Add(a_gTile);

		if (m_lstTileData.Count != 4)
			return;

		for(int i =0; i<WALLS;i++)
		{
			GameObject gWall = Instantiate(m_refTileGenerator.GTile, m_lstTileData[i].transform.position, Quaternion.identity, m_gWallParent.transform);
			gWall.name = "Wall_" + (i + 1);
			gWall.AddComponent<Barricade>();
			gWall.tag = "Wall";

			switch (i)
			{
				case 0:
					if (m_refTileGenerator.IColumnNumber % 2 == 0)
					{
						gWall.transform.position += new Vector3(-0.5f, 0.5f, -1);
					}
					else
					{
						gWall.transform.position += new Vector3(0f, 0.5f, -1);
						
					}
					gWall.transform.localScale = new Vector3(m_refTileGenerator.IColumnNumber + 1, 1, 1);
					break;
				case 1:
					if (m_refTileGenerator.IRowNumber % 2 == 0)
					{
						gWall.transform.position += new Vector3(-1f, 0.5f, -0.5f);
					}
					else
					{
						gWall.transform.position += new Vector3(-1f, 0.5f, 0);
					
					}
					gWall.transform.localScale = new Vector3(1, 1, m_refTileGenerator.IRowNumber + 1);
					break;
				case 2:
					if (m_refTileGenerator.IRowNumber % 2 == 0)
					{
						gWall.transform.position += new Vector3(1f, 0.5f, -0.5f);
					}
					else
					{
						gWall.transform.position += new Vector3(1f, 0.5f, 0);
					
					}
					gWall.transform.localScale = new Vector3(1, 1, m_refTileGenerator.IRowNumber + 1);
					break;
				case 3:

					if (m_refTileGenerator.IColumnNumber % 2 == 0)
					{
						gWall.transform.position += new Vector3(-0.5f, 0.5f, 1);
					}
					else
					{
						gWall.transform.position += new Vector3(0f, 0.5f, 1);						
					}
					gWall.transform.localScale = new Vector3(m_refTileGenerator.IColumnNumber + 1, 1, 1);
					break;
			}
		}
	}
}
