using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public List<GameObject> monsterKind;
    public Transform[] spawnPlace;
    public Vector3 spawnPosition;

    float timer;
    public float timeInterval;
    /// <summary> 게임이 시작되면 </summary>
    public bool m_HasGameStared;
    public int m_SpawnLevel;
    

    void Start()
    {
        //spawnPlace = GetComponentsInChildren<Transform>();
        m_HasGameStared = GameManager.gameManager.curGUIState != 1;
        m_SpawnLevel = GameManager.gameManager.m_TimeStampLevel;
    }

    private void Update()
    {
        m_HasGameStared = GameManager.gameManager.curGUIState != 1;
        m_SpawnLevel = GameManager.gameManager.m_TimeStampLevel;
        //Debug.Log("진");
        if (m_HasGameStared)
            return;
        //Debug.Log("입");
        timer += Time.deltaTime;
        if (timer > timeInterval)
        {
            timer = 0;
            Spawn();
        }
    }

    void SummonBoss()
    {
        
    }


    void Spawn() 
    {
        List<int> allowedIndices = new List<int>(); ;
        int randomMonsterIndex = 0;

        switch (m_SpawnLevel)
        {

            case 1:
                allowedIndices.Clear();
                allowedIndices.Add(0);
                randomMonsterIndex = allowedIndices[Random.Range(0, allowedIndices.Count)];

                break;
            case 2:
                allowedIndices.Clear();
                allowedIndices.Add(0);
                allowedIndices.Add(1);
                randomMonsterIndex = allowedIndices[Random.Range(0, allowedIndices.Count)];


                break;
            case 3:
                allowedIndices.Clear();
                allowedIndices.Add(2);
                allowedIndices.Add(3);
                randomMonsterIndex = allowedIndices[Random.Range(0, allowedIndices.Count)];
                break;
            case 4:
                allowedIndices.Clear();
                allowedIndices.Add(3);
                allowedIndices.Add(4);
                randomMonsterIndex = allowedIndices[Random.Range(0, allowedIndices.Count)];
                break;
            case 5:
                allowedIndices.Clear();
                allowedIndices.Add(6);
                allowedIndices.Add(4);
                allowedIndices.Add(5);
                randomMonsterIndex = allowedIndices[Random.Range(0, allowedIndices.Count)];
                break;
            case 6:
                allowedIndices.Clear();
                allowedIndices.Add(6);
                allowedIndices.Add(5);
                randomMonsterIndex = allowedIndices[Random.Range(0, allowedIndices.Count)];
                break;
            case 7:
                allowedIndices.Clear();
                allowedIndices.Add(6);
                randomMonsterIndex = allowedIndices[Random.Range(0, allowedIndices.Count)];
                break;
        }  


        //int randomMonsterIndex = Random.Range(0, monsterKind.Count);
        GameObject selectedMonsterPrefab = monsterKind[randomMonsterIndex];
        spawnPosition = spawnPlace[Random.Range(1, spawnPlace.Length)].position;
        GameObject spawnedMonster = Instantiate(selectedMonsterPrefab, spawnPosition, Quaternion.identity);
        spawnedMonster.transform.parent = GameObject.Find("Teki").transform;
    }

    /*
    void SpawnMonster(Vector3 spawnPosition)
    {
        // 몬스터 종류가 설정되어 있지 않으면 아무것도 하지 않음
        if (monsterKind.Count == 0)
        {
            Debug.LogWarning("Monster kinds are not set in the inspector.");
            return;
        }

        // 랜덤한 몬스터 종류 선택
        int randomMonsterIndex = Random.Range(0, monsterKind.Count);
        GameObject selectedMonsterPrefab = monsterKind[randomMonsterIndex];
        GameObject spawnedMonster = Instantiate(selectedMonsterPrefab, spawnPosition, Quaternion.identity);

    }
    */


}
