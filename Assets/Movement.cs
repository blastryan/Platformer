using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    public SpriteRenderer spriteRenderer;
    [SerializeField] float playerYBoundery;
    LevelManager levelManager;
    
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        levelManager=GameObject.Find("LevelManager").GetComponent<LevelManager>();
        spriteRenderer=GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        MovementAction();
        PlayerDestroyer();
    }
    void MovementAction()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);
        SpriteFlip(horizontalMove);

    }
    void PlayerDestroyer()
    {
        if (transform.position.y < playerYBoundery)
        {
            Destroy(gameObject);
            levelManager.RespawnPlayer();
        }
    }
    void SpriteFlip(float horizontalMove)
    {
        if (horizontalMove > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalMove < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}

