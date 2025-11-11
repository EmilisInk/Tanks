using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static int spawnCount;

    public List<GameObject> prefabs;
    public int amount = 10;

    public Vector3 mapStart = new Vector3 (-11, 0, -11);
    public Vector3 mapEnd = new Vector3 (11, 0, 11);

    private void Update()
    {
        if (spawnCount < amount)
        {
            spawnCount++;
            var position = new Vector3();
            position.x = Random.Range(mapStart.x, mapEnd.x);
            position.y = 5;
            position.z = Random.Range(mapStart.z, mapEnd.z);

            var rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            
            var p = prefabs[Random.Range(0, prefabs.Count)];

            Instantiate(p, position, rotation);
        }
    }

    private void Start()
    {
        spawnCount = 0;
    }
}
