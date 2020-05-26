using UnityEngine;
public interface IPlayerMovement 
{
	Rigidbody PlayerRigidbody { get; }
	void Movement();
}
