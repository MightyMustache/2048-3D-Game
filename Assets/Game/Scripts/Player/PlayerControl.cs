using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _throwForce = 5f;
    [SerializeField] private float _cubeSensitivity = 0.01f;

    private float _clampPosXOffset = 0.75f;
    private CubeSpawner _cubeSpawner;
    private GameObject _currentCube;
    private Vector2 _startPointerPosition;
    private bool _pause;
    private SFXManager _sFXManager;

    [Inject(Id = "StartLineRenderer")]
    private Renderer _startLineRender;

    [Inject]
    public void Constract(CubeSpawner cubeSpawner, SFXManager sFXManager)
    {
        _cubeSpawner = cubeSpawner;
        _sFXManager = sFXManager;
    }

    private void OnEnable()
    {
        _pause = true;
        PlayerInputHandler.OnTouchInput += HandlePointer;
        PauseManager.OnPause += GamePause;
    }

    private void OnDisable()
    {
        PlayerInputHandler.OnTouchInput -= HandlePointer;
        PauseManager.OnPause -= GamePause;
    }

    public void GamePause(bool pauseState)
    {
        _pause = pauseState;
    }

    private void HandlePointer(Vector2 pointerPos)
    {
        if (!_pause)
        {
            if (pointerPos == Vector2.zero)
            {
                ThrowCube();
                return;
            }
            if (_currentCube == null)
            {
                _startPointerPosition = pointerPos;
                CreateCube();
            }
            else if (_startPointerPosition != pointerPos)
            {
                MoveCube(pointerPos);
            }
        }

    }

    private void ThrowCube()
    {
        if (_currentCube == null) return;

        Rigidbody rb = _currentCube.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * _throwForce, ForceMode.Impulse);
        _currentCube = null;
        _sFXManager.PlayThrowSFX();
    }

    private void CreateCube()
    {
        _currentCube = _cubeSpawner.SpawnCube();

    }

    private void MoveCube(Vector2 pointerPos)
    {
       

            Vector2 delta = pointerPos - _startPointerPosition;
            _startPointerPosition = pointerPos;

            Vector3 curPos = _currentCube.transform.position;
            float clampedX = Mathf.Clamp(
                curPos.x + delta.x * _cubeSensitivity,

                _startLineRender.bounds.min.x + _clampPosXOffset,
                _startLineRender.bounds.max.x - _clampPosXOffset
            );

            _currentCube.transform.position = new Vector3(clampedX, curPos.y, curPos.z);
    }
}
