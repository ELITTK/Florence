using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    private Animator Anim_box;
    public GameObject CD;
    // Start is called before the first frame update
    void Start()
    {
        Anim_box= GetComponent<Animator>();
        CD.GetComponent<cd>().enabled = false;

    }

    // Update is called once per frame
    void OnMouseDown()
    {
        
        Anim_box.SetTrigger("click");
        CD.GetComponent<cd>().enabled = true;
    }
}
