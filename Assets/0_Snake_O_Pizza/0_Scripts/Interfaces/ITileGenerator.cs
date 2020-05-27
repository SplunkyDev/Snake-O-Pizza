
using UnityEngine;

public interface ITileGenerator 
{
	GameObject GTile { get; }
	int IRowNumber { get; }
	int IColumnNumber { get; }
	void GenerateTiles();
}
