using Audio;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Menu
{
    public class ButtonSound : MonoBehaviour
    {
        private void Awake()
        {
            AddEventTrigger();
        }

        private void AddEventTrigger()
        {
            EventTrigger trigger = gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry entryPointerEnter = new EventTrigger.Entry();
            entryPointerEnter.eventID = EventTriggerType.PointerEnter;
            entryPointerEnter.callback.AddListener(_ => { OnPointerEnterDelegate(); });
            trigger.triggers.Add(entryPointerEnter);

            EventTrigger.Entry entryPointerClick = new EventTrigger.Entry();
            entryPointerClick.eventID = EventTriggerType.PointerClick;
            entryPointerClick.callback.AddListener(_ => { OnPointerClickDelegate(); });
            trigger.triggers.Add(entryPointerClick);            
        }

        public static void OnPointerEnterDelegate()
        {
            AudioManager.Instance.ButtonHover();
        }

        public static void OnPointerClickDelegate()
        {
            AudioManager.Instance.ButtonClick();
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}
