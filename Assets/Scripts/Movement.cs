using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource aSource;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 100f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aSource = GetComponent<AudioSource>();
        // aSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateRocket(true);
        } else if (Input.GetKey(KeyCode.D))
        {
            RotateRocket();
        }
    }

    void RotateRocket(bool isLeft = false) 
    {
        rb.freezeRotation = true;
        transform.Rotate(
            Vector3.forward * Time.deltaTime * rotationThrust * (isLeft ? 1 : -1)
        );
        rb.freezeRotation = false;
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!aSource.isPlaying) {
                aSource.Play();
            }

            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        } else {
            if (aSource.isPlaying) {
                aSource.Stop();
            }
        }
    }
}
