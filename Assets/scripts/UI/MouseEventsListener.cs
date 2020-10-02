using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEventsListener : MonoBehaviour,UIElement
{
    [SerializeField]
    UIEventListener listener;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseEnter()
    {

        listener.onUIEvent(Constant.MOUSE_EVENT_ENTER, transform, null);
    }


    private void OnMouseExit()
    {

        listener.onUIEvent(Constant.MOUSE_EVENT_EXIT, transform, null);
    }
    private void OnMouseUp()
    {

        listener.onUIEvent(Constant.MOUSE_EVENT_UP, transform, null);
    }

    private void OnMouseDown()
    {

        listener.onUIEvent(Constant.MOUSE_EVENT_DOWN, transform, null);
    }

    public void setMouseEventListener(UIEventListener listener)
    {
        
    }

    public void setUIListner(UIEventListener listener)
    {
        this.listener = listener;
    }
}
