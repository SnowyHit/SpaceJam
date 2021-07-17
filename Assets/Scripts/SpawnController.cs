using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
  public GameObject enemyPefab;
  private Vector3 point;
  private float radius=50f;

  private void Start(){
    point=GameObject.Find("Player").transform.position;
    CreateEnemiesAroundPoint(100,point,radius);

  }
  private void Update(){

  }

  public void CreateEnemiesAroundPoint (int num, Vector3 point, float radius){

    for (int i = 0; i < num; i++){

        /* Distance around the circle */
        var radians = 2 * Mathf.PI / num * i;

        /* Get the vector direction */
        var vertical = Mathf.Sin(radians);
        var horizontal = Mathf.Cos(radians);

        var spawnDir = new Vector3 (horizontal, vertical,0);

        /* Get the spawn position */
        var spawnPos = point + spawnDir * radius; // Radius is just the distance away from the point

        /* Now spawn */
        var enemy = Instantiate (enemyPefab, spawnPos, Quaternion.identity) as GameObject;

        /* Rotate the enemy to face towards player */
        enemy.transform.LookAt(point);

        /* Adjust height */
        enemy.transform.Translate (new Vector3 (0, enemy.transform.localScale.y / 2, 0));
    }
  }
}
