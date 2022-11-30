using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Text pauseText;

    public void Pause()
    {
        pauseText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void Play()
    {
        pauseText.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
