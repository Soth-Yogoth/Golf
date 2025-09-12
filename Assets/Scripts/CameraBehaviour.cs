using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraBehaviour : MonoBehaviour
{

    public Transform target;

    private Vector3 mousePos;

    private Vector3 direction = new Vector3(0, 1, 1);
    private float distance = 10;
    private double angleX = 0;
    private double angleY = 0;

    void Start()
    {
        mousePos = Input.mousePosition;
    }

    void Update()
    {
        transform.position = target.position + distance * direction;
        transform.LookAt(target);

        if (Input.GetMouseButton(2))
        {
            if (Input.mousePosition.x < mousePos.x)
            {
                angleX -= Math.PI / 2;
            }
            else if (Input.mousePosition.x > mousePos.x)
            {
                angleX += Math.PI / 2;
            }

            if (Input.mousePosition.y < mousePos.y)
            {
                angleY -= Math.PI / 2;
            }
            else if (Input.mousePosition.y > mousePos.y)
            {
                angleY += Math.PI / 2;
            }

            Rotate((float)angleX, (float)angleY);

            angleX = 0;
            angleY = 0;
        }

        mousePos = Input.mousePosition;

        Zoom(-Input.mouseScrollDelta.y);
    }

    private void Rotate(float angleX, float angleY)
    {
        transform.RotateAround(target.position, Vector3.up, angleX);

        if ((angleY < 0 && (transform.eulerAngles.x < 60 || transform.eulerAngles.x > 180))
            || (angleY > 0 && (transform.eulerAngles.x > 320 || transform.eulerAngles.x < 180)))
        {
            transform.RotateAround(target.position, transform.right, -angleY);
        }

        direction = -(target.position - transform.position) / distance;
    }

    private void Zoom(float scrollDelta)
    {
        if ((distance > 5 && scrollDelta < 0) || (scrollDelta > 0 && distance < 20))
        {
            distance += scrollDelta;
        }
    }
}
