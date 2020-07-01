using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image backgroundImage;
    private Image joysticImage;
    private Vector3 inputVector;
    [SerializeField]
    Color backgroundImageActiveColor = Color.red;
    [SerializeField]
    Color joysticImageActiveColor = Color.red;

    Color joysticImageStartColor;
    Color backgroundImageStartColor;
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(backgroundImage.rectTransform, eventData.position, eventData.pressEventCamera, out position))
        {
            position.x = (position.x / backgroundImage.rectTransform.sizeDelta.x);
            position.y = (position.y / backgroundImage.rectTransform.sizeDelta.y);

            if (position.magnitude > 1.0f)
            {
                inputVector = position.normalized;
            }
            else
            {
                inputVector = position;
            }

            joysticImage.rectTransform.anchoredPosition = new Vector3(inputVector.x * (backgroundImage.rectTransform.sizeDelta.x / 2), inputVector.y * (backgroundImage.rectTransform.sizeDelta.y / 2));


        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
        joysticImage.color = joysticImageActiveColor;
        backgroundImage.color = backgroundImageActiveColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector3.zero;
        joysticImage.rectTransform.anchoredPosition = Vector3.zero;

        joysticImage.color = joysticImageStartColor;
        backgroundImage.color = backgroundImageStartColor;

    }


    public float getHorizontalAxis()
    {
        if (inputVector.x != 0)
        {

            return inputVector.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }

    }


    public float getVerticalAxis()
    {
        if (inputVector.y != 0)
        {

            return inputVector.y;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }

    }



    // Start is called before the first frame update
    void Start()
    {
        backgroundImage = GetComponent<Image>();
        joysticImage = transform.GetChild(0).GetComponent<Image>();

        backgroundImageStartColor= backgroundImage.color ;
        joysticImageStartColor = joysticImage.color;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
