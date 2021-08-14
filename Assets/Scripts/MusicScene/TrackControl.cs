using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class TrackControl : MonoBehaviour
{
    public RectTransform[] tracks = new RectTransform[3];
    public GameObject Note;
    public int speedBase, speedCtrl;
    public static List<GameObject> notePoolList = new List<GameObject>();
    private float speed;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        Transform playerPosi = GameObject.FindGameObjectWithTag("Player").transform;
        float length = Mathf.Abs(transform.position.x - playerPosi.position.x);
        speed = length / speedBase * speedCtrl;
        EventCenter.GetInstance().AddEventListener("NoteGenerate", NoteGenerate);

        //mat = gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void NoteGenerate()
    {
        GameObject note = PopPool();
        NoteCtrl noteF = note.GetComponentInChildren<NoteCtrl>();
        //添加初始化内容   
        noteF.rectTrans = tracks[Random.Range(0, 2)];
        noteF.rectTrans.position = tracks[Random.Range(0, 2)].position;
        noteF.speed = speed;
        note.SetActive(true);
    }

    public GameObject PopPool()
    {
        foreach (GameObject obj in notePoolList)
        {
            if (obj.activeSelf == false)
            {
                return obj;
            }
        }
        GameObject note = Instantiate(Note,GameObject.Find("Canvas").transform);
        notePoolList.Add(note);

        return note;
    }
}
