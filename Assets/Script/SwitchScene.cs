using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SwitchScene : MonoBehaviour
{
    public GameObject noteUi;
    public GameObject loadingScreen;
    public Text textProgress;

    public Slider slider;
    public ObjectPickUp objectPickUp;

    public ObjectableZombie objectableZombie;

    bool isArea = false;


    // Update is called once per frame
    void Start()
    {
        noteUi.SetActive(false);
        isArea = false;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (isArea == true)
            {

                if (objectPickUp.isPickedUp == true && objectableZombie.isScene1 == true)
                {
                    SceneManager.LoadScene(2);
                    objectableZombie.isScene1 = false;
                    objectableZombie.isScene2 = true;
                }
                if (objectableZombie.Zombie == 0 && objectableZombie.isScene2 == true)
                {
                    LoadScene(4);
                    objectableZombie.isScene2 = false;
                    objectableZombie.isScene3 = true;
                    objectableZombie.Zombie = 10;
                }
                if (objectableZombie.Zombie == 0 && objectableZombie.isScene3 == true)
                {
                    LoadScene(5);
                    objectableZombie.isScene3 = false;
                    objectableZombie.isScene4 = true;
                }
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isArea = true;
            noteUi.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isArea = false;
            noteUi.SetActive(false);
        }
    }

    public void LoadScene(int loadIndex)
    {
        StartCoroutine(LoadAsync(loadIndex));
    }

    IEnumerator LoadAsync(int loadIndex)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(loadIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progressIndicator = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progressIndicator;
            textProgress.text = progressIndicator * 100f + "%";
            yield return null;
        }
    }
}
