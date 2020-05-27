using UnityEngine;

public interface ITile 
{
	int ITileID { get; }
	GameObject GTile { get; }
	Color TileColor { get; }
	GameUtility.Base.eTileState ETileState { get; }
	void ChangeTileState();
}
