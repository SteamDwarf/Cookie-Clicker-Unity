using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CookieParticle : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numText;
    [SerializeField] private float speed;
    [SerializeField] private float timer;

    void Start()
    {
        float x = Random.Range(-100, 100);
        float y = Random.Range(-100, 100);

        transform.localPosition = new Vector3(x, y, 0);
    }

    void Update()
    {
        float newY = transform.position.y + Time.deltaTime * speed;

        transform.position = new Vector3(transform.position.x, newY, 0);
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetNum(float num)
    {
        numText.text = $"+{num}";
    }
}
