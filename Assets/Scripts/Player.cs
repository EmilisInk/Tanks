using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isPlayer1 = true;

    [Header("Movement Settings")]
    public float speed = 10;
    [Header("Shooting Settings")]
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    private float cooldown = 2;


    private bool canStir = true;
    private Rigidbody rb;
    private Vector3 direction = new();


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating(nameof(Shoot), cooldown, cooldown);
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(20 * transform.forward, ForceMode.Impulse);
    }
    void Update()
    {
        if (isPlayer1)
        {
            direction.x = Input.GetAxisRaw("Horizontal1");
            direction.z = Input.GetAxisRaw("Vertical1");
        }
        else
        {
            direction.x = Input.GetAxisRaw("Horizontal2");
            direction.z = Input.GetAxisRaw("Vertical2");
        }
        

        if(direction != Vector3.zero)
        {
            transform.forward = direction.normalized;
        }
    }
    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        if (canStir)
        {
            rb.velocity = direction.normalized * speed;
        }
        }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ice"))
        {
            canStir = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ice"))
        {
            canStir = false;
        }
    }
}
