using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    private float ltimer;

    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public float fillFront;
    public float fillBack;
    public float healthFraction;
    public float percentComplete;

    public Image frontHPbar;
    public Image backHPbar;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        //Debug.Log(health);
        if (Input.GetKeyDown(KeyCode.X))
        {
            TakeDamage(Random.Range(5, 10));
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            RestoreHealth(Random.Range(5, 10));
        }


    }
    
    public void UpdateHealthUI()
    {
        //Debug.Log(health);
        fillFront = frontHPbar.fillAmount;
        fillBack = backHPbar.fillAmount;
        healthFraction = health / maxHealth;

        if(fillBack > healthFraction)
        {
            frontHPbar.fillAmount = healthFraction;
            backHPbar.color = Color.red;
            ltimer += Time.deltaTime;
            percentComplete = ltimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHPbar.fillAmount = Mathf.Lerp(fillBack, healthFraction, percentComplete);
        }

        if (fillFront < healthFraction)
        {
            backHPbar.fillAmount = healthFraction;
            backHPbar.color = Color.green;
            ltimer += Time.deltaTime;
            percentComplete = ltimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHPbar.fillAmount = Mathf.Lerp(fillFront, backHPbar.fillAmount, percentComplete);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        ltimer = 0f;
    }

    public void RestoreHealth(float restore)
    {
        health += restore;
        ltimer = 0f;
    }
}
