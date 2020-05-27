using System.Collections.Generic;
using UnityEngine;

public interface ICollectible 
{
	Dictionary<int, ITile> DTile { get; }
	void CollectibleTake();
	void CollectibleNotTaken();
	void UpdateAvailableTile(ITile a_refTile);
}
