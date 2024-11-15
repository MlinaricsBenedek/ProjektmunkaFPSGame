using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject spawnPointGm;
    private void Awake()
    {
        spawnPointGm.SetActive(false);
    }
}
