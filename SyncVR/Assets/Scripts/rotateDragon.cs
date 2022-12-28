using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateDragon : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, Random.Range(0, 100) * Time.deltaTime,0f, Space.Self);
    }
}
