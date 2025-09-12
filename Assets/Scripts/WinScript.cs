using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    [SerializeField] GameObject panel;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ball")
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
