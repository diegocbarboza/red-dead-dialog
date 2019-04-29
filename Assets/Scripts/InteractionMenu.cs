using System.Collections.Generic;
using UnityEngine;

namespace RedDeadInteraction
{
    public class InteractionMenu : MonoBehaviour
    {
        public Color itemDisabledColor = new Color(0.75f, 0.75f, 0.75f);

        [Header("Name Sub Panel")]
        [SerializeField] private GameObject targetNameSubPanel;
        [SerializeField] private InteractionOption tagetNameMenuItem;

        [Header("Name Sub Panel")]
        [SerializeField] private GameObject optionsSubPanel;
        [SerializeField] private InteractionOption optionPrefab;
        [SerializeField] private GameObject separator;

        [Header("Button Sprites")]
        [SerializeField] private Sprite crossSprite;
        [SerializeField] private Sprite circleSprite;
        [SerializeField] private Sprite squareSprite;
        [SerializeField] private Sprite triangleSprite;
        [SerializeField] private Sprite r1Sprite;
        [SerializeField] private Sprite r2Sprite;
        [SerializeField] private Sprite l1Sprite;
        [SerializeField] private Sprite l2Sprite;
        [SerializeField] private Sprite dPadUpSprite;
        [SerializeField] private Sprite dPadDownSprite;
        [SerializeField] private Sprite dPadLeftSprite;
        [SerializeField] private Sprite dPadRighSprite;

        private IInteractable currentInteractable;
        private Dictionary<ButtonType, InteractionOption> optionDictionary;

        private void Awake()
        {
            FindInstance();
            optionDictionary = new Dictionary<ButtonType, InteractionOption>();
        }
        private Sprite GetButtonSprite(ButtonType buttonType)
        {
            switch (buttonType)
            {
                case ButtonType.Cross:
                    return crossSprite;
                case ButtonType.Circle:
                    return circleSprite;
                case ButtonType.Square:
                    return squareSprite;
                case ButtonType.Triangle:
                    return triangleSprite;
                case ButtonType.R1:
                    return r1Sprite;
                case ButtonType.R2:
                    return r2Sprite;
                case ButtonType.L1:
                    return l1Sprite;
                case ButtonType.L2:
                    return l2Sprite;
                case ButtonType.DPadUp:
                    return dPadUpSprite;
                case ButtonType.DPadDown:
                    return dPadDownSprite;
                case ButtonType.DPadLeft:
                    return dPadLeftSprite;
                case ButtonType.DPadRight:
                    return dPadRighSprite;
                default:
                    return null;
            }
        }

        public void Engage(IInteractable interactable)
        {
            currentInteractable = interactable;
            tagetNameMenuItem.SetText(interactable.GetName());
            targetNameSubPanel.SetActive(true);
        }

        public void Disengage(IInteractable interactable)
        {
            if (currentInteractable == interactable)
            {
                targetNameSubPanel.SetActive(false);
                HideOptions();
                currentInteractable = null;
            }
        }

        public void ShowOptions(bool refresh = false)
        {
            if (refresh) HideOptions();

            if (currentInteractable != null && !optionsSubPanel.activeSelf)
            {
                separator.SetActive(true);
                optionsSubPanel.SetActive(true);
                optionDictionary.Clear();

                foreach (InteractionItem it in currentInteractable.GetInteractions())
                {
                    InteractionOption option = Instantiate(optionPrefab) as InteractionOption;
                    option.GetComponent<RectTransform>().SetParent(optionsSubPanel.transform);
                    option.GetComponent<RectTransform>().localScale = Vector3.one;
                    option.Config(it, GetButtonSprite(it.Button), it.Enabled ? Color.white : itemDisabledColor);                    
                    optionDictionary.Add(option.GetButton(), option);
                }
            }
        }

        public void HideOptions()
        {
            if (currentInteractable != null && optionsSubPanel.activeSelf)
            {
                for (int i = optionsSubPanel.transform.childCount - 1; i >= 0; i--)
                {
                    Destroy(optionsSubPanel.transform.GetChild(i).gameObject);
                }

                separator.SetActive(false);
                optionsSubPanel.SetActive(false);
            }
        }

        public void ProcessOption(ButtonType button)
        {
            if (currentInteractable != null)
            {
                if (optionDictionary.ContainsKey(button))
                {
                    InteractionOption option = optionDictionary[button];
                    if (option != null)
                    {
                        currentInteractable.GetTransform().SendMessage(option.GetMessage(), SendMessageOptions.DontRequireReceiver);
                        ShowOptions(true);
                    }
                }
            }
        }

        #region Static
        private static InteractionMenu instance = null;

        public static InteractionMenu Instance
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
            InteractionMenu[] interactionMenus = FindObjectsOfType<InteractionMenu>();
            Debug.Assert(interactionMenus.Length == 1, string.Format("There are {0} interaction menus in the scene. Please ensure there is always exactly one interaction menu in the scene.", interactionMenus.Length));
            if (interactionMenus.Length > 0) instance = interactionMenus[0];
        }
        #endregion
    }
}