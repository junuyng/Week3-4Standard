using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameArea : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float delayTime;

    private List<IDamagable> objects = new List<IDamagable>();

    private void OnEnable()
    {
        StartCoroutine(DealDamage());
    }


    private IEnumerator DealDamage()
    {
        while (gameObject.activeSelf)
        {
            foreach (var obj in objects)
            {
                obj.TakeDamge(damage);
            }
            
            yield return new WaitForSeconds(delayTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamagable damagable))
        {
            objects.Add(damagable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IDamagable damagable))
        {
            objects.Remove(damagable);
        }
    }
}