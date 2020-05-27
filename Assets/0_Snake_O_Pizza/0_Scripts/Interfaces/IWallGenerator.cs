using System.Collections.Generic;
using UnityEngine;

public interface IWallGenerator 
{
	List<GameObject> LTileData { get; }
	void AddTileToList(GameObject a_gTile);
	void GenerateWalls();
}
