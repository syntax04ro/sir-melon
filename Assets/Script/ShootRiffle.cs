using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRiffle : MonoBehaviour
{
    public Camera cam;
    public float damage = 10f;
    public float range = 5f;
    public Animator Anim;
    public GameObject swordInPinggang; 
    public GameObject swordInTangan;
    public GameObject effectPunch;

    bool isTakeSword = true;
    bool isSaveSword = false;

    public ObjectPickUp objectPickUp;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(h, 0f, v).normalized;

        float data = Anim.GetFloat("speed");
        if (Input.GetButtonDown("Fire1") && isSaveSword == true)
        {
            Shoot();
            Anim.SetBool("isPunch", true);

            // float a = Time.time;
            // if(a > nextToTime){
            //     Anim.SetBool("isPunch2", true);
            //     nextToTime += Time.time/5;  
            // }else{
            //     Anim.SetBool("isPunch2", false);
            // }

            // Debug.Log(Anim.GetBool("isPunch2") + " =  " + a + " data time " + nextToTime);

        
        }
        else if (Input.GetButtonDown("Fire1") && data == 0.1 && isSaveSword == true)
        {
            Shoot();
            Anim.SetBool("isPunch", true);
        }
        else if (Input.GetButtonDown("Fire1") && Input.GetButtonDown("Fire2") && isSaveSword == true)
        {
            Shoot();
            Anim.SetBool("isPunch", true);
        }
        else
        {
            Anim.SetBool("isPunch", false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha1) && isTakeSword == true && objectPickUp.isPickedUp == true)
        {
            Anim.SetBool("isTakeSword", true);
            swordInPinggang.SetActive(false);
            swordInTangan.SetActive(true);
            isTakeSword = false;
            isSaveSword = true;
            
        }
        if(Input.GetKeyUp(KeyCode.Alpha1)) Anim.SetBool("isTakeSword", false);
        if(Input.GetKeyDown(KeyCode.Alpha2) && isSaveSword == true  && objectPickUp.isPickedUp == true)
        {
            Anim.SetBool("isSaveSword", true);
            swordInPinggang.SetActive(true);
            swordInTangan.SetActive(false);
            isSaveSword = false;
            isTakeSword = true;
        }
        // Debug.Log("isPick up" + objectPickUp.isPickedUp);
        if(Input.GetKeyUp(KeyCode.Alpha2)) Anim.SetBool("isSaveSword", false);
    }

    private void Shoot()
    {


        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            // Debug.Log(hit.transform.name);
            TargetHit target = hit.collider.GetComponent<TargetHit>();
            // Debug.Log(target);

            if (target != null)
            {
                target.TakeDamage(damage);
                GameObject targetObject = Instantiate(effectPunch, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(targetObject, 1f);
            }
        }
    }

    private void Start() {

    }
}