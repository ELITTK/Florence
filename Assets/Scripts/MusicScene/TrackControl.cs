using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class TrackControl : MonoBehaviour
{
    public GameObject[] tracks = new GameObject[3];
    public GameObject Note;
    public int speedBase, speedCtrl;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        Transform playerPosi = GameObject.FindGameObjectWithTag("Player").transform;
        float length = Mathf.Abs(transform.position.x - playerPosi.position.x);
        speed = length / speedBase * speedCtrl;
        EventCenter.GetInstance().AddEventListener("NoteGenerate", NoteGenerate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void NoteGenerate()
    {

    }
}
