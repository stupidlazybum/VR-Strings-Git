using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverManager : MonoBehaviour {

    private ShowPanels sPanel;

    void Awake()
    {
        sPanel = GetComponent<ShowPanels>();
    }

    public void Gameover()
    {
        Debug.LogError("Game over man, game over");
        sPanel.ShowGameoverPanel();
        //Time.timeScale = 0;
    }

    public void UnGameover()
    {
        sPanel.HideGameoverPanel();
        //Time.timeScale = 1;
    }
}
