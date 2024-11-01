using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    public Transform IngameUI;
    public GameObject ConditionUI;
    public GameObject PauseUI;
    public GameObject Player;
    private void Start()
    {        
        GameObject conditionUIInstance = Instantiate(ConditionUI, IngameUI);
        Instantiate(Player);
        GameObject PauseUIInstance = Instantiate(PauseUI, IngameUI);
    }
}
