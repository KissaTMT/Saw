using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject[] _enemies;
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
                Instantiate(_enemies[Random.Range(0,_enemies.Length)], _player.position + new Vector3(Random.Range(-20,20),Random.Range(-20,20)), Quaternion.identity);
            }
        }
    }
}
