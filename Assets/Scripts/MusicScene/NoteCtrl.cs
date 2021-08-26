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
    public float fadeTime = 1f;

    private ParticleSystem particle;
    private BoxCollider box;
    private Vector3 velocity = Vector3.zero;
    private bool moveable;
    // Start is called before the first frame update
    void Start()
    {
        particle = transform.Find("SoundEffect").gameObject.GetComponent<ParticleSystem>();
        particle.Stop();
        rectTrans = gameObject.GetComponent<RectTransform>();
        box = gameObject.GetComponent<BoxCollider>();
        moveable = true;
    }
    private void OnEnable()
    {
        particle = transform.Find("SoundEffect").gameObject.GetComponent<ParticleSystem>();
        particle.Stop();
        moveable = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveable)
        {
            Movement();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EventCenter.GetInstance().EventTrigger("NoteHit");
            //add partical effect here
            moveable = false;
            particle.Play();
            Debug.Log("start partical");
            StartCoroutine(Timer(fadeTime));
            //particle.Stop();
            //Debug.Log("stop partical");
            //gameObject.SetActive(false);
        }
    }

    void Movement()
    {
        if (initialPosition.x - transform.position.x > 300)
        {
            gameObject.SetActive(false);
        }
        //rectTrans.position = new Vector2(rectTrans.position.x - speed, rectTrans.position.y);
        transform.position = Vector3.SmoothDamp(transform.position, tarPosition, ref velocity, smoothTime);

    }   
    IEnumerator Timer(float time)
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(0.1f);
            time -= 0.1f;
        }
        particle.Stop();
        Debug.Log("stop partical");
        gameObject.SetActive(false);
        yield break;
    }

    public void Initialize()
    {
        tarPosition = new Vector3(initialPosition.x - 400, initialPosition.y, initialPosition.z);
        transform.position = initialPosition;
    }
    /*
    public void PositionSet(RectTransform tar)
    {
        rectTrans.position = tar.position;
    }
    */
}
