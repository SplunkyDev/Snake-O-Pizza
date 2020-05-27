
using UnityEngine;

public interface ITileGenerator 
{
	System.Collections.Generic.List<ITile> LTileData { get; }
	GameObject GTile { get; }
	int IRowNumber { get; }
	int IColumnNumber { get; }
	void GenerateTiles();
}
