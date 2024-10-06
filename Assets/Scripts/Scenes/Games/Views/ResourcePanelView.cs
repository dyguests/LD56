using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Games.Views
{
    public class ResourcePanelView : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text text;

        public void SetText(string text)
        {
            this.text.text = text;
        }
    }
}