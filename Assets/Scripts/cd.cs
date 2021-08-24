using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cd : MonoBehaviour
{
    private Animator Anim_cd;
    public GameObject Handle;
    // Start is called before the first frame update
    void Awake()
    {
        Anim_cd = GetComponent<Animator>();
        
    }
    void Start()
    {
       

    }

    void OnMouseDown()
    {
        Anim_cd.SetTrigger("click");
        Handle.GetComponent<handle>().enabled = true;
    }

    // Update is called once per frame
    
}