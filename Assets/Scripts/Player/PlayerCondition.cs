using UnityEngine;

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public Condition Health;
    public Condition Mana;
    private Transform InGameUI;

    private void Awake()
    {
        InGameUI = GameObject.Find("InGameUI").GetComponent<Transform>();
        Health = InGameUI.Find("ConditionUI(Clone)/HP").GetComponent<Condition>();
        Mana = InGameUI.Find("ConditionUI(Clone)/MP").GetComponent<Condition>();
    }

    private void Update()
    {
        Mana.AddValue(Mana.GetPassiveValue() * Time.deltaTime);
    }

    public void TakeDamge(float damage)
    {
        Health.SubValue(damage);
    }
}