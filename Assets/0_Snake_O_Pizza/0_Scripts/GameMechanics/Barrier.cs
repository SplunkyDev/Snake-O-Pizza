using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour, IImpact
{
	[SerializeField]private float m_fForceValue = 5;
	private Vector3 m_vec3AlternateDirection;
	private ContactPoint contact;

	void Start()
    {
        
    }

	void OnCollisionEnter(Collision a_col)
	{
		if (!a_col.gameObject.CompareTag("Player"))
			return;

		Debug.Log("[Barrier] Snake Collided");
		Impact(a_col);
	}

	public void Impact(Collision a_col)
	{
		Rigidbody _rigidBody = a_col.gameObject.GetComponent<Rigidbody>();
		if(_rigidBody == null)
		{
			Debug.Log("[BArrier] No rigidbofy found");
			return;
		}

		contact = a_col.contacts[0];
		m_vec3AlternateDirection = contact.normal * -1;
		StartCoroutine(DisableForwardVelocityTemp(a_col.gameObject.GetComponent<IPlayerMovement>()));
	}

	private IEnumerator DisableForwardVelocityTemp(IPlayerMovement a_refPlayerMovement)
	{
		if (a_refPlayerMovement == null)
		{
			Debug.LogError("[Barrier] PlayerMovement ref null");
			yield break;
		}

		a_refPlayerMovement.BMovementActive = false;
		a_refPlayerMovement.Vec3AlternateDirection = m_vec3AlternateDirection;		
	}



}
