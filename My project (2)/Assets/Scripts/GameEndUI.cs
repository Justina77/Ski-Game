using DG.Tweening.Core.Easing;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndUI : MonoBehaviour
{

    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private Image crossfade;
    [SerializeField] private int nextLevelIndex;

    void Start()
    {
        gameOverMenu.SetActive(false);
        crossfade.CrossFadeAlpha(0, 1f, true);
    }

    private void OnEnable()
    {
        GameEvents.raceEnd += EnableGameOver;
        GameEvents.Quit += Quit;
    }

    private void OnDisable()
    {
        GameEvents.raceEnd -= EnableGameOver;
        GameEvents.Quit -= Quit;
    }

    private void EnableGameOver()
    {
        gameOverMenu.SetActive(true);
    }

    public void RestartLevel()
    {
        StartCoroutine(RestartCoroutine());
    }

    private IEnumerator RestartCoroutine()
    {
        crossfade.CrossFadeAlpha(1, 1f, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        StartCoroutine(NextLevelCoroutine());
    }

    private IEnumerator NextLevelCoroutine()
    {
        crossfade.CrossFadeAlpha(1, 1f, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextLevelIndex);
    }

    private void Quit()
    {
        StartCoroutine(QuitCoroutine());
    }

    private IEnumerator QuitCoroutine()
    {
        crossfade.CrossFadeAlpha(1, 1f, true);
        yield return new WaitForSeconds(1);
        Application.Quit();
    }

    public void QuitButtom()
    {
        GameEvents.CallQuit();
    }

}
