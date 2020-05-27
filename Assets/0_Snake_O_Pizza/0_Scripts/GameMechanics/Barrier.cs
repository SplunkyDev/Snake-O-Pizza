using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour, IImpact
{
	[SerializeField]private float m_fForceValue = 5;

	private Quaternion m_qRot;
	private Vector3 m_vec3AlternateDirection;
	private bool m_bContact = false;
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
		m_bContact = true;

		m_qRot =   Quaternion.Euler(a_col.gameObject.transform.eulerAngles.x, Random.Range(90, 180), a_col.gameObject.transform.eulerAngles.z);
		//m_vec3Direction =   a_col.gameObject.transform.position - transform.position;
		//float Angle = Vector3.Angle(a_col.transform.forward, contact.normal);
		float Angle = Vector3.Angle(a_col.transform.forward, contact.normal * -1);
		Debug.Log("[Barrier] Angle: "+Angle);
		Angle = Angle>=180? Angle - 120: Angle + 120;
		Debug.Log("[Barrier] Angle 2: " + Angle);
		m_qRot = Quaternion.AngleAxis(Angle, Vector3.up);
		m_vec3AlternateDirection = new Vector3(a_col.gameObject.transform.eulerAngles.x, Angle, a_col.gameObject.transform.eulerAngles.z);

		StartCoroutine(DisableForwardVelocityTemp(a_col.gameObject.GetComponent<IPlayerMovement>()));
		//_rigidBody.angularVelocity = (contact.normal * m_fForceValue * -1);
		_rigidBody.AddForce(contact.normal * m_fForceValue * -1);
		Debug.Log("[Barrier] FORCE ADDED");
	}

	private IEnumerator DisableForwardVelocityTemp(IPlayerMovement a_refPlayerMovement)
	{
		if (a_refPlayerMovement == null)
		{
			Debug.LogError("[Barrier] PlayerMovement ref null");
			yield break;
		}

		a_refPlayerMovement.QRotation = m_qRot;
		a_refPlayerMovement.Vec3AlternateDirection = m_vec3AlternateDirection;
		a_refPlayerMovement.BMovementActive = false;

	}

	void Update()
	{
		if(m_bContact)
			Debug.DrawRay(contact.point, contact.normal * -1, Color.white);
	}
}
