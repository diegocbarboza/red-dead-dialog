using UnityEngine;
using UnityEngine.UI;

namespace RedDeadInteraction
{
    public class InteractionOption : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Text text;

        private InteractionItem interaction;

        public void Config(InteractionItem interaction, Sprite sprite, Color color)
        {
            this.interaction = interaction;
            image.sprite = sprite;
            image.color = color;
            text.color = color;
            text.text = interaction.Text;
        }

        public void SetText(string value)
        {
            text.text = value;
        }

        public ButtonType GetButton()
        {
            return interaction.Button;
        }

        public string GetMessage()
        {
            return interaction.Message;
        }
    }
}