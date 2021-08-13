using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackControl : MonoBehaviour
{
    public GameObject[] tracks = new GameObject[3];
    public int speedBase, speedCtrl;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        Transform playerPosi = GameObject.FindGameObjectWithTag("Player").transform;
        float length = Mathf.Abs(transform.position.x - playerPosi.position.x);
        speed = length / speedBase * speedCtrl;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
