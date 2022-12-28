using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectFruit : MonoBehaviour
{
    public GameObject gm;
    public ParticleSystem deathAnimation;

    public void Awake()
    {
        gm = GameObject.FindWithTag("GameController");
    }

    public void OnTriggerEnter(Collider other)
    { 
        gm.GetComponent<AudioSource>().Play();
        GameManager.score += 1;
        Instantiate(deathAnimation, transform.localPosition, Quaternion.identity);
        Destroy(gameObject);
    }
}
