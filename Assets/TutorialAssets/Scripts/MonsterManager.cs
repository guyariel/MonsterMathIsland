using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    [SerializeField] int amountOfMonsters = 10;
    [SerializeField] Transform monsterSpwanPoints;
    [SerializeField] GameObject[] monsterPrefabs;
    [SerializeField] float waveDifficulty;

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

        waveDifficulty = calculateWaveDifficulty();
    }

    float calculateWaveDifficulty()
    {
        float difficulty = 0;

        foreach (GameObject monster in monsters)
        {
            difficulty += monster.GetComponent<Points>().points;
        }

        difficulty /= (amountOfMonsters * 3);

        return difficulty;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
