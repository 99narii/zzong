using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Spawner : MonoBehaviour
{
    public GameObject applePrefab;    // ��� ������
    public GameObject bugPrefab;      // ���� ������
    public float ApplespawnInterval = 0.5f; // ������Ʈ ���� ���� (��)
    public float BugspawnInterval = 0.8f; // ������Ʈ ���� ���� (��)
    public float minX = -6f; // ���� ��ġ�� �ּ� x��
    public float maxX = 8.13f;  // ���� ��ġ�� �ִ� x��
    bool isGameOver = false;

    private void Start()
    {
        // ���� �������� �Լ� ȣ��
        InvokeRepeating("SpawnApple", 0f, ApplespawnInterval);
        InvokeRepeating("SpawnBug", 0f, BugspawnInterval);
    }

    private void Update()
    {
        isGameOver = GameObject.FindWithTag("GamePlayer").GetComponent<MiniGamePlayer>().isGameOver;
    }
    // ���� ������Ʈ ���� �Լ�
    void SpawnApple()
    {
        if (!isGameOver)
        {
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, 5.8f, -3.1f);
            Instantiate(applePrefab, spawnPosition, Quaternion.identity);
        }

    }

    void SpawnBug()
    {
        if (!isGameOver)
        {
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, 5.8f, -3.1f);
            Instantiate(bugPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
