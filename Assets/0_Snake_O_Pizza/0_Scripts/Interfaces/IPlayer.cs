using UnityEngine;

public interface IPlayer 
{
	GameObject GPlayer { get; }
	void CollectibleEaten();
}
