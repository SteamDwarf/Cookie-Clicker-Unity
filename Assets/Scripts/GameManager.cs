using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cookiesText;
    [SerializeField] private TextMeshProUGUI clickPowerText;
    [SerializeField] private TextMeshProUGUI autoClickPowerText;
    [SerializeField] private GameObject cookieParticle;
    [SerializeField] private GameObject cookieButton;

    private float cookies;
    private float clickPower;
    public float autoClickPower;


    void Start()
    {
        cookies = 0;
        clickPower = 1;
        autoClickPower = 0;
        autoClickPowerText.text = $"{autoClickPower} <sprite=0>";
    }

    void Update()
    {
        cookies += autoClickPower * Time.deltaTime;
        cookiesText.text = $"Печенья: {(int)cookies} <sprite=0>";
    }

    public void Click()
    {
        GameObject cookieParticleGO = GameObject.Instantiate(cookieParticle, cookieButton.transform);
        cookieParticleGO.GetComponent<CookieParticle>().SetNum(clickPower);

        cookies += clickPower;
    }


    public void UpgradeClickPower(float upgradeValue)
    {
        clickPower += upgradeValue;
        clickPowerText.text = $"{clickPower} <sprite=0>";
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


    public void TakeMyMoney(float price)
    {
        cookies -= price;
    }

    public float GetCurrentCookies()
    {
        return cookies;
    }

    public void Exit()
    {
        Application.Quit();
    }

}
