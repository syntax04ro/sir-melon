using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float targetHealth = 650f;
    public Animator Anim;
    public HealthBar healthBar;
    public ObjectableZombie objectableZombie;
    public void TakeDamage(float amount)
    {
        targetHealth -= amount;
        healthBar.setHealth(targetHealth);
        
        if (targetHealth <= 0f)
        {
            Anim.SetTrigger("isDie");
            GetComponent<Collider>().enabled = false;
            Die();
        }
    }

    void Die()
    {
        objectableZombie.isKillZombie = true;
        Destroy(gameObject,10);
        objectableZombie.Zombie -= 1;
    }
}
