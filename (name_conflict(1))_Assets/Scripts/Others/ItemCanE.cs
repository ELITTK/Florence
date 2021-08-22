using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ɻ�����Ʒ,��Ҫ��Ʒ��trigger
/// </summary>
public class ItemCanE : MonoBehaviour
{
    public GameObject playerInArea;//��Χ�ڿɻ�������Ʒ�����

    // Update is called once per frame
    void Update()
    {
        if (playerInArea!=null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("��һ�����Ʒ");
            }
        }
    }


    /// <summary>
    /// ��ҽ���ɻ�������ʱ
    /// </summary>
    /// <param name="collision"></param>
    protected void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponentInParent<LightBallMove>())
        {
            playerInArea = collision.gameObject;
            Debug.Log("��ҽ��뻥����Χ");
        }
    }

    /// <summary>
    /// ����뿪�ɻ�������ʱ
    /// </summary>
    /// <param name="collision"></param>
    protected void OnTriggerExit(Collider collision)
    {
        if (collision.GetComponentInParent<LightBallMove>())
        {
            playerInArea = null;
            Debug.Log("����뿪������Χ");
        }
    }
}
