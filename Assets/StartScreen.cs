using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public Button StartButton;
    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(ButtonClicked);
    }

    void ButtonClicked()
    {
        SceneManager.LoadScene("Scene_0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
