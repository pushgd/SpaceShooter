using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UIEventListener 
{
    void onUIEvent(int eventID, Transform transform, System.Object[] arguments);
}
