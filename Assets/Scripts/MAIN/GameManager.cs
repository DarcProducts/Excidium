using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager S;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject deathScreen;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GlobalVector2 spawnLocation;
    [SerializeField] GameObject menuScreen;
    [SerializeField] TMPro.TMP_Text menuText;
    [SerializeField] string gameSceneName;
    [SerializeField] Area[] areasToReset;
    [SerializeField] Dialog[] dialogsToReset;
    [SerializeField] bool valueToSet;
    bool spawningPlayer = false;

    void Awake() => S = this;

    void Start() => HideGameOverScreen();

    public void ShowDeathScreen() => deathScreen.SetActive(true);

    public void HideDeathScreen() => deathScreen.SetActive(false);

    public void HideGameOverScreen() => gameOverScreen.SetActive(false); 

    public void ShowGameOverScreen() => gameOverScreen.SetActive(true);

    public void Menu()
    {
        if (menuScreen.activeSelf)
        {
            CloseMenu();
            return;
        }
        menuScreen.SetActive(true);
        menuText.enabled = false;
    }

    public void CloseMenu()
    {
        menuText.enabled = true;
        menuScreen.SetActive(false);
    }

    public void SpawnPlayer(float spawnDelay)
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var p in players) Destroy(p);
        CameraFollow.S.NullTarget();
        if (!spawningPlayer)
        {
            spawningPlayer = true;
            Invoke(nameof(SpawnNewPlayer), spawnDelay);
        }
    }

    void ResetGameTexts()
    {
        foreach (var v in areasToReset)
            v.hasBeenSeen = valueToSet;
        foreach (var v in dialogsToReset)
            v.hasBeenRead = valueToSet;
    }

    void SpawnNewPlayer()
    {
        deathScreen.SetActive(false);
        GameObject newPlayer = Instantiate(playerPrefab, spawnLocation.Value, Quaternion.identity);
        CameraFollow.S.SetTarget(newPlayer.transform);
        spawningPlayer = false;
    }

    public void RestartGame()
    {
        ResetGameTexts();
        SceneManager.LoadScene(gameSceneName);
    }

    public void ExitGame() => Application.Quit();
}
