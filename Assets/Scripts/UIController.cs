using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UIの制御
/// </summary>
public class UIController : MonoBehaviour
{
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject scoreObject;
    [SerializeField] GameObject gameOverObject;

    public void VisibleTitle(bool visible)
    {
        this.startButton.SetActive(visible);
    }

    public void VisibleScore(bool visible)
    {
        this.scoreObject.SetActive(visible);
    }

    public void VisibleGameOver(bool visible)
    {
        this.gameOverObject.SetActive(visible);
    }
}
