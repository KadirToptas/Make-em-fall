using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Game_Manager : MonoBehaviour
{
    public int _score = 0;
    [SerializeField] private TMP_Text _scoreText;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        _scoreText.text = _score.ToString();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
