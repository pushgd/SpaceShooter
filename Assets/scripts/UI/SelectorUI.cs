using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using UnityEngine;

public class SelectorUI : MonoBehaviour, UIEventListener,UIElement
{
    [SerializeField]
    GameObject leftButton;
    [SerializeField]
    GameObject rightButton;
    [SerializeField]
    GameObject text;


    [SerializeField]
    Info[] objects;

    
    Transform objectPosition;

    GameObject displayObject;
    private int currentIndex = 0;

    [SerializeField]
    PlaneInfo planeInfo;

    private UIEventListener listener;
    private System.Object[] args;
    
    // Start is called before the first frame update
    void Start()
    {
        leftButton = transform.Find("left").gameObject;
        leftButton.GetComponent<UIElement>().setUIListner(this);
        rightButton = transform.Find("right").gameObject;
        rightButton.GetComponent<UIElement>().setUIListner(this);
        text = transform.Find("text").gameObject;
        
        objectPosition = transform.Find("object").transform;
        onIndexChange();
        args = new System.Object[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void onIndexChange()
    {
        text.GetComponent<TextMesh>().text = objects[currentIndex].text;
        Destroy(displayObject);
        displayObject = Instantiate(objects[currentIndex].displayObject, objectPosition.position, objectPosition.rotation);
        Destroy(displayObject.GetComponent<Bullet>());


    }
 
    public void onUIEvent(int eventID, Transform transform, object[] arguments)
    {
        if (leftButton.name == transform.name)
        {
            if (eventID == Constant.MOUSE_EVENT_UP)
            {
                currentIndex--;

                if (currentIndex < 0)
                {
                    currentIndex = 0;
                }
                onIndexChange();
                args[0] = currentIndex;
                args[1] = objects[currentIndex];
                listener.onUIEvent(Constant.INDEX_DECREASED, this.transform, args);
                
            }
        }

        if (rightButton.name == transform.name)
        {
            if (eventID == Constant.MOUSE_EVENT_UP)
            {
                currentIndex++;
                if (currentIndex >= objects.Length)
                {
                    currentIndex = objects.Length - 1;
                }
            }
            onIndexChange();
            args[0] = currentIndex;
            args[1] = objects[currentIndex];
            listener.onUIEvent(Constant.INDEX_INCREASED, this.transform, args);
        }
    }

    public void setUIListner(UIEventListener listener)
    {
        this.listener = listener;
    }
}
