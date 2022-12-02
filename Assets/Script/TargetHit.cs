using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public float targetHealth = 100f;
    public AudioSource src;
    public Animator Anim;
    public ObjectableZombie objectableZombie;
    private void Start() {
        src.Play();
    }
    public void TakeDamage(float amount)
    {
        targetHealth -= amount;

        // Debug.Log("Target Health: " + targetHealth);
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
        if(objectableZombie.isScene2 == true && objectableZombie.Zombie == 0) Mission.objek.getDataMission(true,false);
        if(objectableZombie.isScene3 == true && objectableZombie.Zombie == 0) Mission.objek.getDataMission(true,false);
    }
}
