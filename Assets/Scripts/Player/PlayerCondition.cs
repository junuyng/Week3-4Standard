
    using System.Collections;
    using UnityEngine;

    public class PlayerCondition : MonoBehaviour, IDamagable
    {
        public Condition Health;
        public Condition Mana;
        
        private void Update()
        {
            Mana.AddValue(Mana.GetPassiveValue()* Time.deltaTime);
        }

        public void TakeDamge(float damage)
        {
             Health.SubValue(damage);
        }
        
     

         
    }
