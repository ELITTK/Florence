using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class VCAMcontrol : MonoBehaviour
{
    public GameObject[] VCam = new GameObject[4];
    //0 front 1 left 2 back 3 right
    int currentCam = 0;
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.GetInstance().AddEventListener<int>("RightCameraShift",CameraShift);
        for (int i = 0; i < 4; i++)
        {
            if (VCam[i].activeInHierarchy)
            {
                currentCam = i;
                break;
            }
        }
    }
    
    void CameraShift(int i)
    {
        VCam[(currentCam + i + 4) % 4].SetActive(true);
        VCam[currentCam].SetActive(false);
        currentCam = (currentCam + i) % 4;
    }
}
