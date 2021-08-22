using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 物品的组合区域
/// </summary>
public class PlaceItem : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<DragItem>())
        {
            col.GetComponent<DragItem>().GetInRightPlace();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.GetComponent<DragItem>())
        {
            col.GetComponent<DragItem>().GetOutRightPlace();
        }
    }
}
