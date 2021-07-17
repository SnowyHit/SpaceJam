using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0f, 0.01f, Space.Self);
    }
}
