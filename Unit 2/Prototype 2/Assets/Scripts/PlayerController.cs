using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;

    public GameObject projectilePrefab;
    

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }


        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            // send projectile
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }


        horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
     
    }
}
