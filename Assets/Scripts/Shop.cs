using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private BoostManager boostManager;
    [SerializeField] private List<GameObject> powerBoosters;
    [SerializeField] private List<GameObject> countBoosters;

    private void Start()
    {
        foreach(GameObject booster in powerBoosters)
        {
            if(booster.GetComponent<PowerBooster>().GetBoosterType() != BoosterTypes.Click)
            {
                booster.SetActive(false);
            }
        }
    }

    public bool BuyPowerBooster(BoosterTypes boosterType, float price, float powerMultiplier)
    {
        if(gameManager.GetCurrentCookies() >= price)
        {
            gameManager.TakeMyMoney(price);
            boostManager.UpdatePowerBooster(boosterType, powerMultiplier);

            return true;
        }

        return false;
    }

    public bool BuyCountBooster(BoosterTypes boosterType, float price, float upgradeValue, float count)
    {
        if (gameManager.GetCurrentCookies() >= price)
        {
            gameManager.TakeMyMoney(price);
            boostManager.UpdateCountBooster(boosterType, upgradeValue, count);

            if (count == 0)
            {
                ShowPowerBooster(boosterType);
            }

            return true;
        }

        return false;
    }

    public void UpdateCountBoosterPower(BoosterTypes boosterType, float newPower)
    {
        foreach (GameObject countBooster in countBoosters)
        {
            CountBooster booster = countBooster.GetComponent<CountBooster>();

            if (booster.GetBoosterType() == boosterType)
            {
                booster.SetPower(newPower);
            }
        }
    }

    private void ShowPowerBooster(BoosterTypes boosterType)
    {
        GameObject powerBoosterGO = powerBoosters.Find(boosterGO => boosterGO.GetComponent<PowerBooster>().GetBoosterType() == boosterType);

        if (powerBoosterGO != null)
        {
            powerBoosterGO.SetActive(true);
        }
    }
}
