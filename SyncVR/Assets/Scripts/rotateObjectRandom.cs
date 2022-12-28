using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObjectRandom : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(10 * Time.deltaTime, 0f, 10 * Time.deltaTime, Space.Self);
    }
}
