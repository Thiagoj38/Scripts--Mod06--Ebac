using System;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 dir;
    public float timeToReset = 8f;

    public string tagToLook = "Enemy";

    public Action OnHitTarget;

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
        OnHitTarget = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {            
            //OnHitTarget?.Invoke();
            FinishUsage();
        }
        else
        {
            StartProjectile();
        }
    }      


}


