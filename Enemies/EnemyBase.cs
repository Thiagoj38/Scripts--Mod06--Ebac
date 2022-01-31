using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBase : MonoBehaviour, IKillable, IDamageable<int>
{


    #region Variables

    public EnemySetup enemySetup;
    public int life;
    public GameObject enemy;
    public Action OnHitTarget;
    public string tagToLook = "Projectile";
    protected int damage = 2;

    #endregion

    #region METHODS


    public virtual void Damage()
    {

        
        life -= damage;
        Kill();

    }

    public virtual void Kill()
    {
        if (life == 0 || life < 0)
        {
            GameObject.Destroy(enemy);
        }
    }
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToLook)
        {
            //Destroy(collision.gameObject);
            //OnHitTarget?.Invoke();
            Damage();

        }
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        life = enemySetup.startLife;
    }

    private void Update()
    {
        
    }

}
