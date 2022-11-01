using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountBooster : MonoBehaviour
{
    [SerializeField] private BoosterTypes boosterType;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI boostText;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private Shop shop;
    [SerializeField] private float power;
    [SerializeField] private float startPrice;
    [SerializeField] private float priceMultiplier;

    private float count;
    private float price;

    void Start()
    {

        SetInfo();
    }

    public void BuyUpgrade()
    {
        bool isSuccess = shop.BuyCountBooster(boosterType, price, power, count);

        if (isSuccess)
        {
            price *= priceMultiplier;
            count++;

            priceText.text = $"{price} <sprite=0>";
            boostText.text = $"{power} <sprite=0>/c";
            countText.text = $"{count}";
        }
    }

    public BoosterTypes GetBoosterType()
    {
        return boosterType;
    }

    public void SetPower(float newPower)
    {
        power = newPower;
        boostText.text = $"{power} <sprite=0>/c";
    }

    public string GetBoosterName()
    {
        return BoosterTypes.GetName(boosterType.GetType(), boosterType);
    }

    private void SetInfo()
    {
        price = startPrice;
        count = 0;

        priceText.text = $"{price} <sprite=0>";
        boostText.text = $"{power} <sprite=0>/c";
        countText.text = $"{count}";
    }
}
