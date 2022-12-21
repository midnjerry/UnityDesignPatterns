using System.Collections.Generic;
using UnityEngine.Events;

public class RaceEventBus
{
    /*
     * Create a map of UnityEvent instances that keep track of listeners.
     * When event is published, all registered callback functions are invoked.
     */
    private static readonly IDictionary<RaceEventType, UnityEvent> s_events = new Dictionary<RaceEventType, UnityEvent>();

    public static void Subscribe(RaceEventType eventType, UnityAction listener)
    {
        UnityEvent unityEvent;

        if (s_events.TryGetValue(eventType, out unityEvent))
        {
            unityEvent.AddListener(listener);
        } else
        {
            unityEvent = new UnityEvent();
            unityEvent.AddListener(listener);
            s_events.Add(eventType, unityEvent);
        }        
    }

    public static void Unsubscribe(RaceEventType eventType, UnityAction listener)
    {
        UnityEvent unityEvent;

        if (s_events.TryGetValue(eventType, out unityEvent))
        {
            unityEvent.RemoveListener(listener);
        }
    }

    public static void Publish(RaceEventType eventType)
    {
        UnityEvent unityEvent;
        if (s_events.TryGetValue(eventType, out unityEvent)) {
            unityEvent.Invoke();
        }
    }
}
