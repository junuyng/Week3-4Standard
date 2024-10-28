using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager instance;
    public static  CharacterManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CharacterManager>();
                if (instance == null)
                {
                    CharacterManager obj = new GameObject("CharacterManager").AddComponent<CharacterManager>();
                    instance = obj;
                }
                
            }
            return instance;
        }
    }

   public Player player;
   
    
    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

        
        else
        {
            Destroy(gameObject);
        }
    }
    
    
}

