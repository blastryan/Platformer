using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float enemyAttackSpeed;
    [SerializeField] float xBoundry;
    [SerializeField] float yBoundry;
    LevelManager levelManager;
    private void Awake()
    {
      levelManager=GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    private void Update()
    {
        EnemyDestroyer();
    }
    private void FixedUpdate()
    {
        EnemyAttack();
    }
    void EnemyAttack()
    {
        transform.Translate(-1 + enemyAttackSpeed * Time.deltaTime, 0, 0);
    }   
    void EnemyDestroyer()
    {
     if (transform.position.x < xBoundry || transform.position.y < yBoundry )
    {
        Destroy(gameObject);
    }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            Destroy(collision.gameObject);
            levelManager.RespawnPlayer();
        }
    }
}
