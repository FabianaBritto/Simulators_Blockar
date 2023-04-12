using UnityEngine;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private GameObject[] visualEffects;

    private void Start()
    {
        HiddenAllVisualEffects();
        ShowVisualEffect(0);

        AddClickListenerOnButtons();
        DefineLabelsOnButtons();
    }

    private void AddClickListenerOnButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            var visualEffectIndex = i;
            buttons[i].onClick.AddListener(() =>
            {
                HiddenAllVisualEffects();
                ShowVisualEffect(visualEffectIndex);
            });
        }
    }

    private void DefineLabelsOnButtons()
    {
        for (int i = 0; i < visualEffects.Length; i++)
        {
            string buttonLabel = visualEffects[i].name;
            buttons[i].GetComponentInChildren<Text>().text = buttonLabel;
        }
    }

    private void ShowVisualEffect(int index)
    {
        visualEffects[index].SetActive(true);
    }

    private void HiddenAllVisualEffects()
    {
        foreach (var effect in visualEffects)
            effect.SetActive(false);
    }
}
