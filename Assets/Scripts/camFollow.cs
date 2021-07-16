using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{
    private Transform target;
  	public float smoothSpeed = 0.125f;
  	public Vector3 offset;

    void Start()
    {
      target = GameObject.Find("Player").transform;
    }

  	void FixedUpdate ()
  	{
      Vector3 targetPos  = new Vector3(target.position.x + offset.x , target.position.y + offset.y , target.position.z + offset.z);
  		transform.position = Vector3.MoveTowards(transform.position , targetPos, smoothSpeed);
  	}

}
