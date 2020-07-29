using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    private Rigidbody2D rb2d;
    private float direction = 1;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb2d.velocity = new Vector2(direction * moveSpeed, 0);  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction *= -1;
    }
}
