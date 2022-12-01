using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
    public Text mission1;


    public static Mission objek;
    public ObjectableZombie objectableZombie;
    // Start is called before the first frame update
    private void Awake()
    {
        objek = this;
    }

    public void getDataMission(bool data1, bool data2)
    {

        if (objectableZombie.isScene1 == true)
        {
            if (data1 == true)
            {
                mission1.text = "Completed";
                mission1.color = Color.green;
            }
            else
            {
                mission1.text = "01. Find Item";
                mission1.color = Color.white;
            }
        }
        else if (objectableZombie.isScene2 == true)
        {
            if (data1 == true)
            {
                mission1.text = "Completed";
                mission1.color = Color.green;
            }
            else
            {
                mission1.text = "01. Kill All Zombies";
                mission1.color = Color.white;
            }
        }
        else if (objectableZombie.isScene3 == true)
        {
            if (data1 == true)
            {
                mission1.text = "Completed";
                mission1.color = Color.green;
            }
            else
            {
                mission1.text = "01. Kill All Zombies";
                mission1.color = Color.white;
            }
        }
           else if (objectableZombie.isScene4 == true)
        {
            if (data1 == true)
            {
                mission1.text = "Completed";
                mission1.color = Color.green;
            }
            else
            {
                mission1.text = "01. Kill Boss Enemies";
                mission1.color = Color.white;
            }
        }
        else
        {
            return;
        }


    }

}
