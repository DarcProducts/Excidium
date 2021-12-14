using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject deathPanel;
    [SerializeField] GameObject demoOverPanel;

    void OnEnable()
    {
        PlayerHealth.OnDied += ShowDeathPanel;
        PlayerHealth.OnStart += HideDeathPanel;
    }

    void OnDisable()
    {
        PlayerHealth.OnDied -= ShowDeathPanel;
        PlayerHealth.OnStart -= HideDeathPanel;
    }

    public void ShowDeathPanel() => deathPanel.SetActive(true);
    public void HideDeathPanel() => deathPanel.SetActive(false);

    public void ShowDemoOverPanel() => demoOverPanel.SetActive(true);
    public void HideDemoOverPanel() => demoOverPanel.SetActive(false);
}
