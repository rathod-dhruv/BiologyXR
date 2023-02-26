using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    public GameObject[] prefabs;

    public void ActivateIndex(int idx)
    {
        foreach (GameObject g in prefabs)
            g.SetActive(false);

        prefabs[idx].SetActive(true);
    }
}
