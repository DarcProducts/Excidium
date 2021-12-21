using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AreaEnteredController : MonoBehaviour
{
    public static AreaEnteredController S { get; private set; }
    [SerializeField] GameObject demoOverPanel;
    [SerializeField] bool disableAreaEnteredText = false;
    bool showAreaEntered;
    [SerializeField] TMP_Text areaEnteredText;
    [SerializeField] float areaTextDisplayTime;
    [SerializeField] Transform areaTextFinalLocation;
    [SerializeField] float areaTextMoveSpeed;
    Vector2 originalLocation;

    void Awake() => S = this;   

    void Start()
    {
        originalLocation = areaEnteredText.transform.localPosition;
    }

    private void FixedUpdate()
    {

        if (disableAreaEnteredText) return;
        Vector2 areaPos = areaEnteredText.transform.localPosition;
        if (showAreaEntered)
        {
            if (areaPos != (Vector2)areaTextFinalLocation.position)
                areaEnteredText.transform.localPosition = Vector2.MoveTowards(areaPos, areaTextFinalLocation.localPosition, areaTextMoveSpeed);
        }
        else if (!showAreaEntered)
        {
            if (areaPos != originalLocation)
                areaEnteredText.transform.localPosition = Vector2.MoveTowards(areaPos, originalLocation, areaTextMoveSpeed);
        }
    }

    public void ShowAreaEntered(string newArea)
    {
        areaEnteredText.text = newArea;
        showAreaEntered = true;
        Invoke(nameof(HideAreaEnteredText), areaTextDisplayTime);
    }

    void HideAreaEnteredText() => showAreaEntered = false;
    public void ShowDemoOverPanel() => demoOverPanel.SetActive(true);
    public void HideDemoOverPanel() => demoOverPanel.SetActive(false);
}
