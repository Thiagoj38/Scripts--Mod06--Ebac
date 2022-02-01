using System;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 dir;
    public float timeToReset = 5f;

    public string tagToLook = "Enemy";


    void Update()
    {
        transform.Translate(dir * Time.deltaTime);
    }


    public void StartProjectile()
    {
        Invoke(nameof(FinishUsage), timeToReset);

    }

    private void FinishUsage()
    {
        gameObject.SetActive(false);
        CancelInvoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {            
            FinishUsage();
        }
                
    }      


}



