using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AutoLoadScene : MonoBehaviour
{
    public SwitchScene scene;
    public ObjectableZombie objectableZombie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >=32)
        {
            SceneManager.LoadScene(3);
        }     
        Debug.Log(Time.time);   
    }

    public void SceneData(int index)
    {
        SceneManager.LoadScene(index);
    }

}
