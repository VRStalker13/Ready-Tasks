using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public abstract class ViewMethods : View
{
    public virtual void SetParams()
    {
        return;
    }
    
    protected virtual void AddOnPointerEnter(Object[] obj, EventTriggerType id, UnityAction<BaseEventData> eventData)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = id;
        entry.callback.AddListener(eventData);
        
        foreach (var x in obj)
        {
            x.AddComponent<EventTrigger>().triggers.Add(entry);
        }
    }
}

