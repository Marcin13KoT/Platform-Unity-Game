using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    private GameObject player;
    GameObject shield;
    private GameObject powerup;
    private Vector2 playerDirection;
    public AudioSource powerUpSFX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        shield = transform.Find("Shield").gameObject;
        powerup = GameObject.FindGameObjectWithTag("PowerUp");
        powerUpSFX = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(0, directionY).normalized;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, playerDirection.y * playerSpeed);
    }

    void ActivateShield()
    {
        shield.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PowerUp powerup = collision.GetComponent<PowerUp>();
        if (powerup)
        {
            if (powerup.activateShield)
            {
                ActivateShield();
                powerUpSFX.PlayOneShot(powerUpSFX.clip, 0.8f);
                Destroy(powerup.gameObject);
            }
        }
    }
}
