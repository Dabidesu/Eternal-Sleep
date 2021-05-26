using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    [SerializeField] public bool pickUpAllowed;
    [SerializeField] bool truexd;

    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("OnTrig");
        if (collision.gameObject.CompareTag("Player"))
        {
            pickUpAllowed = true;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("OnTrig");
        if (collision.gameObject.CompareTag("Player"))
        {
           pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        Destroy(gameObject);
    }
}
