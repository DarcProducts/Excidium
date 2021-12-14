using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidAcidSpawner : MonoBehaviour
{
    [SerializeField] ObjectPool acidPool;
    [SerializeField] float disableTime;
    [SerializeField] Vector2 spawnTime;
    [SerializeField] float accentRate;
    [SerializeField] Transform spawnArea;

    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        StopCoroutine(nameof(CreateBubbleOfAcid));
    }

    IEnumerator CreateBubbleOfAcid()
    {
        GameObject acid = acidPool.GetObject();

        yield return new WaitForSeconds(UnityEngine.Random.Range(Mathf.Min(spawnTime.x, spawnTime.y), Mathf.Max(spawnTime.x, spawnTime.y)));
        StartCoroutine(nameof(CreateBubbleOfAcid));
    }
}
