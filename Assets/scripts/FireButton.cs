using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FireButton : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    bool buttonPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        buttonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnPointerDown(PointerEventData eventData)
    {

        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public bool isPressed()
    {
        return Input.GetButton("Fire1") || buttonPressed;
    }


}
