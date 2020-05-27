using UnityEngine;
public interface IPlayerMovement 
{
	bool BMovementActive { get; set; }
	Quaternion QRotation { get; set; }
	Vector3 Vec3AlternateDirection { get; set; }
	Rigidbody PlayerRigidbody { get; }
	void Movement();
}
