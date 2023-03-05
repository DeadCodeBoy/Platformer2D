using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryGenerator : MonoBehaviour
{
    [SerializeField] private Cherry _cherryTemplate;
    [SerializeField] private Transform[] _spawnPosition;

    private void Start()
    {
        StartCoroutine(CherrySpawn());
    }

    private IEnumerator CherrySpawn()
    {
        for (int i = 0; i < _spawnPosition.Length; i++)
        {
            var spawnPoint = Instantiate(_cherryTemplate, _spawnPosition[i].transform.position, Quaternion.identity);
            yield return null;
        }
    }
}
