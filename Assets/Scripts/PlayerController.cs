using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private ColorController colorController;
    private Rigidbody2D rb;
    private float normalizer=-200f;
    Vector2 direc2;
    private string direction;
    GameObject asteroidPrefab;
    public float forceMod;
    [SerializeField]private float defaultForce=0f;
    [SerializeField]private float maxForce=400f;
    private float force;
    public float Force{get{return force;}set{force=value;}}


    private void Awake()
    {
      force=defaultForce;
      rb = gameObject.GetComponent<Rigidbody2D>();
      colorController=GetComponent<ColorController>();
      SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
      StartCoroutine(SlowCoroutine());
    }

    void Update()
    {

      if(force > maxForce)
      {
        force=maxForce;
      }
      if(direction!=null)
      {
        if(colorController.colors.Peek()==Color.red)
        {
          colorController.Combo+=1;
          force+= forceMod*colorController.Combo;
        }
        else
        {
          force=defaultForce;
          colorController.Combo=0;
        }
      }
      if(direction!=null){
        direction=null;
        rb.AddForce((direc2/normalizer)*force);
      }




      // if(direction == "Right")
      // {
      //   direction = null;
      //   rb.AddForce(Vector2.right * force);
      //
      // }
      // if(direction == "Left")
      // {
      //   direction = null;
      //   rb.AddForce(Vector2.left * force);
      // }
      // if(direction == "Up")
      // {
      //   direction = null;
      //   rb.AddForce(Vector2.up * force);
      // }
      // if(direction == "Down")
      // {
      //   direction = null;
      //   rb.AddForce(Vector2.down * force);
      // }

    }

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
      direction = data.Direction.ToString();
      direc2=data.EndPosition-data.StartPosition;


    }

    IEnumerator SlowCoroutine()
    {
      while(true){
        if(rb.velocity.x < 0.2f && rb.velocity.y <0.2f)
        {
          rb.AddForce(new Vector2(Random.Range(-10 , 10) , Random.Range(-10,10)));
        }
        yield return new WaitForSeconds(2);
      }


    }
}
