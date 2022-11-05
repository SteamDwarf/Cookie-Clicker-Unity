using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private GameObject cookieParticle;
    [SerializeField] private GameObject rainedCookie;
    [SerializeField] private GameObject canvas;

    public void CreateTextParticle(string text, Transform parent, bool isRandom)
    {
        //GameObject particleGO = GameObject.Instantiate(cookieParticle, parent);
        GameObject particleGO = GameObject.Instantiate(cookieParticle);

        if(isRandom)
        {
            float x = Random.Range(-100, 100);
            float y = Random.Range(-100, 100);

            particleGO.transform.parent = parent;
            particleGO.transform.localPosition = new Vector3(x, y, parent.position.z);
        }
        else
        {
            particleGO.transform.parent = canvas.transform;
            particleGO.transform.position = new Vector3(parent.position.x, parent.position.y, parent.position.z);
        }

        particleGO.GetComponent<CookieParticle>().SetText(text);
    }
}
