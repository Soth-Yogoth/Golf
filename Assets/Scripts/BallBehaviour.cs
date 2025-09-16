using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class BallBehaviour : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Rigidbody body;
    [SerializeField]  AudioSource sound;
    [SerializeField] GameObject plane;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (lineRenderer.enabled && Input.GetMouseButtonDown(0))
        {
            Vector3 line = lineRenderer.GetPosition(1) - transform.position;
            Vector3 force = -line.normalized * (float)(5 * Math.Pow(line.magnitude, 3) + 10);
            body.AddForce(force);

            sound.Play();
        }

        plane.transform.position = body.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 2)
        {
            sound.Play();
        }
    }
}
