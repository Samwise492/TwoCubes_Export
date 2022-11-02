using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameReloading : MonoBehaviour
{
    [SerializeField] Text defeatText, winText;
    CollideDetection[] collideDetection;
    public int winCounter;

    void Start()
    {
        collideDetection = FindObjectsOfType<CollideDetection>();
        StartCoroutine(CheckForGameState());
    }

    IEnumerator CheckForGameState()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();

            foreach (var collideElement in collideDetection)
            {
                if (collideElement.gameEnd)
                {
                    StartCoroutine(ReloadGame(defeatText.gameObject));
                }
            }
            
            if (collideDetection.All(x => x.isTouchedFinish == true))
            {
                winCounter = 2;
                StartCoroutine(ReloadGame(winText.gameObject));
            }
            else if (collideDetection.Any(x => x.isTouchedFinish == true))
            {
                winCounter = 1;
            }
        }
    }
    IEnumerator ReloadGame(GameObject gameResult)
    {
        gameResult.SetActive(true);

        yield return new WaitForSeconds(1);
        
        gameResult.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 

        yield break;
    }
}
