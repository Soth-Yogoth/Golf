using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawVector : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Rigidbody body;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (body.linearVelocity.magnitude < 0.01f && Time.timeScale != 0) 
        {
            Vector3 intersectionPoint = Raycast();
            Draw(intersectionPoint);
        }
        else
        {
            Draw(transform.position);
        }
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

    private Vector3 Raycast()
    {
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);

        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);

        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);

        RaycastHit hit;

        if (Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit, 1000))
        {
            Vector3 intersection = hit.point;
            intersection.y = transform.position.y;

            return intersection;
        }
        else return transform.position;
    }
}
