using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent<EventTrigger> OnTriggerEnterEvents;
    [SerializeField] UnityEvent<EventTrigger> OnTriggerExitEvents;

    void OnTriggerEnter2D(Collider2D other) => OnTriggerEnterEvents?.Invoke(this);

    void OnTriggerExit2D(Collider2D other) => OnTriggerExitEvents?.Invoke(this);
}