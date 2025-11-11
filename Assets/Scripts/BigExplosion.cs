using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigExplosion : MonoBehaviour
{
    public float radius = 6;
    private float force = 60;
    public ForceMode mode = ForceMode.Impulse;

    void Start()
    {
        var collider = Physics.OverlapSphere(transform.position, radius);

        foreach(var c in collider)
        {
            var rb = c.attachedRigidbody;
            if(rb != null)
            {
                var direction = (rb.transform.position - transform.position).normalized;
                rb.AddForce(direction * force, mode);
            }
            
            var health = c.GetComponent<Health>();
            if(health != null )
            {
                health.Damage(20);
            }
        }
    }
}
