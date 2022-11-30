using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainmenu : MonoBehaviour
{
    public GameObject bg;
    public GameObject about;
    public ObjectPickUp pickUp;
    public ObjectableZombie objectableZombie;
    public SwitchScene scene;

    // Start is called before the first frame update
    void Start()
    {
        bg.SetActive(true);
        about.SetActive(false);
    }

    public void aboutClicked()
    {
        bg.SetActive(false);
        about.SetActive(true);
    }

    public void exitClicked()
    {
        Application.Quit();
    }

    public void backClicked()
    {
        bg.SetActive(true);
        about.SetActive(false);
    }
    public void playClicked()
    {
        scene.LoadScene(1);
        objectableZombie.isKillZombie = false;
        pickUp.isPickedUp = false;
        objectableZombie.isKillZombie = false;
        objectableZombie.isScene1 = true;
        objectableZombie.isScene2 = false;
        objectableZombie.isScene3 = false;
        objectableZombie.isScene4 = false;
        objectableZombie.Zombie = 10;

    }
}
