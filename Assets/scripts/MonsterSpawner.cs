using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] monsterRefrence;
    [SerializeField]
    private Transform leftPos, rightPos;

    private GameObject spawnedMonster;

    private int randomIndex;
    private int randomSide;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterRefrence.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterRefrence[randomIndex]);

            if (randomSide == 0)
            {
                //left side spawn 
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<monster>().speed = Random.Range(4, 10);
            }
            else
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<monster>().speed = Random.Range(-4, -10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }

        }
    }

}
