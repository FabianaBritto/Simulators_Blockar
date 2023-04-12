using UnityEngine;
using UnityEngine.EventSystems;

namespace Menu
{
    public class ButtonTooltip : MonoBehaviour
    {
        [SerializeField] private GameObject tooltip;

        private void Awake()
        {
            EventTrigger trigger = gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry entryPointerEnter = new EventTrigger.Entry();
            entryPointerEnter.eventID = EventTriggerType.PointerEnter;
            entryPointerEnter.callback.AddListener(_ => { OnPointerEnterDelegate(); });
            trigger.triggers.Add(entryPointerEnter);

            EventTrigger.Entry entryPointerClick = new EventTrigger.Entry();
            entryPointerClick.eventID = EventTriggerType.PointerExit;
            entryPointerClick.callback.AddListener(_ => { OnPointerExitDelegate(); });
            trigger.triggers.Add(entryPointerClick);
        }

        private void Start()
        {
            tooltip.SetActive(false);
        }

        private void OnPointerEnterDelegate()
        {
            tooltip.SetActive(true);
        }

        private void OnPointerExitDelegate()
        {
            tooltip.SetActive(false);
        }
    }
}
