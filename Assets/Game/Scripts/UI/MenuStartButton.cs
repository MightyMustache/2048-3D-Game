using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject; 

public class MenuStartButton : MonoBehaviour
{

    [Inject(Id = "HUD")]
    private GameObject _HUD;

    [Inject(Id = "Menu")]
    private GameObject _menu;

    [Inject]
    private PauseManager _pauseManager;

    [Inject]
    private MusicManager _musicManager;

    public void GameStart()
    {
        _menu.SetActive(false);
        _pauseManager.PauseGame(false);
        _HUD.SetActive(true);
        _musicManager.PlayBackGroudMusic();
    }

}
