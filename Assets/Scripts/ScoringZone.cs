using UnityEngine;
using UnityEngine.EventSystems;

public class ScoringZone : MonoBehaviour
{
    public EventTrigger.TriggerEvent ScoreTrigger;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            ScoreTrigger.Invoke(eventData);
        }
    }
}
