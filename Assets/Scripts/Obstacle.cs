using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject player;
    private GameObject shield;
    public AudioSource tickSource;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        tickSource = GetComponent<AudioSource> ();
    }

    void Update()
    {
        shield = GameObject.FindGameObjectWithTag("Shield");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }

        if(collision.tag == "Shield")
        {
            tickSource.PlayOneShot(tickSource.clip, 0.8f);
            Destroy(this.gameObject);
            shield.SetActive(false);
        }

        else if(collision.tag == "Player")
        {
            tickSource.PlayOneShot(tickSource.clip, 0.5f);
            Destroy(player.gameObject);
        }
    }

}