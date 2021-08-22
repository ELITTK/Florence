using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Ʒ���������
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
