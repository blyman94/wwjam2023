using System.Threading.Tasks;
using UnityEngine;

public class EventSequencer : MonoBehaviour
{
    public GameEvent[] events;
    public int[] timeBetweenEvents;

    public async void StartSequence()
    {
        for (int i = 0; i < events.Length; i++)
        {
            await RunEventAfterTime(events[i], timeBetweenEvents[i]);
        }
    }

    public async Task RunEventAfterTime(GameEvent gameEvent, float time)
    {
        await Task.Delay(Mathf.RoundToInt(time * 1000));
        gameEvent.Raise();
    }
}
