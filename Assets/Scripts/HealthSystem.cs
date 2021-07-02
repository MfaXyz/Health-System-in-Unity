using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [Header("Variables")] 
    public int countOfHealth;
    [SerializeField] private int health;

    [Header("Components")] 
    public Image imageBar;

    private void Awake()
    {
        health = countOfHealth;
        BarChanger();
    }

    private void BarChanger()
    {
        imageBar.fillAmount = health /(float) countOfHealth;
    }

    public void DamageHealth(int damageCount)
    {
        health -= damageCount;
        BarChanger();
        if (health <= 0)
        {
            health = 0;
            //Debug.Log("!Min Health:" + health);
        }
    }

    public void HealHealth(int healCount)
    {
        health += healCount;
        BarChanger();
        if (health > countOfHealth)
        {
            health = countOfHealth;
            //Debug.Log("!Max Health:" + health);
        }
    }
    
    //hps: 1 Health Per Second
    public IEnumerator RegenerationHealth(float hps)
    {
        while (true)
        {
            health++;
            BarChanger();
            if (health > countOfHealth)
            {
                health = countOfHealth;
                //Debug.Log("!Max Health:" + health);
                yield break;
            }
            yield return new WaitForSeconds(hps);
        }
    }
}
