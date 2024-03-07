using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;

  public float speed = 5f;

  public Transform shottingOffset;
    // Update is called once per frame

    void Start()
    {
      Enemy.OnEnemyDied += EnemyOnEnemyDied;
      EnemySpawner.OnGameEnded += OnGameEnded;
    }

    void OnDestroy()
    {
      Enemy.OnEnemyDied -= EnemyOnEnemyDied;
    }
    void EnemyOnEnemyDied(int pointsWorth)
    {
      Debug.Log($"I got one! It was worth ${pointsWorth}!");
    }

    void OnGameEnded()
    {
      Debug.Log("Game Over!");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      Debug.Log("They Got me!");
      Destroy(collision.gameObject);
      
      if(collision.gameObject.tag == "EnemyBullet") 
      {
        OnGameEnded();
        Destroy(gameObject);
      }
      
    }
    void Update()
    {
      float direction = Input.GetAxis("Horizontal");
      Vector3 newPosition = transform.position + new Vector3(direction, 0, 0) * speed * Time.deltaTime;
      newPosition.x = Mathf.Clamp(newPosition.x, -24, 24);
      transform.position = newPosition;

      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 10f);

      }
    }
}
