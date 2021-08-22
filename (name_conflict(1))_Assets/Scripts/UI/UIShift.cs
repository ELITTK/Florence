using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIShift : MonoBehaviour
{
	private float alpha = 0.0f;
	public float alphaSpeed = 2.0f;
	public float waitTime;

	public TextMeshProUGUI text;

	private CanvasGroup cg;
	private bool canShift;
	private int counter;
	private float timer;
	private string square;
	void Start()
	{
		square = "■";
		canShift = true;
		counter = 0;
		timer = 0;
		cg = this.transform.GetComponent<CanvasGroup>();
		//text = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
	}

	void FixedUpdate()
	{
		if (alpha != cg.alpha)
		{
			cg.alpha = Mathf.Lerp(cg.alpha, alpha, alphaSpeed * Time.deltaTime);
			if (Mathf.Abs(alpha - cg.alpha) <= 0.01)
			{
				cg.alpha = alpha;
				timer = 10f / counter;
				StartCoroutine(IEnName());
				//Hide();
			}
			canShift = false;
		}
		if (timer > 0)
        {
			timer -= Time.deltaTime;
			if (timer <= 0)
            {
				canShift = true;
            }
        }
	}

	public void Show()
	{
		alpha = 1;
		counter++;
		text.text = string.Empty;
		//cg.blocksRaycasts = true;//可以和该UI对象交互
	}

	public void Hide()
	{
		alpha = 0;

		//cg.blocksRaycasts = false;//不可以和该UI对象交互
	}

	public bool Shiftable()
    {
		return canShift;
    }

	IEnumerator IEnName()
	{
		for (int i = 0; i < 5; i++)
        {
			if (Random.Range(0,5) == 1)
            {
				text.text += " ";
            }
			else
            {
				text.text += square;
            }
			yield return new WaitForSeconds(waitTime);
		}
		Hide();
		StopCoroutine("IEnName");
	}
}
