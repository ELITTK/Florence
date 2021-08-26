using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���϶��Խ�����ϵ�����
/// </summary>
public class DragItem : MonoBehaviour
{
    public float limitY=1.3f;//Y�������ڴ�ֵ
    public static float adjustZ = 0f;//Z�������������Ʒ����Զ�����Z����ֵ
    //public float limitMaxY = 2f;//Y�������������Ʒ����ƷYֵ������ڸ�ֵ
    //private float limitMinY;//Y�������������Ʒ����ƷYֵ������ڸ�ֵ��Ĭ��Ϊ��Ʒ��ʼyֵ+0.18

    private bool isInRightPlace = false;//�Ƿ��ڿɷ��õ���������
    private bool isPlaced = false;//�Ƿ��Ѿ�����

    private int mouseState = 0;//0:����ɿ���1:��갴��

    protected Vector3 startPos;

    protected Camera cam;//�������

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
            //�������ѡȡ������
            mouseState = 1;
        }
        else if (Input.GetMouseButtonUp(0))//�ɿ����
        {
            LandPointParticleMng.Instance.DisableParticle();

            mouseState = 0;
            if (isInRightPlace)
            {
                //������Ʒ
                isPlaced = true;
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.useGravity = true;
                rb.isKinematic = false;

                EventCenter.GetInstance().EventTrigger<GameObject>("������Ʒ", gameObject);
            }
            else
            {
                transform.position = startPos;//���巵�س�ʼλ��
            }
        }


        if (mouseState == 1)//һֱ�������
        {
            //λ��
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

            //��ֱ��������
            Vector3 direction = new Vector3(0,-1,0);

            RaycastHit hitDown;

            Physics.Raycast(transform.position+new Vector3(0,-1,0), direction, out hitDown, 300);
            Debug.DrawLine(transform.position, hitDown.point);

            LandPointParticleMng.Instance.SetLandParticle(hitDown.point);

            }
        }




    public void GetInRightPlace() //�����˿ɷ��õ�����
    {
        isInRightPlace = true;
    }

    public void GetOutRightPlace() //�����˿ɷ��õ�����
    {
        isInRightPlace = false;
    }
}
