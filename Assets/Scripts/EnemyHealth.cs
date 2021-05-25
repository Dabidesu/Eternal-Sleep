using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float eHealth;
    public float eMaxHealth;

    public GameObject eHealthBarUI;
    //public Slider slider;

    void Start()
    {
        eHealth = eMaxHealth;
        //slider.value = CalculateHealth();
    }

    void Update()
    {
        //slider.value = CalculateHealth();

        if (eHealth < eMaxHealth)
        {
            eHealthBarUI.SetActive(true);
        }
        
        //If HP reaches zero
        if(eHealth <= 0)
        {
            //add animation
            //add delay
            Destroy(gameObject);
        }

        //Restores more than the Max HP
        if(eHealth > eMaxHealth)
        {
            eHealth = eMaxHealth;
        }
    }

    float CalculateHealth()
    {
        return eMaxHealth / eMaxHealth;
    }
}
