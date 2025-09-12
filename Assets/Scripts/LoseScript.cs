using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour
{
    public GameObject panel;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
