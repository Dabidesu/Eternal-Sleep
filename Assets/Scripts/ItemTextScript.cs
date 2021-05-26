using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTextScript : MonoBehaviour
{
    [SerializeField] public static int coinAmount;
    private Text ItemsCollectedText;

    void Start ()
    {
        ItemsCollectedText = GetComponent<Text>();
        coinAmount = 0;
    }

    void Update()
    {
        ItemsCollectedText.text = "Coins: " + coinAmount;
    }
}
