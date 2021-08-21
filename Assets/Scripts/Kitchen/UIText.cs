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
        EventCenter.GetInstance().AddEventListener("���ü�������", AddCount);
        EventCenter.GetInstance().AddEventListener<bool>("��Ͻ���", GetPlaceResult);
        FreshText();
    }

    public void FreshText()
    {
        text.text = counts.ToString() + "/" + maxCounts.ToString();
        if (counts >= maxCounts)
        {
            EventCenter.GetInstance().EventTrigger("�������");
        }
    }

    public void AddCount()
    { 
        counts++;
        FreshText();
    }

    public void GetPlaceResult(bool b)
    {
        Debug.Log("�������");
        if (b)
        {
            text.text = "��ϳɹ�";
        }
        else
        {
            text.text = "���ʧ��";
        }
    }
}
