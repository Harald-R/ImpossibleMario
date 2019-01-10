using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefab;

    void Spawn()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }

    void SetPrefab(GameObject newPrefab)
    {
        prefab = newPrefab;
    }

}
