using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour, IImpact
{
	[SerializeField]private float m_fForceValue = 5;

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

		ContactPoint contact = a_col.contacts[0];
		Debug.DrawRay(contact.point, contact.normal * -1, Color.white);

		StartCoroutine(DisableForwardVelocityTemp(1, a_col.gameObject.GetComponent<IPlayerMovement>()));
		//_rigidBody.angularVelocity = (contact.normal * m_fForceValue * -1);
		_rigidBody.AddForce(contact.normal * m_fForceValue * -1);
		Debug.Log("[Barrier] FORCE ADDED");
	}

	private IEnumerator DisableForwardVelocityTemp(float a_fDelay, IPlayerMovement a_refPlayerMovement)
	{
		if (a_refPlayerMovement == null)
		{
			Debug.LogError("[Barrier] PlayerMovement ref null");
			yield break;
		}

		a_refPlayerMovement.BMovementActive = false;
		Debug.Log("[Barrier] Movement: Before Delay: "+ a_refPlayerMovement.BMovementActive);
		//a_refPlayerMovement.PlayerRigidbody.velocity = Vector3.zero;
		yield return new WaitForSeconds(a_fDelay);
		//a_refPlayerMovement.PlayerRigidbody.isKinematic = true;
		//yield return new WaitForSeconds(0.25f);
		//a_refPlayerMovement.PlayerRigidbody.velocity = Vector3.zero;
		//a_refPlayerMovement.PlayerRigidbody.isKinematic = false;
		a_refPlayerMovement.BMovementActive = true;
		Debug.Log("[Barrier] Movement: After Delay: "+ a_refPlayerMovement.BMovementActive);
	}
}
