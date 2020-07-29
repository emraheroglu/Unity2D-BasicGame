using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer : MonoBehaviour
{
    public Text healthText;
    public GameObject bombObject;
    private float health;
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBomb();
        }

        healthText.text = health.ToString();
    }

    private void FireBomb()
    {
        GameObject currentBomb = Instantiate(bombObject, transform.position + Vector3.down, Quaternion.identity);
        currentBomb.GetComponent<Rigidbody2D>().velocity = Vector2.down * 20f;
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
