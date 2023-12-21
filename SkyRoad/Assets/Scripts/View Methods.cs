using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ViewMethods : View
{
    public virtual void SetParams()
    {
        return;
    }

    protected virtual void OnPointerEnterButtons(Button[] but)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((data) => GameMusic.Music.PlayButtonsMusic(true));
        
        foreach (var buttons in but)
        {
            buttons.AddComponent<EventTrigger>().GetComponent<EventTrigger>().triggers.Add(entry);
        }
    }
}
