using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Condition : MonoBehaviour
{
    [SerializeField] private float maxValue;

    [SerializeField] private float startValue;
    [SerializeField] public float passiveValue;
    [SerializeField] private Image uiBar;

    private float curValue;

    private void Start()
    {
        curValue = startValue;
    }

    private void Update()
    {
        uiBar.fillAmount = curValue / maxValue;
    }

    public float GetPassiveValue()
    {
        return passiveValue;
    }

    public void AddValue(float value)
    {
        curValue = Mathf.Min(curValue + value, maxValue);
    }

    public void SubValue(float value)
    {
        curValue = Mathf.Max(curValue - value, 0f);
    }
}