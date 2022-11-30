using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRiffle : MonoBehaviour
{
    public Camera cam;
    public float damage = 10f;
    public float range = 4f;
    public Animator Anim;
    public GameObject swordInPinggang;
    public GameObject swordInTangan;
    public GameObject effectPunch;

    public float maxDelay = 0.7f;
    private float lasCLick = 0;
    public float numClicks = 0;
    private float nextTime = 0;

    bool isTakeSword = true;
    bool isSaveSword = false;

    public ObjectPickUp objectPickUp;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Time.time - lasCLick > maxDelay)
        {
            numClicks = 0;
        }
        if(numClicks == 0)
        {
            Anim.SetBool("isPunch", false);
            Anim.SetBool("isPunch2", false);
        }
        if(numClicks >= 3)
        {
            numClicks = 0;
            Anim.SetBool("isPunch", false);
            Anim.SetBool("isPunch2", false);
        }
        if (Anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && Anim.GetCurrentAnimatorStateInfo(0).IsName("isPunch"))
        {
            Anim.SetBool("isPunch", false);
        }
        if (Anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && Anim.GetCurrentAnimatorStateInfo(0).IsName("isPunch2"))
        {
            Anim.SetBool("isPunch2", false);
            numClicks = 0;
        }
        float data = Anim.GetFloat("speed");
        if (Time.time > nextTime)
        {
            if (Input.GetButtonDown("Fire1") && isSaveSword == true)
            {
                getPunch();
                Shoot();

            }
            else if (Input.GetButtonDown("Fire1") && data == 0.1 && isSaveSword == true)
            {
                getPunch();
                Shoot();
            }
            else if (Input.GetButtonDown("Fire1") && Input.GetButtonDown("Fire2") && isSaveSword == true)
            {
                getPunch();
                Shoot();
            }
            else
            {
                Anim.SetBool("isPunch", false);
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && isTakeSword == true && objectPickUp.isPickedUp == true)
        {
            Anim.SetBool("isTakeSword", true);
            swordInPinggang.SetActive(false);
            swordInTangan.SetActive(true);
            isTakeSword = false;
            isSaveSword = true;

        }
        if (Input.GetKeyUp(KeyCode.Alpha1)) Anim.SetBool("isTakeSword", false);
        if (Input.GetKeyDown(KeyCode.Alpha2) && isSaveSword == true && objectPickUp.isPickedUp == true)
        {
            Anim.SetBool("isSaveSword", true);
            swordInPinggang.SetActive(true);
            swordInTangan.SetActive(false);
            isSaveSword = false;
            isTakeSword = true;
        }
        // Debug.Log("isPick up" + objectPickUp.isPickedUp);
        if (Input.GetKeyUp(KeyCode.Alpha2)) Anim.SetBool("isSaveSword", false);
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

    public void getPunch()
    {
        lasCLick = Time.time;
        numClicks++;

        if (numClicks == 1)
        {
            Anim.SetBool("isPunch", true);
        }
        numClicks = Mathf.Clamp(numClicks, 0, 3);

        if (numClicks == 2)
        {
            Anim.SetBool("isPunch", false);
            Anim.SetBool("isPunch2", true);
        }
    }
}