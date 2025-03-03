using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    private void Awake()
    {
        StartCoroutine(SpawnRoutine());
    }
    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2, 5));

            var countEnemies = Random.Range(2, 5);
            for (var i = 0; i < countEnemies; i++)
            {
                Instantiate(_enemy, new Vector2(Random.Range(-20,20),Random.Range(-40,40)), Quaternion.identity);
            }
        }
    }
}
