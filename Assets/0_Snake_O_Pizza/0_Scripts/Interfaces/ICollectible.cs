using System.Collections.Generic;
using UnityEngine;

public interface ICollectible 
{
	Dictionary<int, ITile> DTile { get; }
	void CollectibleTake();
	void CollectibleNotTaken();
	void InitializeTileData(List<ITile> a_lstTile);
	void UpdateAvailableTile(ITile a_refTile);
	void PlaceCollectibleInGame();
}
