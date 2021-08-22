using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShift : MonoBehaviour
{
	private float alpha = 0.0f;
	public float alphaSpeed = 2.0f;

	private CanvasGroup cg;

	void Start()
	{
		cg = this.transform.GetComponent<CanvasGroup>();
	}

	void Update()
	{
		if (alpha != cg.alpha)
		{
			cg.alpha = Mathf.Lerp(cg.alpha, alpha, alphaSpeed * Time.deltaTime);
			if (Mathf.Abs(alpha - cg.alpha) <= 0.01)
			{
				cg.alpha = alpha;
			}
		}
	}

	public void Show()
	{
		alpha = 1;

		cg.blocksRaycasts = true;//���Ժ͸�UI���󽻻�
	}

	public void Hide()
	{
		alpha = 0;

		cg.blocksRaycasts = false;//�����Ժ͸�UI���󽻻�
	}
}
