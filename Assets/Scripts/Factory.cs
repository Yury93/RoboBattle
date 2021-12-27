using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform pointToSpawn;
    [SerializeField] private Transform positionParent;
    [SerializeField] private T prefab;
    [SerializeField] private int lenght;
    [SerializeField] private int width;

    public T GetNewInstance()
    {
        Vector3 pos = new Vector3(pointToSpawn.position.x + (Random.Range(-10f, width)), pointToSpawn.position.y,
            pointToSpawn.position.z + (Random.Range(20, lenght)));

        return Instantiate(prefab, pos, Quaternion.identity, positionParent);
    }
}
