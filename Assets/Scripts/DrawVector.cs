using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class DrawVector : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Rigidbody body;

    [SerializeField] Camera camera;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if ((Time.timeScale != 0) && (body.linearVelocity.magnitude == 0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            lineRenderer.enabled = Physics.Raycast(ray, out hit, 1000, 1 << 3);

            if (lineRenderer.enabled) Draw(hit.point);
        }
        else lineRenderer.enabled = false;
    }

    private void Draw(Vector3 worldPoint)
    {
        Vector3 direction = worldPoint - transform.position;

        if (direction.magnitude > 5)
        {
            direction.Normalize();
            direction *= 5;
        }

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + direction);
    }
}
