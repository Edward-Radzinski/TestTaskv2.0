using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player _player;

    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _restart;
    [SerializeField] private GameObject _resume;

    public bool pause;

    private void Start()
    {
        Time.timeScale = 1f;
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (!_player)
        {
            OnApplicationPause(true);
            _restart.SetActive(true);
            _resume.SetActive(false);
        }
        if(pause)
        {
            OnApplicationPause(true);
        }
    }

    public void OnApplicationPause(bool pause)
    {
        Time.timeScale = pause ? 0f : 1f;
        _pausePanel.SetActive(pause);
    }
}
