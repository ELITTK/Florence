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

        EventCenter.GetInstance().AddEventListener("���ü�������", AddCount);
        EventCenter.GetInstance().AddEventListener<bool>("��Ͻ���", GetPlaceResult);
        EventCenter.GetInstance().AddEventListener("���ü�����", ResetCount);
    }

    private void FreshText()
    {
        text.text = counts.ToString() + "/" + maxCounts.ToString();
        if (counts >= maxCounts)
        {
            EventCenter.GetInstance().EventTrigger("�������");
        }
    }


    private void GetPlaceResult(bool b)
    {
        if (b)
        {
            text.text = "��ϳɹ�,�����л�����һ����Ʒ";//ʤ����
            EventCenter.GetInstance().EventTrigger("��ϳɹ�");
        }
        else
        {
            text.text = "���ʧ��";//ʧ����
            EventCenter.GetInstance().EventTrigger("���ʧ��");
        }
    }

    private void AddCount()
    {
        counts++;
        FreshText();

    }
    private void ResetCount()//���ü�����
    {
        counts = 0;
        maxCounts = levelManager.GetActiveItemOrderCheck().neededOrder.Count;
        FreshText();
    }
}
