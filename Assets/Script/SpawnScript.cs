using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] Enemy;
    // public GameObject[] Spawn;
    List<Transform> Spawn = new List<Transform>();
    public int enemyCount;
    public ObjectableZombie objectableZombie;
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("SpawnPoints");
        foreach(Transform t in go.transform){
            Spawn.Add(t);
        }
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy(){
        while(enemyCount < 10){
            GameObject NewZombie = Instantiate(Enemy[Random.Range(0,Enemy.Length)], Spawn[Random.Range(0,Spawn.Count)].position, Quaternion.identity);
            yield return new WaitForSeconds(1);
            enemyCount += 1;
        }
    }
}
