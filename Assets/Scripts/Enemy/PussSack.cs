using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PussSack : MonoBehaviour
{
    [SerializeField] float duration;
    float currentDuration;
    SpriteRenderer sRend;
    [SerializeField] Sprite startSprite;
    [SerializeField] Sprite fillingSprite1;
    [SerializeField] Sprite fillingSprite2;
    [SerializeField] Sprite openSprite;
    [SerializeField] GameObject puss;
    [SerializeField] float pussForce;
    [SerializeField] Vector2 pussDirection;


    void Awake()
    {
        sRend = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        currentDuration = duration;
    }

    void FixedUpdate()
    {
        currentDuration = currentDuration < 0 ? 0 : currentDuration -= Time.fixedDeltaTime;

        if (currentDuration > duration / 1.5f)
            sRend.sprite = startSprite;
        else if ((currentDuration < duration / 1.5f && currentDuration > duration / 4))
            sRend.sprite = fillingSprite1;
        else if ((currentDuration < duration / 4 && currentDuration > duration / 6))
            sRend.sprite = fillingSprite2;
        else if (currentDuration < duration / 6)
            sRend.sprite = openSprite;

        if (currentDuration.Equals(0))
        {
            GameObject p = Instantiate(puss, transform.position, Quaternion.identity);
            Rigidbody2D pRB = p.GetComponent<Rigidbody2D>();
            if (pRB != null)
                pRB.AddForce(pussForce * pussDirection, ForceMode2D.Impulse);
            currentDuration = duration;
        }
    }
 }
