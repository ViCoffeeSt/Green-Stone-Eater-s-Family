using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] _gemPrefabs;
    [SerializeField] private int _initialGemCount;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _gemSpawnHeightOffset;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private int _maxActiveGems;

    private Transform _player;
    private List<GameObject> _activeGems = new List<GameObject>();

    private void Start()
    {
        _player = transform;

        StartCoroutine(SpawnGemsWithInterval());
    }

    private IEnumerator SpawnGemsWithInterval()
    {
        for (int i = 0; i < _initialGemCount; i++)
        {
            SpawnGem();
        }

        while (true)
        {
            yield return new WaitForSeconds(_spawnInterval);

            if (_activeGems.Count < _maxActiveGems)
            {
                SpawnGem();
            }
        }
    }

    private void SpawnGem()
    {
        Vector3 randomPosition = Random.insideUnitSphere * _spawnRadius + _player.position;

        RaycastHit hit;

        if (Physics.Raycast(randomPosition, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            randomPosition = hit.point + Vector3.up * _gemSpawnHeightOffset;
        }

        GameObject randomGemPrefab = _gemPrefabs[Random.Range(0, _gemPrefabs.Length)];

        GameObject gem = Instantiate(randomGemPrefab, randomPosition, Quaternion.identity);
        _activeGems.Add(gem);


        while (_activeGems.Count > _maxActiveGems)
        {
            GameObject oldestGem = _activeGems[0];
            _activeGems.RemoveAt(0);
            Destroy(oldestGem);
        }
    }
}
