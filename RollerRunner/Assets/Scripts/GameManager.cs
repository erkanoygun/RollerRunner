using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerGameObject;
    [SerializeField] private GameObject _winnerPanel;
    [SerializeField] private GameObject _gameOwerPanel;
    private Player _playerScript;
    void Start()
    {
        _playerScript = _playerGameObject.GetComponent<Player>();
    }

    
    void Update()
    {
        if (_playerScript.isFinish)
        {
            _winnerPanel.gameObject.SetActive(true);
            StartCoroutine(GameStop());
        }
        else if (_playerScript.isGameOver)
        {
            _gameOwerPanel.gameObject.SetActive(true);
            StartCoroutine(GameStop());
        }
        
    }

    IEnumerator GameStop()
    {
        yield return new WaitForSeconds(0.01f);
        Time.timeScale = 0;
    }

    public void NextGameButton()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void RestartGameButton()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
