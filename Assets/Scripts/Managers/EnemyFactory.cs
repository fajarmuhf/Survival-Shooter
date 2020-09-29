using System;
using UnityEngine;

public class EnemyFactory : MonoBehaviour, IFactory
{

    [SerializeField]
    public GameObject[] enemyPrefab;

    public GameObject FactoryMethod(int tag,Transform trs)
    {
        GameObject enemy = Instantiate(enemyPrefab[tag],trs.position,trs.rotation);
        return enemy;
    }
}