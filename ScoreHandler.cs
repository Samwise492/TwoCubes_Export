using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] GameObject cubeNest;
    [SerializeField] Text scoreText;
    int scores;

    void Start()
    {
        StartCoroutine(CountScores());
    }
    IEnumerator CountScores()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            scores = cubeNest.transform.childCount * 200;
            scoreText.text = scores.ToString();
        }
    }
}
