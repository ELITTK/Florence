using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ���������ϵ�˳�����ж��ؿ��Ƿ����
/// </summary>
public class ItemOrderCheck : MonoBehaviour
{
    public List<GameObject> neededOrder;
    public List<GameObject> nowOrder;

    void Start()
    {
        EventCenter.GetInstance().AddEventListener<GameObject>("������Ʒ", PlaceAddItem);
        EventCenter.GetInstance().AddEventListener("�������", CheckOrder);
    }

    public void PlaceAddItem(GameObject item)
    {
        if (!nowOrder.Contains(item))
        {
            nowOrder.Add(item);
            EventCenter.GetInstance().EventTrigger("���ü�������");
        }
    }

    public void CheckOrder()
    {
        Debug.Log("�������");
        for (int i = 0; i < neededOrder.Count; i++)
        {
            if (neededOrder[i]!=nowOrder[i])
            {
                EventCenter.GetInstance().EventTrigger("��Ͻ���",false);
                return;
            }
            EventCenter.GetInstance().EventTrigger("��Ͻ���", true);
        }
    }

}
