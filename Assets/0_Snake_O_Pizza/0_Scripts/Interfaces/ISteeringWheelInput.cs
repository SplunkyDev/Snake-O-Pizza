using UnityEngine;
using UnityEngine.EventSystems;

public interface ISteeringWheelInput 
{
	void PressEvent(BaseEventData eventData);
	void DragEvent(BaseEventData eventData);
	void ReleaseEvent(BaseEventData eventData);
}
