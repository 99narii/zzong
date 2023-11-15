using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBranch : MonoBehaviour
{
    public GameObject Branch;  
    public Terrain terrain;       
    public int numberOfItems = 100;    

    void Start()
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            // Terrain�� ��� ������ ������ ��ġ�� ã��.
            float x = Random.Range(terrain.transform.position.x, terrain.transform.position.x + terrain.terrainData.size.x);
            float z = Random.Range(terrain.transform.position.z, terrain.transform.position.z + terrain.terrainData.size.z);

            // ������ ��ġ�� �ش��ϴ� Terrain�� ���̸� ã��.
            float y = terrain.SampleHeight(new Vector3(x, 0, z)) + terrain.transform.position.y;

            // ������ ��ġ�� ������ Prefab�� �ν��Ͻ�ȭ.
            Instantiate(Branch, new Vector3(x, y+0.2f, z), Quaternion.identity);
        }
    }
}
