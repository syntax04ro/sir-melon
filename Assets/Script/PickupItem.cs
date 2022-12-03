using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{

    public GameObject tasbih;
    public GameObject magicItem;
    public GameObject text3d;
    PlayerController controller;
    bool pickup;
    public PlayerScript player;
    public AudioSource src;
    public Mission mission;
    private float radiusItem = 2.5f;
    // Start is called before the first frame update

    public ObjectPickUp objectPickUp;
    public ObjectableZombie objectableZombie;
    private void Awake()
    {
        controller = new PlayerController();
        controller.Enable();
        controller.Land.ambil.performed += ctx => pickup = ctx.ReadValueAsButton();
        tasbih.SetActive(false);
    }
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

            if (Input.GetKeyDown("f") || pickup)
            {

                objectPickUp.isPickedUp = true;
                tasbih.SetActive(true);
                magicItem.SetActive(false);
                text3d.SetActive(false);
                // Debug.Log(isPickup);
                mission.getDataMission(true, false);
                src.Play();
            }
        }
        else
        {
            text3d.SetActive(false);
        }
    }
}
