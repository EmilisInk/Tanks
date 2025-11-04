using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3;

    void Start()
    {
        Invoke(nameof(SelfDestruct), lifeTime);
    }

    void SelfDestruct()
    {
        //TODO: vfx
        Destroy(gameObject);
    }
}
