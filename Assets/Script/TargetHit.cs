using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    // Start is called before the first frame update
    public float targetHealth = 300f;
    public Animator Anim;
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
        Destroy(gameObject,10);
    }
}
