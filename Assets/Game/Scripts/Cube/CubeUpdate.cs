using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeUpdate : MonoBehaviour
{
    private CubeData _cubeData;

    private void Awake()
    {
        _cubeData = GetComponent<CubeData>();
    }

    public void CubeLevelUp(CubeNumber currentlevel)
    {
        int curLevelNumber = (int)currentlevel;

        if (curLevelNumber > (int)CubeNumber.OneTwentyEight)
        {
            _cubeData.ChangeCube((CubeNumber.OneTwentyEight));
            return;
        }
        _cubeData.ChangeCube((CubeNumber)curLevelNumber + curLevelNumber);
    }
}