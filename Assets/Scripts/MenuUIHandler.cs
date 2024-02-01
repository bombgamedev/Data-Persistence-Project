using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScore;
    [SerializeField] private TMP_InputField inputName;

    private void Start()
    {
        inputName.text = GlobalManager.Instance.bestPlayerName;
        bestScore.text = "Best Score : " + GlobalManager.Instance.bestPlayerName + " : " + GlobalManager.Instance.bestScore;
    }

    public void StartGame()
    {
        GlobalManager.Instance.playerName = inputName.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
