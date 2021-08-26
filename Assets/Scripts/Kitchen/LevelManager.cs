using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Animator UIWhiteTurn;//白屏转场动画

    public List<GameObject> levelItems;//关卡内所有需要组合的物品组

    public int currentInt = 0;//初始物品组下标
    private int maxInt;//最大下标
    private GameObject activeItems;//当前启用的物品组
    private ItemOrderCheck activeItemOrderCheck;

    private void Start()
    {
        SetActiveItems();
        maxInt = levelItems.Count;
        EventCenter.GetInstance().AddEventListener("组合成功", ItemsFinish);
        EventCenter.GetInstance().AddEventListener("组合失败", ResetItems);
    }


    /// <summary>
    /// 返回当且启用物品组的查序Script
    /// </summary>
    /// <returns></returns>
    public ItemOrderCheck GetActiveItemOrderCheck()
    {
        if (!activeItemOrderCheck)
        {
            activeItemOrderCheck = activeItems.GetComponent<ItemOrderCheck>();
        }
        return activeItemOrderCheck;
    }

    /// <summary>
    /// 组合成功，切换到下一个物品组
    /// </summary>
    public void ItemsFinish()
    {
        if (currentInt>=maxInt-1)
        {
            Debug.Log("全部通关"+currentInt+">="+(maxInt-1));
        }
        else
        {
            Invoke("PlayWhiteTurnAnim", 2.5f);
            Invoke("TurnToNextItems", 3);
        }
    }

    /// <summary>
    /// 组合失败，重置当前物品组
    /// </summary>
    public void ResetItems()
    {
        //还没写
    }

    private void TurnToNextItems()
    {
        activeItems.SetActive(false);

        currentInt++;
        SetActiveItems();
        activeItems.SetActive(true);
        activeItemOrderCheck = activeItems.GetComponent<ItemOrderCheck>();

        EventCenter.GetInstance().EventTrigger("重置计数器");
    }

    private void SetActiveItems()
    {
        activeItems = levelItems[currentInt];
    }

    private void PlayWhiteTurnAnim()
    {
        UIWhiteTurn.Play("Kitchen_WhiteTurn");
    }
}
