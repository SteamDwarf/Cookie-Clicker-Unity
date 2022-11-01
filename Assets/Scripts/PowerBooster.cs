using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerBooster : MonoBehaviour
{
    [SerializeField] private BoosterTypes boosterType;
    [SerializeField] private PowerChanging powerChanging;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI powerText;
    [SerializeField] private Shop shop;
    [SerializeField] private float powerMultiplier;
    [SerializeField] private float startPrice;
    [SerializeField] private float priceMultiplier;

    private float price;

    void Start()
    {
        SetInfo();
    }

    public void BuyUpgrade()
    {
        bool isSuccess = shop.BuyPowerBooster(boosterType, price, powerMultiplier);

        if (isSuccess)
        {
            price *= priceMultiplier;
            priceText.text = $"{price} <sprite=0>";
        }
    }

    public BoosterTypes GetBoosterType()
    {
        return boosterType;
    }

    public string GetBoosterName()
    {
        return BoosterTypes.GetName(boosterType.GetType(), boosterType);
    }

    private void SetInfo()
    {
        price = startPrice;

        priceText.text = $"{price} <sprite=0>";

        if(powerChanging == PowerChanging.Addition)
        {
            powerText.text = $"+{powerMultiplier}";
        }
        else
        {
            powerText.text = $"x{powerMultiplier}";
        }
    }

}
