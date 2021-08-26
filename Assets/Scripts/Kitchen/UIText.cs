using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    public int counts = 0;
    public int maxCounts = 3;

    public LevelManager levelManager;

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
        ResetCount();

        EventCenter.GetInstance().AddEventListener("放置计数增加", AddCount);
        EventCenter.GetInstance().AddEventListener<bool>("组合结束", GetPlaceResult);
        EventCenter.GetInstance().AddEventListener("重置计数器", ResetCount);
    }

    private void FreshText()
    {
        text.text = counts.ToString() + "/" + maxCounts.ToString();
        if (counts >= maxCounts)
        {
            EventCenter.GetInstance().EventTrigger("放置完成");
        }
    }


    private void GetPlaceResult(bool b)
    {
        if (b)
        {
            text.text = "组合成功,即将切换至下一组物品";//胜利了
            EventCenter.GetInstance().EventTrigger("组合成功");
        }
        else
        {
            text.text = "组合失败";//失败了
            EventCenter.GetInstance().EventTrigger("组合失败");
        }
    }

    private void AddCount()
    {
        counts++;
        FreshText();

    }
    private void ResetCount()//重置计数器
    {
        counts = 0;
        maxCounts = levelManager.GetActiveItemOrderCheck().neededOrder.Count;
        FreshText();
    }
}
