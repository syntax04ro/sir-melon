using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    PlayerController controller;
    bool isOpen = false;
    bool openpress;
    public GameObject noteUi;
    void Awake()
    {
        controller = new PlayerController();
        controller.Enable();
        controller.Land.buka.performed += ctx => openpress = ctx.ReadValueAsButton();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || openpress)
        {
            if (isOpen == true)
            {
                door.transform.position = new Vector3(8.089f, transform.position.y, transform.position.z);

            }
        }

    }
    private void Start()
    {
        isOpen = false;
        noteUi.SetActive(false);
        door.transform.position = new Vector3(6.159f, 1.967f, -1.211f);
    }


    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpen = true;
            noteUi.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpen = false;
            noteUi.SetActive(false);
            
        }
    }
}