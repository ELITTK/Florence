using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    public int counts = 0;
    public int maxCounts = 3;

    public ItemOrderCheck itemOrderCheck;

    private Text text;

    void Start()
    {
        maxCounts = itemOrderCheck.neededOrder.Count;

        text = GetComponent<Text>();
        EventCenter.GetInstance().AddEventListener("放置计数增加", AddCount);
        EventCenter.GetInstance().AddEventListener<bool>("组合结束", GetPlaceResult);
        FreshText();
    }

    public void FreshText()
    {
        text.text = counts.ToString() + "/" + maxCounts.ToString();
        if (counts >= maxCounts)
        {
            EventCenter.GetInstance().EventTrigger("放置完成");
        }
    }

    public void AddCount()
    { 
        counts++;
        FreshText();
    }

    public void GetPlaceResult(bool b)
    {
        Debug.Log("放置完成");
        if (b)
        {
            text.text = "组合成功";
        }
        else
        {
            text.text = "组合失败";
        }
    }
}
