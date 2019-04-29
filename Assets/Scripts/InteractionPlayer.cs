using UnityEngine;

namespace RedDeadInteraction
{
    public class InteractionPlayer : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetAxisRaw("L2") >= 0.5f)
            {
                InteractionMenu.Instance.ShowOptions();
            }
            else 
            {
                InteractionMenu.Instance.HideOptions();
            }

            if (Input.GetButtonDown("Cross"))
            {
                InteractionMenu.Instance.ProcessOption(ButtonType.Cross);
            }
            else if (Input.GetButtonDown("Circle"))
            {
                InteractionMenu.Instance.ProcessOption(ButtonType.Circle);
            }
            else if (Input.GetButtonDown("Square"))
            {
                InteractionMenu.Instance.ProcessOption(ButtonType.Square);
            }
            else if (Input.GetButtonDown("Triangle"))
            {
                InteractionMenu.Instance.ProcessOption(ButtonType.Triangle);
            }
            else if (Input.GetButtonDown("R1"))
            {
                InteractionMenu.Instance.ProcessOption(ButtonType.R1);
            }
            else if (Input.GetAxisRaw("R2") >= 0.5f)
            {
                InteractionMenu.Instance.ProcessOption(ButtonType.R2);
            }
            else if (Input.GetAxisRaw("DPadHorizontal") >= 0.5f)
            {
                InteractionMenu.Instance.ProcessOption(ButtonType.DPadRight);
            }
            else if (Input.GetAxisRaw("DPadHorizontal") <= -0.5f)
            {
                InteractionMenu.Instance.ProcessOption(ButtonType.DPadLeft);
            }
            else if (Input.GetAxisRaw("DPadVertical") >= 0.5f)
            {
                InteractionMenu.Instance.ProcessOption(ButtonType.DPadUp);
            }
            else if (Input.GetAxisRaw("DPadVertical") <= -0.5f)
            {
                InteractionMenu.Instance.ProcessOption(ButtonType.DPadDown);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Interactable"))
            {
                IInteractable target = other.GetComponent<IInteractable>();
                if (target != null)
                {
                    InteractionMenu.Instance.Engage(target);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Interactable"))
            {
                IInteractable target = other.GetComponent<IInteractable>();
                if (target != null)
                {
                    InteractionMenu.Instance.Disengage(target);
                }
            }
        }
    }
}