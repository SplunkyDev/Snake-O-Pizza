using UnityEngine;
public interface IPlayerMovement 
{
	bool BMovementActive { get; set; }
	Rigidbody PlayerRigidbody { get; }
	void Movement();
}
