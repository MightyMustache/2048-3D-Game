using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameObjectPool : MonoBehaviour
{
    [SerializeField] private int initialSize;

    private readonly Queue<GameObject> _objects = new Queue<GameObject>();
    private GameObject _prefab; 

    public void Initialize(GameObject prefab)
    {
        _prefab = prefab;

        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = CreateObject();
            obj.gameObject.SetActive(false);
            _objects.Enqueue(obj);
        }
    }

    public virtual GameObject Get()
    {
        if (_objects.Count == 0)
            return CreateObject();

        GameObject obj = _objects.Dequeue();
        obj.gameObject.SetActive(true);
        OnGet(obj);
        return obj;
    }

    public virtual void ReturnToPool(GameObject obj)
    {
        obj.gameObject.SetActive(false);
        obj.gameObject.transform.position = transform.position;
        _objects.Enqueue(obj);
        OnReturn(obj);
    }

    protected virtual GameObject CreateObject()
    {
        if (_prefab == null)
        {
            Debug.LogError("Pool prefab is not set");
            return null;
        }

        GameObject obj = Instantiate(_prefab, transform);
        OnCreated(obj);
        return obj;
    }

    protected virtual void OnCreated(GameObject obj) { }
    protected virtual void OnGet(GameObject obj) { }
    protected virtual void OnReturn(GameObject obj) { }
}