using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private Text _currentScoreTextOnPause;
    [SerializeField] private Text _recordScoreTextOnPause;

    [SerializeField] private Text _currentScoreText;

    private int _record;
    private int _currentScore = 0;

    private void Start()
    {
        _record = PlayerPrefs.HasKey("Record") ? PlayerPrefs.GetInt("Record") : 0;
        _recordScoreTextOnPause.text = _record.ToString();

        _currentScoreText.text = "0";
        _currentScoreTextOnPause.text = "0";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<FruitRandomSpawn>())
        {
            _currentScore++;
            _currentScoreText.text = _currentScore.ToString();
            _currentScoreTextOnPause.text = _currentScore.ToString();

            if (_currentScore > _record)
            {
                _record = _currentScore;
                _recordScoreTextOnPause.text = _record.ToString();
                PlayerPrefs.SetInt("Record", _record);
            }
        }
    }
}
