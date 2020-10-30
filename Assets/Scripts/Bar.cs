using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using DG.Tweening;
public class Bar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Text countText;

    public void SetValue(int value, float v)
    {
        slider?.DOValue(v, .3f);
        StartCoroutine(Increase(value, .2f));
    }

    IEnumerator Increase(double value, double time)
    {
            Debug.Log(time / value);
        float interval =(float)(time / value);
        for (int i = 0; i < value; i++)
        {
            countText.text = i.ToString();
            Debug.Log(i);
            yield return new WaitForSeconds(interval);
        }
    }
}