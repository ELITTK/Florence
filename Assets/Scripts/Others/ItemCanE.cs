using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 可互动物品,需要物品有trigger
/// </summary>
public class ItemCanE : MonoBehaviour
{
    public GameObject playerInArea;//范围内可互动该物品的玩家

    // Update is called once per frame
    void Update()
    {
        if (playerInArea!=null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("玩家互动物品");
            }
        }
    }


    /// <summary>
    /// 玩家进入可互动区域时
    /// </summary>
    /// <param name="collision"></param>
    protected void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponentInParent<LightBallMove>())
        {
            playerInArea = collision.gameObject;
            Debug.Log("玩家进入互动范围");
        }
    }

    /// <summary>
    /// 玩家离开可互动区域时
    /// </summary>
    /// <param name="collision"></param>
    protected void OnTriggerExit(Collider collision)
    {
        if (collision.GetComponentInParent<LightBallMove>())
        {
            playerInArea = null;
            Debug.Log("玩家离开互动范围");
        }
    }
}
