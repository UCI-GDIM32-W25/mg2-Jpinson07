using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;

    [SerializeField] private float minTime = 0.5f;
    [SerializeField] private float maxTime = 2f;

    [SerializeField] private float spawnX = 12f;
    [SerializeField] private float spawnY = 14f;   

    private void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);

            Vector3 spawnPos = new Vector3(spawnX, spawnY, 0f);
            Instantiate(coinPrefab, spawnPos, Quaternion.identity);
        }
    }
}
