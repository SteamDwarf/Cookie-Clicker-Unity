using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCookie : MonoBehaviour
{
    [SerializeField] private float timer;

    private GameObject boostManagerGO;
    private BoostManager boostManager;


    void Start()
    {

        float x = Random.Range(-700, 700);
        float y = Random.Range(-300, 300);

        transform.localPosition = new Vector3(x, y, 0);

        boostManagerGO = GameObject.FindGameObjectWithTag("BoostManager");

        if(boostManagerGO)
        {
            boostManager = boostManagerGO.GetComponent<BoostManager>();
        }
    }

    void Update()
    {

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Click()
    {
        boostManager.SetRandomBonus(transform);
        Destroy(gameObject);
        //gameObject.GetComponent<Button>().interactable = false;
        //gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }
}
