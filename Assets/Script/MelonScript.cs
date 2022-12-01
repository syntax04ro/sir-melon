using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelonScript : MonoBehaviour
{
    Rigidbody rb;
    bool hasExplode = false;
    public float velocityY;
    public GameObject EffectMeledak;
    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0,-velocityY,0);
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Ground"){
            if(!hasExplode){
                Meledak();
                hasExplode = true;
            }
        }
        if(other.gameObject.tag == "Player"){
            PlayerScript.playerScript.playerTakeDamage(50f);
        }
    }
    void Meledak(){
        GameObject Ledakan = Instantiate(EffectMeledak, transform.position, transform.rotation);
        Destroy(Ledakan,1);
    }
}
