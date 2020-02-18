using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI text;

    private Bird _bird;
    private int _score;
    private int _lastScoreDebugged;

    private void Awake()
    {
        _bird = FindObjectOfType<Bird>();
    }

    private void Update()
    {
        _score = (int) _bird.transform.position.x / 4;

        if (_lastScoreDebugged != _score)
        {
            text.text = _score.ToString();
        }

        _lastScoreDebugged = _score;
    }
}