using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handle : MonoBehaviour
{
    private Animator Anim_hand;
    // Start is called before the first frame update
    void Start()
    {
        Anim_hand = GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
      
           Anim_hand.SetTrigger("click");
            
    }
}
