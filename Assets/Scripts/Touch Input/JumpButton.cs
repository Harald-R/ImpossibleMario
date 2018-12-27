using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform buttonImage;
    public Color pressedColor;

    [System.NonSerialized] public bool isPressed = false;

    private Image image;
    private Color defaultColor;

    void Start()
    {
        image = buttonImage.GetComponent<Image>();
        defaultColor = image.color;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        image.color = pressedColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        image.color = defaultColor;
    }
}
