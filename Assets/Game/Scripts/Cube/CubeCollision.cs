using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class CubeCollision : MonoBehaviour
{
    [SerializeField] private float minHitSpeed = 3f;
    private CubeData _cubeData;

    public static event Action<CubeNumber> OnCubeMerge;

    [Inject]
    private SFXManager _sFXManager;

    private void Awake()
    {
        _cubeData = GetComponent<CubeData>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<CubeCollision>(out CubeCollision cubeCollision))
        {
            if (GetComponent<Rigidbody>().velocity.magnitude > minHitSpeed && _cubeData.CubeType == collision.gameObject.GetComponent<CubeData>().CubeType)
            {
                collision.gameObject.GetComponent<CubeUpdate>().CubeLevelUp(_cubeData.CubeType);
                OnCubeMerge?.Invoke(_cubeData.CubeType);
                _sFXManager.PlayMergeSFX();
                _cubeData.ReturnCube();
            }
        }
    }

   
}
