using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBallMove : MonoBehaviour
{
    public float moveSpeed=4;

    private Vector3 moveDir = new Vector3(0,0,0);

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //移动
        moveDir.z = Input.GetAxisRaw("Horizontal");
        moveDir.x = -Input.GetAxisRaw("Vertical");
        moveDir.Normalize();
        transform.Rotate(0, 0.6f, 0);

    }

    private void FixedUpdate()
    {
        Movement();
    }

    /// <summary>
    /// 地面移动
    /// </summary>
    private void Movement()
    {
        rb.velocity = moveDir * moveSpeed * Time.deltaTime;
        //rb.MovePosition(transform.position + moveDir * moveSpeed * Time.deltaTime);
    }
}
