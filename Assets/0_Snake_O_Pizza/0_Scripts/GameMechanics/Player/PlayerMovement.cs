using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPlayerMovement
{
	public Rigidbody PlayerRigidbody {  get; private set; }
	public bool BMovementActive { get;  set; }
	public Vector3 Vec3AlternateDirection { get; set; }

	[Tooltip("Speed of player")]
	[SerializeField]private float m_fSpeed = 10;
	[Tooltip("Speed of Rotation")]
	[SerializeField]private float m_fRotateSpeed = 10;

	private IPlayerInput m_refPlayerInput;

	void Start()
    {
		PlayerRigidbody = GetComponent<Rigidbody>();
		m_refPlayerInput = GetComponent<IPlayerInput>();

		if (PlayerRigidbody == null)
		{
			Debug.LogError("[PlayerMovement] Player Rigidbody missing");
		}

		BMovementActive = true;

	}

    void FixedUpdate()
    {
		if (PlayerRigidbody == null)
			return;


			Movement();

	
    }

	public void Movement()
	{
		if (BMovementActive)
		{
			transform.Rotate(Vector3.up * m_refPlayerInput.UserInputs() * m_fRotateSpeed, Space.World);
			PlayerRigidbody.velocity = transform.forward * m_fSpeed;
		}
		else
		{
			if(Vector3.Angle(transform.forward,Vec3AlternateDirection) <10)
			{
				BMovementActive = true;
			}

			Vector3 vec3CollideDirection = transform.position;
			PlayerRigidbody.velocity = vec3CollideDirection * m_fSpeed/2 *-0.5f;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vec3AlternateDirection, transform.up), Time.deltaTime * m_fRotateSpeed/2);			
		}

		
	}

}
