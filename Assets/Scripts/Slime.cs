using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float lifetime = 15;

    private void Start()
    {
        Invoke(nameof(selfDestruct), lifetime);
    }

    void selfDestruct()
    {
        //TODO: vfx
        Destroy(gameObject);
    }
}
