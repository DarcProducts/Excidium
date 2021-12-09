using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager S;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject deathScreen;
    [SerializeField] GameObject playerPrefab;

    void Awake() => S = this;

    void Start() => HideGameOverScreen();

    public void HideDeathScreen() => deathScreen.SetActive(false);

    public void HideGameOverScreen() => gameOverScreen.SetActive(false); 

    public void ShowGameOverScreen() => gameOverScreen.SetActive(true); 

    public void SpawnNewPlayer(Vector2 newLocation)
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var p in players) Destroy(p);
        deathScreen.SetActive(false);
        GameObject newPlayer = Instantiate(playerPrefab, newLocation, Quaternion.identity);
        CameraFollow.S.SetTarget(newPlayer.transform);
    }
}
