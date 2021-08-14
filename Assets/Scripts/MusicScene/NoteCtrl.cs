using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class NoteCtrl : MonoBehaviour
{
    public float speed = 0;
    private ParticleSystem particle;
    public RectTransform rectTrans;
    private BoxCollider box;
    // Start is called before the first frame update
    void Start()
    {
        particle = transform.Find("SoundEffect").gameObject.GetComponent<ParticleSystem>();
        particle.Stop();
        rectTrans = gameObject.GetComponent<RectTransform>();
        box = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EventCenter.GetInstance().EventTrigger("NoteHit");
            //add partical effect here

            particle.Play();
            StartCoroutine(Timer(1.5f));
            particle.Stop();
            gameObject.SetActive(false);
        }
    }

    void Movement()
    {
        rectTrans.position = new Vector2(rectTrans.position.x - speed, rectTrans.position.y);//ÊäÈë×ø±ê
    }
    IEnumerator Timer(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
        }
    }
    /*
    public void PositionSet(RectTransform tar)
    {
        rectTrans.position = tar.position;
    }
    */
}
