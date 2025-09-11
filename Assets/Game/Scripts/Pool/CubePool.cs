using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CubePool : GameObjectPool
{
    [Inject(Id = "Cube")]
    private GameObject _cube;

    [Inject]
    private DiContainer _diContainer;

    private void Awake()
    {
        Initialize(_cube);
    }

    protected override void OnCreated(GameObject obj)
    {
        _diContainer.Inject(obj.GetComponent<CubeData>());
        _diContainer.Inject(obj.GetComponent<CubeCollision>());
    }

    protected override void OnReturn(GameObject obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.rotation = Quaternion.identity;
        rb.transform.rotation = Quaternion.identity;
        rb.Sleep();
    }

}
