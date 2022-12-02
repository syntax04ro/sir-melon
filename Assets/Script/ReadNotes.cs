using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadNotes : MonoBehaviour
{


    public GameObject _noteImage;
    public GameObject noteUi;

    bool isRead = false;
    public AudioSource src;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(isRead);
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
