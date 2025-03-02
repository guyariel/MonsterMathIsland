using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    [SerializeField] int amountOfMonsters = 10;
    [SerializeField] Transform monsterSpwanPoints;
    [SerializeField] GameObject[] monsterPrefabs;

    public List<GameObject> monsters;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Adding random monsters to the scene view
        for (int i = 0; i < amountOfMonsters; i++)
        {
            int monsterIndex = Random.Range(0, monsterPrefabs.Length);
            GameObject monster = Instantiate(monsterPrefabs[monsterIndex], monsterSpwanPoints.position, monsterSpwanPoints.rotation);

            monsters.Add(monster);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
