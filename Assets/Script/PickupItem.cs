using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{

    public GameObject tasbih;
    public GameObject magicItem;
    public GameObject text3d;

    public PlayerScript player;
    public AudioSource src;
    public AudioClip completed;

    public Mission mission;
    private float radiusItem = 2.5f;
    // Start is called before the first frame update

    public ObjectPickUp objectPickUp;
    public ObjectableZombie objectableZombie;
    private void Awake()
    {
        tasbih.SetActive(false);
    }
    private void Start()
    {
        text3d.SetActive(false);
        objectPickUp.isPickedUp = false;
        objectableZombie.isKillZombie = false;
        objectableZombie.isScene1 = true;
        objectableZombie.isScene2 = false;
        objectableZombie.isScene3 = false;
        objectableZombie.isScene4 = false;
        objectableZombie.Zombie = 10;
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
                tasbih.SetActive(true);
                magicItem.SetActive(false);
                text3d.SetActive(false);
                // Debug.Log(isPickup);
                mission.getDataMission(true, false);
                src.clip = completed;
                src.Play();
            }
        }
        else
        {
            text3d.SetActive(false);
        }
    }
}
