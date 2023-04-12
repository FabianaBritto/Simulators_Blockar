using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Menu
{
    public class ButtonHighlight : MonoBehaviour
    {
        private Image buttonImage;
        private readonly Color buttonDefaultColor = new (0f, 0f, 0f, 230f);
        private readonly Color buttonHighlighterColor = new (42f / 255f, 157 / 255f, 143 / 255f);

        private void Awake()
        {
            buttonImage = gameObject.GetComponent<Image>();
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
            buttonImage.color = buttonDefaultColor;
        }

        private void OnPointerEnterDelegate()
        {
            buttonImage.color = buttonHighlighterColor;
        }

        private void OnPointerExitDelegate()
        {
            buttonImage.color = buttonDefaultColor;
        }
    }
}
