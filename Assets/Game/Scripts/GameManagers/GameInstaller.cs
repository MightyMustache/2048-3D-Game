using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private Transform _startLineTransform;
    [SerializeField] private Renderer _startLineRenderer;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _hud;
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private GameObject _scoreGO;
    [SerializeField] private GameObject _resultGO;



    public override void InstallBindings()
    {
        Container.Bind<CubeSpawner>()
        .FromComponentInHierarchy()
        .AsSingle();

        Container.Bind<CubePool>()
        .FromComponentInHierarchy()
        .AsSingle();

        Container.Bind<DataLoader>()
        .FromComponentInHierarchy()
        .AsSingle();

        Container.Bind<PauseManager>()
       .FromComponentInHierarchy()
       .AsSingle();

        Container.Bind<ScoreManager>()
       .FromComponentInHierarchy()
       .AsSingle();

        Container.Bind<MusicManager>()
        .FromComponentInHierarchy()
        .AsSingle();

        Container.Bind<SFXManager>()
        .FromComponentInHierarchy()
        .AsSingle();

        Container.Bind<GameObject>()
        .WithId("Cube")
        .FromInstance(_cube);

        Container.Bind<Transform>()
        .WithId("StartLineTransform")
        .FromInstance(_startLineTransform);

        Container.Bind<Renderer>()
        .WithId("StartLineRenderer")
        .FromInstance(_startLineRenderer);

        Container.Bind<GameObject>()
        .WithId("Menu")
        .FromInstance(_menu);

        Container.Bind<GameObject>()
        .WithId("HUD")
        .FromInstance(_hud);

        Container.Bind<GameObject>()
       .WithId("GameOverMenu")
       .FromInstance(_gameOverMenu);

        Container.Bind<GameObject>()
       .WithId("Result")
       .FromInstance(_resultGO);

        Container.Bind<GameObject>()
       .WithId("Score")
       .FromInstance(_scoreGO);
    }
}

