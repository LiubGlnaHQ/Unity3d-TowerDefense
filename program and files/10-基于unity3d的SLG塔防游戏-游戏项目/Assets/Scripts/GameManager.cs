using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameEndUI gameEndUI;

    private void Awake()
    {
        Instance = this;
    }
    

    public void Fail()
    {
        EnemySpawner.Instance.StopSpawn();
        gameEndUI.Show("GAME OVER");
    }
    public void Win()
    {
        gameEndUI.Show("WIN");
    }

    public void OnRestart()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex ) ;
    }
    public void OnMenu()
    {
        SceneManager.LoadScene(0);
    }
}
