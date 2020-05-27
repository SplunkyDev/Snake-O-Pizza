using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPlayerMovement
{
	public Rigidbody PlayerRigidbody {  get; private set; }
	public bool BMovementActive { get;  set; }

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
		transform.Rotate(Vector3.up * m_refPlayerInput.UserInputs() * m_fRotateSpeed, Space.World);
		PlayerRigidbody.velocity = transform.forward  * m_fSpeed;
	}

}
