using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSceneBase : MonoBehaviour
{
    public int bpm;
    public float introTime;

    private float noteTime, timer;
    private bool isIntroed = false;
    // Start is called before the first frame update
    void Start()
    {
        noteTime = 3600 / bpm;
        EventCenter.GetInstance().AddEventListener("NoteHit",SceneCtrl);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        NoteCtrol();
    }

    void NoteCtrol()
    {
        timer += Time.deltaTime;
        if (isIntroed)  
        {
            //开头已完成
            if (timer > noteTime)
            {
                timer -= noteTime;
                EventCenter.GetInstance().EventTrigger("NoteGenerate");
            }
        }
        else 
        {
            if (timer > introTime)
            {
                isIntroed = true;
                timer -= introTime;
            }
        }
    }

    void SceneCtrl()
    {
        //演出控制部分
    }
}
