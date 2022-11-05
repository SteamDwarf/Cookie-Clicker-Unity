using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class BoostManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ParticleManager particleManager;
    [SerializeField] private Shop shop;
    [SerializeField] private List<CountBoostData> countBoosters;
    [SerializeField] private Image cookie;
    [SerializeField] private Image backgroundSprite;

    public void UpdatePowerBooster(BoosterTypes boosterType, float powerMultiplier)
    {

        if (boosterType == BoosterTypes.Click)
        {
            gameManager.UpgradeClickPower(powerMultiplier);
        }
        else
        {
            float curAutoClickPower = gameManager.GetAutoClickPower();
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

    public void UpdateSprite(BoosterTypes boosterType, Sprite sprite, float power)
    {
        if(boosterType == BoosterTypes.CookieSprite)
        {
            cookie.sprite = sprite;
            gameManager.UpgradeClickPower(power);
        }
        else if(boosterType == BoosterTypes.BackgroundSprite)
        {
            backgroundSprite.sprite = sprite;
            backgroundSprite.color = new Color(202, 202, 202);
            gameManager.UpgradeAutoClickPower(power);
        }
    }

    public void SetRandomBonus(Transform cookieTransform)
    {
        int randomEvent = Random.Range(1, 3);

        if(randomEvent == 1)
        {
            float randomCookies = Mathf.Floor(Random.Range(50, 300));

            gameManager.AddCookies(randomCookies);
            particleManager.CreateTextParticle($"+{randomCookies}", cookieTransform, false);

        } else if(randomEvent == 2)
        {
            float boostPower = Random.Range(10, 30);
            float boostTime = Random.Range(5, 15);

            particleManager.CreateTextParticle($"+{boostPower}/c", cookieTransform, false);
            StartCoroutine(AutoClickBoost(boostPower, boostTime));
        }

        
    }

    private IEnumerator AutoClickBoost(float power, float time)
    {
        gameManager.UpgradeAutoClickPower(power);
        yield return new WaitForSeconds(time);
        gameManager.UpgradeAutoClickPower(power * -1);
    }
}
