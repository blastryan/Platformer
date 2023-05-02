using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float jumpPower;
    [SerializeField] private float radius;
    [SerializeField] Transform feetPos;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float gravityScale;
    [SerializeField] float fallGravityScale;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);//Add.Force Kuvvet uygulama-Impulse anýnda gücü gösterme - Force güç toplayýp gücü göstemerme
        }
        Gravity();
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(feetPos.position, radius, layerMask);
    }
    void Gravity()
    {
        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallGravityScale;
        }
    }
    
}
