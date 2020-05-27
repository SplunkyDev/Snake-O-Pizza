using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraSetup : MonoBehaviour, ICameraPositioning
{
	private ITileGenerator m_refTileGenrator;
	private Camera m_Camera;
	[Inject]
	private void Construct(ITileGenerator a_refTileGenrator)
	{
		m_refTileGenrator = a_refTileGenrator;
	}

	void Start()
    {
		m_Camera = Camera.main;
		SetCameraPosition();
    }

	public void SetCameraPosition()
	{
		m_Camera.transform.position = new Vector3((m_refTileGenrator.IRowNumber / 4), (m_refTileGenrator.IRowNumber + 2), (m_refTileGenrator.IRowNumber / 2));
	}


}
