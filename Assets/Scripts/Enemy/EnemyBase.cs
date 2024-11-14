using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Setup")]
    public EnemySetup enemysetup;

    public int damage = 10;

    public HealthBase healthBase;
    public Animator animator;
    public string triggerattack = "attack";
    public string triggerKill = "kill";

    private void Awake()
    {

        //int damage = enemysetup.damage;

        if (healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill;
        }
    }

    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;
        //PlayKillAnimation();
        PlaykillAnimation();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();

        if(health != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {

       animator.SetTrigger(triggerattack);

    }

        private void PlaykillAnimation()
    {

       animator.SetTrigger(triggerKill);

    }

    public void Damage(int amount)
    {
        healthBase.Damage(amount);
    }

}
