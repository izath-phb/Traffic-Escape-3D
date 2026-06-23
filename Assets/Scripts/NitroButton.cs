using UnityEngine;
using UnityEngine.EventSystems;

public class NitroButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool nitroPressed = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        nitroPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        nitroPressed = false;
    }
}