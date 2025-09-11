using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;

public class CubeData : MonoBehaviour
{
    public CubeNumber CubeType { get; private set; }

    private CubePool _cubePool;
    private DataLoader _dataLoader;
    private Renderer _cubeRenderer;

    private List<TextMeshPro> _cubeNumbers = new List<TextMeshPro>();

    [Inject]
    public void Constract(CubePool cubepool, DataLoader dataloader)
    {
        _cubePool = cubepool;
        _dataLoader = dataloader;
    }

    private void Awake()
    {
        _cubeNumbers.Clear();
        _cubeNumbers.AddRange(GetComponentsInChildren<TextMeshPro>());
        _cubeRenderer = GetComponent<Renderer>();
    }

    public void ChangeCube(CubeNumber numberToChange)
    {
        CubeType = numberToChange;

        foreach (var text in _cubeNumbers)
        {
            text.text = ((int)numberToChange).ToString();
        }

        _cubeRenderer.material = _dataLoader.CubeMaterials[numberToChange];
    }

    public void ReturnCube()
    {
        _cubePool.ReturnToPool(gameObject);
    }
}

