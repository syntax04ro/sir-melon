using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secretPick : MonoBehaviour
{
    
    public GameObject magicItem;
    public GameObject text3d;

    public PlayerScript player;
    public AudioSource src;
    private float radiusItem = 2.5f;
    // Start is called before the first frame update

    public ObjectPickUp objectPickUp;


    private void Start()
    {
        text3d.SetActive(false);
 
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < radiusItem)
        {
            text3d.SetActive(true);

            if (Input.GetKeyDown("f"))
            {

                objectPickUp.isPickedUp = true;
                magicItem.SetActive(false);
                text3d.SetActive(false);
                src.Play();
            }
        }
        else
        {
            text3d.SetActive(false);
        }

        Debug.Log(Vector3.Distance(transform.position, player.transform.position));
    }
}
