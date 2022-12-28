using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObjects : MonoBehaviour
{
    public GameObject[] objects;
    [SerializeField]
    private GameObject[] spawnedObjects;
    Collider m_Collider;
    Vector3 m_Point;

    void Start()
    {
        //spawn objects till theres as much as the game difficulty states
        for (int i = 0; i < GameManager.gameDifficulty[GameManager.difficultySetting]; i++)
        {
            if(spawnedObjects[i] == null)
            {
                spawnedObjects[i] = Instantiate(objects[Random.Range(0, objects.Length)], new Vector3(Random.Range(-100, 100), Random.Range(-20,60), Random.Range(-100, 100)), Quaternion.identity);
                //check if spawned object isn't overlapping with another collider.
                checkColl(i);
            }           
        }
    }
    
    public void checkColl(int spawnedObject)
    {
        Vector3 spawnedLocation = spawnedObjects[spawnedObject].transform.position;

        var hitColliders = Physics.OverlapSphere(spawnedLocation, 1);

        if (hitColliders.Length > 2) //if theres more than 2 collidor within 12 radius, delete spawned object
        {
            Destroy(spawnedObjects[spawnedObject]);
            spawnedObjects[spawnedObject] = Instantiate(objects[Random.Range(0, objects.Length)], new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100)), Quaternion.identity);
        }
    }
}
