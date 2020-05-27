using UnityEngine;

public interface ITile 
{
	Color TileColor { get; }
	GameUtility.Base.eTileState ETileState { get; }
	void ChangeTileState();
}
