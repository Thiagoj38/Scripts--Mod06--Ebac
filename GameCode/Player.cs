using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject projectile;
    public Transform shootPoint;
    public Vector3 dir;
    public PoolManager poolManager;
    public bool canMove = false;
    public int deathNumber = 0;

    

    

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(dir * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-dir * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnObject();

        }
    }

    private void SpawnObject()
    {
        var obj = poolManager.GetPooledObject();
        if (obj == null) return;
       
        

        obj.SetActive(true);
        obj.GetComponent<Projectile>().StartProjectile();
        

        obj.transform.SetParent(null);
        obj.transform.position = shootPoint.transform.position;

        
    }

    
}

