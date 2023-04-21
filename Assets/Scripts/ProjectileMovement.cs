using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speedMin = 3f;
    public float speedMax = 8f;

    private float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        speed = Random.Range(speedMin, speedMax);
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(speed * -1, 0, 0) * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
        if (transform.position.x <= -5f)
        {
            transform.position = new Vector3(23f, transform.position.y, transform.position.z);
            speed = Random.Range(speedMin, speedMax);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        this.transform.position= new Vector3(23f, -2f, 0f);
        this.transform.rotation= Quaternion.Euler(0, 0, 0);
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        speed = Random.Range(speedMin, speedMax);
    }
    /*private void OnTriggerEnter(Collider other)
    {
        transform.position = new Vector3(23f, -2.17f, 0f);
        speed = Random.Range(speedMin, speedMax);
    }*/
}
