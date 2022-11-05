using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ParticleManager particleManager;
    [SerializeField] private TextMeshProUGUI cookiesText;
    [SerializeField] private TextMeshProUGUI clickPowerText;
    [SerializeField] private TextMeshProUGUI autoClickPowerText;
    [SerializeField] private GameObject cookieButton;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject randomCookie;
    [SerializeField] private float minTimeSpawnCookie;
    [SerializeField] private float maxTimeSpawnCookie;
    [SerializeField] private List<string> numsPower;

    private float cookies;
    private float clickPower;
    private float autoClickPower;
    private float timer;

    void Start()
    {
        cookies = 0;
        clickPower = 1;
        autoClickPower = 0;
        timer = Random.Range(minTimeSpawnCookie, maxTimeSpawnCookie);

        autoClickPowerText.text = $"{autoClickPower} <sprite=0>";
    }

    void Update()
    {
        cookies += autoClickPower * Time.deltaTime;
        cookiesText.text = $"Печенья: {GetFormatedNum(cookies)} <sprite=0>";
        ManageRandomCookie();
    }

    public void Click()
    {
        cookies += clickPower;
        particleManager.CreateTextParticle($"+{GetFormatedNum(clickPower)}", cookieButton.transform, true);
    }


    public void UpgradeClickPower(float upgradeValue)
    {
        clickPower += upgradeValue;
        clickPowerText.text = $"{GetFormatedNum(clickPower)} <sprite=0>";
    }

    public void UpgradeAutoClickPower(float upgradeValue)
    {
        autoClickPower += upgradeValue;
        autoClickPowerText.text = $"{autoClickPower} <sprite=0>";
    }

    public void SetAutoClickPower(float newPower)
    {
        autoClickPower = newPower;
        autoClickPowerText.text = $"{autoClickPower} <sprite=0>";
    }

    public float GetAutoClickPower()
    {
        return autoClickPower;
    }


    public void TakeMyMoney(float price)
    {
        cookies -= price;
    }

    public void AddCookies(float cookies)
    {
        this.cookies += cookies;
    }

    public float GetCurrentCookies()
    {
        return cookies;
    }

    public void Exit()
    {
        Application.Quit();
    }


    private void ManageRandomCookie()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);

        if (timer <= 0)
        {
            timer = Random.Range(minTimeSpawnCookie, maxTimeSpawnCookie);

            GameObject instantiatedCookie = GameObject.Instantiate(randomCookie, canvas.transform);
            timer = Random.Range(minTimeSpawnCookie, maxTimeSpawnCookie);
        }
    }

    private string GetFormatedNum(float num)
    {
        float formatedCookiesValue = num;
        int numPowerIndex = 0;
        string numPower = numsPower[numPowerIndex];

        while(formatedCookiesValue >= 1000)
        {
            formatedCookiesValue /= 1000;
            ++numPowerIndex;
            numPower = numsPower[numPowerIndex];
        }

        if(numPower != "")
        {
            return $"{(int)formatedCookiesValue:0.00}{numPower}";
        }

        return $"{(int)formatedCookiesValue}";
    }
}
