using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject[] Melons;
    public GameObject[] Spawns;
    float Delay;
    public float targetHealth = 650f;
    public Animator Anim;
    public HealthBoss healthBar;
    public ObjectableZombie objectableZombie;
    void Start() {
        healthBar.MaxHealth(targetHealth);
    }
    public void TakeDamage(float amount)
    {
        targetHealth -= amount;
        healthBar.setHealth(targetHealth);
        if(targetHealth <= 325f)
        {
            Anim.SetTrigger("Roar");
            AttackBossScript.damageZombie = 50f;
        }
        if(targetHealth <=162.5f)
        {
            StartCoroutine(SpawnMelon());
        }
        if (targetHealth <= 0f)
        {
            Anim.SetTrigger("Die");
            GetComponent<Collider>().enabled = false;
            Die();
        }
    }
    void Die()
    {
        objectableZombie.isKillZombie = true;
        Destroy(gameObject,5);
        objectableZombie.Zombie -= 1;
    }
    IEnumerator SpawnMelon(){
        while(targetHealth > 0){
            GameObject Melon = Instantiate(Melons[Random.Range(0,Melons.Length)], Spawns[Random.Range(0,Spawns.Length)].transform.position, Quaternion.identity);
            Destroy(Melon,3);
            yield return new WaitForSeconds(1);
        }
        
    }
}
