using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject player;
    public Transform target;
    public float speed = 5f;
    bool enemyMove = false;

    private void FixedUpdate()
    {
        MoveEnemy();
    }
    void MoveEnemy()
    {
        if (enemyMove)
        {
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * 10, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyMove = true;
        }
    }

}
