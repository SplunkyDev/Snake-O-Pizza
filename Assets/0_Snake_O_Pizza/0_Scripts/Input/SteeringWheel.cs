using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;

public class SteeringWheel : MonoBehaviour, ISteeringWheelInput, IGetInputValue
{
	public Graphic UI_Element;

	private RectTransform rectT;
	private Vector2 centerPoint;

	[SerializeField]
	private float maximumSteeringAngle = 200f;
	[SerializeField]
	private float wheelReleasedSpeed = 200f;

	private float wheelAngle = 0f;
	private float wheelPrevAngle = 0f;
	private bool wheelBeingHeld = false;

	public float GetClampedValue()
	{
		// returns a value in range [-1,1] similar to GetAxis("Horizontal")
		return wheelAngle / maximumSteeringAngle;
	}

	public float GetAngle()
	{
		// returns the wheel angle itself without clamp operation
		return wheelAngle;
	}

	void Start()
	{
		rectT = UI_Element.rectTransform;
	}

	void Update()
	{
		// If the wheel is released, reset the rotation
		// to initial (zero) rotation by wheelReleasedSpeed degrees per second
		if (!wheelBeingHeld && !Mathf.Approximately(0f, wheelAngle))
		{
			float deltaAngle = wheelReleasedSpeed * Time.deltaTime;
			if (Mathf.Abs(deltaAngle) > Mathf.Abs(wheelAngle))
				wheelAngle = 0f;
			else if (wheelAngle > 0f)
				wheelAngle -= deltaAngle;
			else
				wheelAngle += deltaAngle;
		}

		// Rotate the wheel image
		rectT.localEulerAngles = Vector3.back * wheelAngle;
	}


	public void PressEvent(BaseEventData eventData)
	{
		// Executed when mouse/finger starts touching the steering wheel
		Vector2 pointerPos = ((PointerEventData)eventData).position;

		wheelBeingHeld = true;
		centerPoint = RectTransformUtility.WorldToScreenPoint(((PointerEventData)eventData).pressEventCamera, rectT.position);
		wheelPrevAngle = Vector2.Angle(Vector2.up, pointerPos - centerPoint);
	}

	public void DragEvent(BaseEventData eventData)
	{
		// Executed when mouse/finger is dragged over the steering wheel
		Vector2 pointerPos = ((PointerEventData)eventData).position;

		float wheelNewAngle = Vector2.Angle(Vector2.up, pointerPos - centerPoint);
		// Do nothing if the pointer is too close to the center of the wheel
		if (Vector2.Distance(pointerPos, centerPoint) > 20f)
		{
			if (pointerPos.x > centerPoint.x)
				wheelAngle += wheelNewAngle - wheelPrevAngle;
			else
				wheelAngle -= wheelNewAngle - wheelPrevAngle;
		}
		// Make sure wheel angle never exceeds maximumSteeringAngle
		wheelAngle = Mathf.Clamp(wheelAngle, -maximumSteeringAngle, maximumSteeringAngle);
		wheelPrevAngle = wheelNewAngle;
	}

	public void ReleaseEvent(BaseEventData eventData)
	{
		// Executed when mouse/finger stops touching the steering wheel
		// Performs one last DragEvent, just in case
		DragEvent(eventData);

		wheelBeingHeld = false;
	}
}
