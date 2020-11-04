using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class WalletIndecator : MonoBehaviour
{
    [SerializeField] Text Indicator;
    [SerializeField] GameObject effectPrefub;
    [SerializeField] Wallet wallet;
    [SerializeField] float time;
    Coroutine coroutine;
    // Use this for initialization
    void Start()
    {
        wallet.OnChange.AddListener(UpdateIndicator);
        UpdateIndicator(0);
    }

    private void UpdateIndicator(int value)
    {
        if (value == 0) return;
        var effect = Instantiate(effectPrefub, transform.position, Quaternion.identity, transform).GetComponentInChildren<Text>();
        effect.text = value.ToString();
        Destroy(effect.transform.parent.gameObject, 2);
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        int from = wallet.Value;
        int to = wallet.Value + value;
        coroutine = StartCoroutine(Effect(from, to));
    }

    IEnumerator Effect(int from, int to)
    {
        if (from < to)
        {
            for (int i = from; i < to; i++)
            {
                Indicator.text = i.ToString();
                yield return new WaitForSeconds(time / (from - to));
            }
        }
        else
        {
            for (int i = from; i > to; i--)
            {
                Indicator.text = i.ToString();
                yield return new WaitForSeconds(time / (from - to));
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}