using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
  Material material;
  Vector2 offset;
  Rigidbody2D rb;
  public Material[] materials;
  float secondsToWait=10f;


  public int xVelocity, yVelocity;

  private void Awake()
  {
    rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    material = GetComponent<Renderer>().material;
  }

  void Start()
  {
    offset = new Vector2(rb.velocity.x , rb.velocity.y);
    StartCoroutine(BgCoroutine());
  }

  void Update()
  {

    offset = new Vector2(rb.velocity.x , rb.velocity.y);
    material.mainTextureOffset += offset*Time.deltaTime;
  }
  IEnumerator BgCoroutine()
  {
    while(true){
      if(rb.velocity.x>1 || rb.velocity.y>1){
        int temp=Random.Range(0,materials.Length);

        GetComponent<Renderer>().material=materials[temp];
        material = GetComponent<Renderer>().material;

      }



      yield return new WaitForSeconds(secondsToWait);
    }


  }

}
