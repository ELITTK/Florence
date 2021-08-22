using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSceneMain : MonoBehaviour
{
    public int bpm, introTime;
    public GameObject note;
    //public GameObject[] track = new GameObject[3];

    private float deltaNoteTime;
    private float timer = 0f;
    private BoxCollider playerBox;
    // Start is called before the first frame update
    void Start()
    {
        deltaNoteTime = 3600 / bpm;
        EventCenter.GetInstance().AddEventListener("NoteHit", NoteHit);
    }

    // Update is called once per frame
    void Update()
    {
        NoteGenerate();
    }

    void NoteGenerate()
    {
        timer += Time.deltaTime;
        if (timer > deltaNoteTime)
        {
            timer -= deltaNoteTime;
            //添加note生成方法
        }
    }

    void NoteHit()
    {
        //添加下部分演出内容
    }
}
