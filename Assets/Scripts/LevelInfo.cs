using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInfo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private TMP_Text _tmPro;
    void Start()
    {
        _tmPro = GetComponent(typeof(TMP_Text)) as TMP_Text;
        _tmPro.text = $"Level {SceneManager.GetActiveScene().buildIndex + 1}";
    }
}
