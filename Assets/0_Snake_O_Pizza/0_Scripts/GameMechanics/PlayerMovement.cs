using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPlayerMovement
{
	public Rigidbody PlayerRigidbody {  get; private set; }
	public bool BMovementActive { get;  set; }
	public Quaternion QRotation { get; set; }
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
		}
		else
		{
			//Quaternion _rot = Quaternion.LookRotation(Vec3AlternateDIrection);
			//_rot = Quaternion.Euler(0, _rot.y, _rot.z);
			//transform.rotation = Quaternion.Slerp(transform.rotation, QRotation, Time.deltaTime * m_fRotateSpeed/2);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(Vec3AlternateDirection), Time.deltaTime * m_fRotateSpeed/2);
			
		}

		PlayerRigidbody.velocity = transform.forward  * m_fSpeed;
	}

}
