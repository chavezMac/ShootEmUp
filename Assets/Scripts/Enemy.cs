using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public int points = 0;
  public int totalEnemies = 0;
  public delegate void EnemyDied(int pointWorth);
  public static event EnemyDied OnEnemyDied;
  
    // Start is called before the first frame update
  void OnCollisionEnter2D(Collision2D collision)
  {
    Debug.Log("Ouch!");
    Destroy(collision.gameObject);
    

    if(collision.gameObject.tag == "Bullet") {
      OnEnemyDied.Invoke(points);
      Destroy(gameObject);
    }
  }

}
