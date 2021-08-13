using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Note : MonoBehaviour
{
    private BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        box = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EventCenter.GetInstance().EventTrigger("NoteHit");
            //add partical effect
            Destroy(this);
        }
    }
}
