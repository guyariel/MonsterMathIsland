using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    [SerializeField] int amountOfMonsters = 10;
    [SerializeField] Transform monsterSpwanPoints;
    [SerializeField] Transform queuePoint;
    [SerializeField] Transform attackPoint;
    [SerializeField] GameObject[] monsterPrefabs;
    [SerializeField] float waveDifficulty;

    public List<GameObject> monsters;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Adding random monsters to the scene view
        for (int i = 0; i < amountOfMonsters; i++)
        {
            InstantiateMonster();
        }

        MonstersAttacks(0);
        waveDifficulty = calculateWaveDifficulty();
    }

    private void InstantiateMonster()
    {
        int monsterIndex = Random.Range(0, monsterPrefabs.Length);
        GameObject monster = Instantiate(monsterPrefabs[monsterIndex], monsterSpwanPoints.position, monsterSpwanPoints.rotation);

        monsters.Add(monster);
    }
        
    public void MonstersAttacks (int monsterIndex)
    {
        if (monsters.Count <= monsterIndex) return;

        Transform monster = monsters[monsterIndex].transform;
        monster.position = attackPoint.position;
        monster.rotation = attackPoint.rotation;
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
