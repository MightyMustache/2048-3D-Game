using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CubeSpawner : MonoBehaviour
{

    [Inject(Id = "StartLineTransform")]
    private Transform _startLineTransform;

    [Range(0f, 100f)]
    [SerializeField] private float chanceForCubeTypeTwo = 75f;
    [SerializeField] private int spawnCubePrice = -20;


    private CubePool _cubePool;
    private ScoreManager _scoreManager;
    private float _spawnPosYOffset = 0.75f;


    [Inject]
    public void Constract(CubePool cubePool, ScoreManager scoreManager)
    {
        _cubePool = cubePool;
        _scoreManager = scoreManager;
    }

    private CubeNumber GetCubeSpawnType()
    {
        float random = Random.Range(0f, 100f);
        if (random < chanceForCubeTypeTwo)
            return CubeNumber.Two;
        else
            return CubeNumber.Four;
    }

    public GameObject SpawnCube()
    {
        GameObject cubeToSpawn = _cubePool.Get();
        cubeToSpawn.transform.position = new Vector3(_startLineTransform.position.x, _startLineTransform.position.y + _spawnPosYOffset, _startLineTransform.position.z);
        cubeToSpawn.GetComponent<CubeData>().ChangeCube(GetCubeSpawnType());
        _scoreManager.ChangeScore(spawnCubePrice);
        return cubeToSpawn;
    }
}
