using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject effectPrefab;
    public float countdown = 3;

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Bullet"))
        {
            Invoke(nameof(Explode), countdown);
        }
    }

    public void Explode()
    {
        var position = transform.position;
        position.y = 0;
        var rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        Instantiate(effectPrefab, position, rotation);
        Spawner.spawnCount--;
        Destroy(gameObject);
    }
}
