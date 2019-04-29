using UnityEngine;
using UnityEngine.UI;

namespace RedDeadInteraction
{
    public class DialogPanel : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private Image image;

        private void Awake()
        {
            FindInstance();
        }

        public void ShowText(string value)
        {
            text.text = value;
            image.gameObject.SetActive(true);
            CancelInvoke("Hide");
            Invoke("Hide", 2.0f);
        }

        private void Hide()
        {
            image.gameObject.SetActive(false);
        }

        #region Static
        private static DialogPanel instance;

        public static DialogPanel Instance
        {
            get
            {
                if (instance == null)
                {
                    FindInstance();
                }
                return instance;
            }
        }

        private static void FindInstance()
        {
            DialogPanel[] dialogPanels = FindObjectsOfType<DialogPanel>();
            Debug.Assert(dialogPanels.Length == 1, string.Format("There are {0} dialog panels in the scene. Please ensure there is always exactly one dialog panel in the scene.", dialogPanels.Length));
            if (dialogPanels.Length > 0) instance = dialogPanels[0];
        }
        #endregion
    }
}