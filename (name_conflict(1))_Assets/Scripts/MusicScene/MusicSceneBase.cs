using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSceneBase : MonoBehaviour
{
    public int bpm;
    public float introTime;
    public GameObject sofa;
    public UIShift dialogLeft, dialogRight;
    public int clearNote;

    private float noteTime, timer;
    private bool isIntroed = false;
    private int dialogCounter;
    // Start is called before the first frame update
    void Start()
    {
        noteTime = 60 / bpm;
        Debug.Log(noteTime);
        clearNote = 0;
        dialogCounter = 0;
        EventCenter.GetInstance().AddEventListener("NoteHit",SceneCtrl);

        sofa.transform.position = new Vector3(sofa.transform.position.x, sofa.transform.position.y, 50f - clearNote / 2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        NoteCtrol();
        //SceneCtrl();
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
                //Debug.Log("NoteGenerate");
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
        clearNote++;
        sofa.transform.position = new Vector3(sofa.transform.position.x, sofa.transform.position.y, 50f - clearNote / 2f);
        if (dialogCounter % 2 == 0)
        {
            Debug.Log("entered!");
            if (dialogLeft.Shiftable())
            {
                dialogCounter++;
                dialogLeft.Show();
                Debug.Log("SHOwed!");
            }
        }
        else
        {
            if (dialogRight.Shiftable())
            {
                dialogCounter++;
                dialogRight.Show();
            }
        }
    }
}
