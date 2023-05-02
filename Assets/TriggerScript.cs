using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    [SerializeField] GameObject enemyPreFab;
    [SerializeField] Transform spawnPos;
    [SerializeField] float enemySpeed;
    bool moveEnemy = false;


    private void FixedUpdate()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        if (moveEnemy)
        {
            SpawnEnemy();
            moveEnemy = false;
            //enemyPreFab.GetComponent<Rigidbody2D>().velocity = new Vector2(-1* enemySpeed, 0);
        }
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPreFab, spawnPos.position, enemyPreFab.transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moveEnemy = true;
        }
    }


}
