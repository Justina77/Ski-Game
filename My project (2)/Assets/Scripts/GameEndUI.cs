using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.UI;

public class GameEndUI : MonoBehaviour
{

    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private Image crossfade;
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

    }

    public void NextLevel()
    {

    }

    public void QuitLevel()
    {

    }
}
