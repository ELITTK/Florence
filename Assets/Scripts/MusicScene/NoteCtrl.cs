using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class NoteCtrl : MonoBehaviour
{
    public float speed = 0;
    
    public RectTransform rectTrans;
    public Vector3 initialPosition, tarPosition;
    public float smoothTime = 0.3F;

    private ParticleSystem particle;
    private BoxCollider box;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        particle = transform.Find("SoundEffect").gameObject.GetComponent<ParticleSystem>();
        particle.Stop();
        rectTrans = gameObject.GetComponent<RectTransform>();
        box = gameObject.GetComponent<BoxCollider>();

    }
    private void Awake()
    {
        particle = transform.Find("SoundEffect").gameObject.GetComponent<ParticleSystem>();
        particle.Stop();
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
        if (initialPosition.x - transform.position.x > 700)
        {
            gameObject.SetActive(false);
        }
        //rectTrans.position = new Vector2(rectTrans.position.x - speed, rectTrans.position.y);
        transform.position = Vector3.SmoothDamp(transform.position, tarPosition, ref velocity, smoothTime);

    }   
    IEnumerator Timer(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
        }
    }

    public void Initialize()
    {
        tarPosition = new Vector3(initialPosition.x - 800, initialPosition.y, initialPosition.z);
        transform.position = initialPosition;
    }
    /*
    public void PositionSet(RectTransform tar)
    {
        rectTrans.position = tar.position;
    }
    */
}
