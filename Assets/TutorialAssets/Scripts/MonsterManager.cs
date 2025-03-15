using System.Collections.Generic;
using System.Linq;
using TutorialAssets.Scripts;
using UnityEditor.Rendering;
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
        monster.GetComponent<MonsterController>().ChangeState(MonsterState.Attack);
        monster.position = attackPoint.position;
        monster.rotation = attackPoint.rotation;
    }

    public void MoveMonsterToQueue (int monsterIndex)
    {
        if (monsters.Count <= monsterIndex) return;

        Transform monster = monsters[monsterIndex].transform;
        monster.GetComponent<MonsterController>().ChangeState(MonsterState.Queue);
        monster.position = queuePoint.position;
        monster.rotation = queuePoint.rotation;
    }

    public void MoveNextMonsterToQueue ()
    {
        MoveMonsterToQueue(1);
    }

    public void KillMonster (int monsterIndex)
    {
        Destroy(monsters[monsterIndex]);
        monsters.RemoveAt(monsterIndex);
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
