using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : MonoBehaviour
{
    [SerializeField] private float healAmount;
 

    [ContextMenu("마나포션사용")]
    private void HealMana()
    {
        CharacterManager.Instance.player.Condition.Mana.AddValue(healAmount);
        Destroy(gameObject);
    }
}
