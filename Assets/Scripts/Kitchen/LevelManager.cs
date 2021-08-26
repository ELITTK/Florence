using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Animator UIWhiteTurn;//����ת������

    public List<GameObject> levelItems;//�ؿ���������Ҫ��ϵ���Ʒ��

    public int currentInt = 0;//��ʼ��Ʒ���±�
    private int maxInt;//����±�
    private GameObject activeItems;//��ǰ���õ���Ʒ��
    private ItemOrderCheck activeItemOrderCheck;

    private void Start()
    {
        SetActiveItems();
        maxInt = levelItems.Count;
        EventCenter.GetInstance().AddEventListener("��ϳɹ�", ItemsFinish);
        EventCenter.GetInstance().AddEventListener("���ʧ��", ResetItems);
    }


    /// <summary>
    /// ���ص���������Ʒ��Ĳ���Script
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
    /// ��ϳɹ����л�����һ����Ʒ��
    /// </summary>
    public void ItemsFinish()
    {
        if (currentInt>=maxInt-1)
        {
            Debug.Log("ȫ��ͨ��"+currentInt+">="+(maxInt-1));
        }
        else
        {
            Invoke("PlayWhiteTurnAnim", 2.5f);
            Invoke("TurnToNextItems", 3);
        }
    }

    /// <summary>
    /// ���ʧ�ܣ����õ�ǰ��Ʒ��
    /// </summary>
    public void ResetItems()
    {
        //��ûд
    }

    private void TurnToNextItems()
    {
        activeItems.SetActive(false);

        currentInt++;
        SetActiveItems();
        activeItems.SetActive(true);
        activeItemOrderCheck = activeItems.GetComponent<ItemOrderCheck>();

        EventCenter.GetInstance().EventTrigger("���ü�����");
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
