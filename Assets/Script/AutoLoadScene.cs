using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System; 
public class AutoLoadScene : MonoBehaviour
{
    public SwitchScene scene;
    float countDownStartValue = 0;
    public ObjectableZombie objectableZombie;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);
        countDownStartValue++;
        Invoke("countDownTimer", 1.0f);
        if (countDownStartValue >= 1400)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void SceneData(int index)
    {
        SceneManager.LoadScene(index);
    }

}
