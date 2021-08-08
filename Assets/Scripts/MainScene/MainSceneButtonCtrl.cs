using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneButtonCtrl : MonoBehaviour
{
    public void RightClick()
    {
        EventCenter.GetInstance().EventTrigger<int>("RightCameraShift", 1);
    }
    public void LeftClick()
    {
        EventCenter.GetInstance().EventTrigger<int>("RightCameraShift", -1);
    }
}
