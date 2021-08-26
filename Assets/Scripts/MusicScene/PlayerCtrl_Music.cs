using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl_Music : MonoBehaviour
{
    //public Transform[] tracks = new Transform[3];
    public float smoothTime = 0.05F;
    public float positionX;
    public float[] positionY = new float[3];
    private int current;
    //
    public bool isMoving;
    //
    private Vector3 velocity = Vector3.zero;

    private Vector3 tarPosition;
    private float horizonInput;
    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        current = 0;
        
        tarPosition = new Vector3(positionX, positionY[0], 150);
        Debug.Log(tarPosition);
        Debug.Log(transform.position);
        transform.position = tarPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizonInput = Input.GetAxis("Vertical");
        Movement();
        //Debug.Log(tarPosition); 
    }

    void Movement()
    {
        
        if (isMoving)
        {
            //Debug.Log(tarPosition);
            transform.position = Vector3.SmoothDamp(transform.position, tarPosition, ref velocity, smoothTime);
            if (Vector3.Distance(tarPosition,transform.position) < 0.2f)
            {
                isMoving = false;
            }
        }
        else
        {
            if (horizonInput > 0.2f && current > 0)
            {   
                current--;
                isMoving = true;
            }
            if (horizonInput < -0.2f && current < 2)
            {
                current++;
                isMoving = true;
            }
            
            tarPosition = new Vector3(transform.position.x, positionY[current], 150);
        }   
        //Debug.Log("isMoving");
    }   
}
