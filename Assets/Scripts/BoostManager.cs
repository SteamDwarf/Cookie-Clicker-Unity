using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class BoostManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Shop shop;
    [SerializeField] private List<CountBoostData> countBoosters;


    public void UpdatePowerBooster(BoosterTypes boosterType, float powerMultiplier)
    {

        if (boosterType == BoosterTypes.Click)
        {
            gameManager.UpgradeClickPower(powerMultiplier);
        }
        else
        {
            float curAutoClickPower = gameManager.autoClickPower;
            CountBoostData countBoosterData = countBoosters.Find(boosterData => boosterData.name == BoosterTypes.GetName(boosterType.GetType(), boosterType));
            float boosterPower = countBoosterData.count * countBoosterData.power;
            float otherBoostersPower = curAutoClickPower - boosterPower;
            float newPower = countBoosterData.power * powerMultiplier;

            countBoosterData.power = newPower;

            gameManager.SetAutoClickPower(otherBoostersPower + countBoosterData.power * countBoosterData.count);
            shop.UpdateCountBoosterPower(boosterType, newPower);
        }
    }

    public void UpdateCountBooster(BoosterTypes boosterType, float power, float count)
    {
        string boosterName = BoosterTypes.GetName(boosterType.GetType(), boosterType);
        CountBoostData boosterData = countBoosters.Find(booster => booster.name == boosterName);

        if (boosterData == null)
        {
            boosterData = new CountBoostData(boosterName, 1, power);
            countBoosters.Add(boosterData);
        }
        else
        {
            boosterData.count = count + 1;
        }

        gameManager.UpgradeAutoClickPower(power);
    }
}
