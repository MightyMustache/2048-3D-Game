using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseManager : MonoBehaviour
{

    public static event Action<bool> OnPause;

    public void PauseGame(bool pauseState)
    {
        OnPause?.Invoke(pauseState);
    }

    private void OnDisable()
    {
        OnPause = null;
    }

}
