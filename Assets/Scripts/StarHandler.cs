using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHandler : MonoBehaviour
{
    private UIController ui;
    public GameObject ps;
    private float addTime=5f;
    private int addScore=10;
    private float particleLifeTime=4f;
    void Start()
    {
      ui=GameObject.Find("UIManager").GetComponent<UIController>();
    }
    void OnTriggerEnter2D(Collider2D col){

      if(col.tag=="Player"){
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score",0)+addScore);
        ui.timeRemaining+=addTime;
      }
      GameObject go =Instantiate(ps,this.transform.position,Quaternion.identity);
      Destroy(go,particleLifeTime);
      Destroy(this.gameObject);
    }

}
