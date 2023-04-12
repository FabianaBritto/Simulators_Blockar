using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class LevelListRenameButtons : MonoBehaviour
    {
        [SerializeField] private Text[] buttonLabels; 
        
        private void Start()
        {
            int i = 0;
            foreach (var label in buttonLabels)
            {
                i++;
                label.text = i <= 9 ?  $"#0{i}" : $"#{i}";
            }
        }
    }
}
