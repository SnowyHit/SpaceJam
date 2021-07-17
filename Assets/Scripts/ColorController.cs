using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    float secondsToWait=1;
    private int combo=0;
    public int Combo{
      get{
        return combo;
      }
      set{
        combo=value;
      }
    }

    public Queue<Color> colors=new Queue<Color>();

    private void Awake(){
      spriteRenderer=GetComponent<SpriteRenderer>();
      colors.Enqueue(Color.red);
      colors.Enqueue(Color.magenta);
      colors.Enqueue(Color.white);
    }
    private void Start(){

      StartCoroutine(ColorCoroutine());
    }
    private void Update(){
      secondsToWait=1-(combo*0.05f);

    }
    IEnumerator ColorCoroutine()
    {
      while(true){
        Color temp = colors.Dequeue();
        colors.Enqueue(temp);
        spriteRenderer.color=temp;

        yield return new WaitForSeconds(secondsToWait);
      }


    }




}
