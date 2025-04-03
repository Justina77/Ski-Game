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
        gameObject.SetActive(false);
        crossfade.CrossFadeAlpha(0, 1f, true);
    }

    private void OnEnable()
    {
        GameEvents.raceEnd += EnableGameOver;
    }

    private void OnDisable()
    {
        GameEvents.raceEnd -= EnableGameOver;
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
        crossfade.CrossFadeAlpha(0, 1f, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        StartCoroutine(NextLevelCoroutine());
    }

    private IEnumerator NextLevelCoroutine()
    {
        crossfade.CrossFadeAlpha(0, 1f, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextLevelIndex);
    }

    public void QuitLevel()
    {

    }
}
