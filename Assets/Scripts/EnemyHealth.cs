using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float eHealth;
    public float eMaxHealth;

    public GameObject eHealthBarUI;
    public Slider enemySlider;

    void Start()
    {
        eHealth = eMaxHealth;
        
    }

    void Update()
    {

        enemySlider.value = eHealth;
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

    public void eTakeDamage(float damage)
    {
        eHealth -= damage;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            eTakeDamage(5f);
        }
    }
}
