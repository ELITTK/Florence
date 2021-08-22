using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 检查物体组合的顺序以判定关卡是否完成
/// </summary>
public class ItemOrderCheck : MonoBehaviour
{
    public List<GameObject> neededOrder;
    public List<GameObject> nowOrder;

    void Start()
    {
        EventCenter.GetInstance().AddEventListener<GameObject>("放置物品", PlaceAddItem);
        EventCenter.GetInstance().AddEventListener("放置完成", CheckOrder);
    }

    public void PlaceAddItem(GameObject item)
    {
        if (!nowOrder.Contains(item))
        {
            nowOrder.Add(item);
            EventCenter.GetInstance().EventTrigger("放置计数增加");
        }
    }

    public void CheckOrder()
    {
        Debug.Log("放置完成");
        for (int i = 0; i < neededOrder.Count; i++)
        {
            if (neededOrder[i]!=nowOrder[i])
            {
                EventCenter.GetInstance().EventTrigger("组合结束",false);
                return;
            }
            EventCenter.GetInstance().EventTrigger("组合结束", true);
        }
    }

}
