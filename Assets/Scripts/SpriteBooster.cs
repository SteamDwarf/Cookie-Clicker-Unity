using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpriteBooster : MonoBehaviour
{
    [SerializeField] private BoosterTypes boosterType;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Sprite sprite;
    [SerializeField] private float price;
    [SerializeField] private Shop shop;
    [SerializeField] private float power;


    private void Start()
    {
        priceText.text = $"{price} <sprite=0>";
    }

    public void BuyUpgrade()
    {
        bool isSuccess = shop.BuySpriteBooster(boosterType, price, sprite, power);

        if(isSuccess)
        {
            gameObject.SetActive(false);
        }
    }
}
