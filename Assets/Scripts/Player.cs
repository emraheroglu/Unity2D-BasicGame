using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 8f;
    public Text healthText;
    public GameObject bombObject;
    private Rigidbody2D rb2d;
    private float health;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        health = 100;
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            rb2d.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBomb();
        }

        healthText.text = health.ToString();
    }

    private void FireBomb()
    {
        GameObject currentBomb = Instantiate(bombObject, transform.position + Vector3.up, Quaternion.identity);
        currentBomb.GetComponent<Rigidbody2D>().velocity = Vector2.up * moveSpeed * 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Bomb"))
        {
            Destroy(collision.gameObject);
            health -= 10;
            if (health <= 0)
            {
                health = 100;
            }
        }
    }
}
