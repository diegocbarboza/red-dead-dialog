namespace RedDeadInteraction
{
    public class InteractionItem
    {
        public InteractionItem(string text, ButtonType button, string message, bool enabled)
        {
            Text = text;
            Button = button;
            Message = message;
            Enabled = enabled;
        }

        public string Text { get; private set; }

        public ButtonType Button { get; private set; }

        public string Message { get; private set; }

        public bool Enabled { get; private set; }
    }
}