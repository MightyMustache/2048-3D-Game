using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    public Dictionary<CubeNumber, Material> CubeMaterials { get; private set; }
        = new Dictionary<CubeNumber, Material>();

    public AudioClip[] Music { get; private set; }
    public AudioClip[] SFX { get; private set; }


    private void Awake()
    {
        LoadMaterials();
    }

    private void LoadMaterials()
    {
        CubeMaterials.Clear();

        Music = Resources.LoadAll<AudioClip>("Music");

        SFX = Resources.LoadAll<AudioClip>("SFX");


        Material[] materials = Resources.LoadAll<Material>("CubeMaterials");

        foreach (var material in materials)
        {
            if (int.TryParse(material.name, out int number))
            {
                if (System.Enum.IsDefined(typeof(CubeNumber), number))
                {
                    CubeNumber cubeNumber = (CubeNumber)number;
                    CubeMaterials[cubeNumber] = material;
                }
                else
                {
                    Debug.LogWarning($"Material {material.name} != enum CubeNumber!");
                }
            }
            else
            {
                Debug.LogWarning($"Material name {material.name} is not digit!");
            }
        }
    }
}
