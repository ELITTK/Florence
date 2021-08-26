using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 需拖动以进行组合的物体
/// </summary>
public class DragItem : MonoBehaviour
{
    public float limitY=1.3f;//Y轴锁定在此值
    public static float adjustZ = 0f;//Z轴调整，拿起物品后会自动调整Z到该值
    //public float limitMaxY = 2f;//Y轴调整，拿起物品后，物品Y值不会高于该值
    //private float limitMinY;//Y轴调整，拿起物品后，物品Y值不会低于该值。默认为物品初始y值+0.18

    private bool isInRightPlace = false;//是否处于可放置的区域内了
    private bool isPlaced = false;//是否已经放置

    private int mouseState = 0;//0:鼠标松开，1:鼠标按下

    protected Vector3 startPos;

    protected Camera cam;//主摄像机

    RaycastHit hit;

    void Start()
    {
        startPos = transform.position;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        //limitMinY = transform.position.y+0.18f;
    }


    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0) && hit.transform.gameObject.name == this.name && !isPlaced)
        {
            //按下鼠标选取该物体
            mouseState = 1;
        }
        else if (Input.GetMouseButtonUp(0))//松开鼠标
        {
            LandPointParticleMng.Instance.DisableParticle();

            mouseState = 0;
            if (isInRightPlace)
            {
                //放下物品
                isPlaced = true;
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.useGravity = true;
                rb.isKinematic = false;

                EventCenter.GetInstance().EventTrigger<GameObject>("放置物品", gameObject);
            }
            else
            {
                transform.position = startPos;//物体返回初始位置
            }
        }


        if (mouseState == 1)//一直按着鼠标
        {
            //位置
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);

            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pos.z);
            transform.position = Camera.main.ScreenToWorldPoint(mousePos);

            transform.position = new Vector3(transform.position.x,limitY, adjustZ);

            /*
            if (transform.position.y < limitMinY)
            {
                transform.position = new Vector3(transform.position.x, limitMinY, adjustZ);
            }
            else if (transform.position.y>limitMaxY)
            {
                transform.position = new Vector3(transform.position.x, limitMaxY, adjustZ);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, adjustZ);
            }*/

            //垂直向下射线
            Vector3 direction = new Vector3(0,-1,0);

            RaycastHit hitDown;

            Physics.Raycast(transform.position+new Vector3(0,-1,0), direction, out hitDown, 300);
            Debug.DrawLine(transform.position, hitDown.point);

            LandPointParticleMng.Instance.SetLandParticle(hitDown.point);

            }
        }




    public void GetInRightPlace() //进入了可放置的区域
    {
        isInRightPlace = true;
    }

    public void GetOutRightPlace() //进入了可放置的区域
    {
        isInRightPlace = false;
    }
}
