using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(Time.time >=14)
        {
            scene.LoadScene(2);
        }        
    }

    public void SceneData(int index)
    {
        scene.LoadScene(index);
    }

}
