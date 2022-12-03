using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadNotes : MonoBehaviour
{


    public GameObject _noteImage;
    public GameObject noteUi;
    PlayerController controller;
    bool openpress;
    bool isRead = false;
    public AudioSource src;
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
            if (isRead == true)
            {
                noteUi.SetActive(false);
                isRead = false;
                _noteImage.SetActive(true);
                src.Play();
            }
        }

    }
    private void Start()
    {
        noteUi.SetActive(false);
        _noteImage.SetActive(false);
    }


    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            noteUi.SetActive(true);
            isRead = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            noteUi.SetActive(false);
            isRead = false;
            _noteImage.SetActive(false);
        }
    }
}
