
    using System.Collections;
    using UnityEngine;

    public class PlayerCondition : MonoBehaviour
    {
        [SerializeField]private Condition Health;
        [SerializeField] private Condition Mana;
        
        private void Update()
        {
            Mana.AddValue(Mana.GetPassiveValue()* Time.deltaTime);
        }    
        
    }
