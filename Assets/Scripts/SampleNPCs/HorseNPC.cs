using System.Collections.Generic;
using UnityEngine;

namespace RedDeadInteraction.SampleNPCs
{
    public class HorseNPC : MonoBehaviour, IInteractable
    {
        [SerializeField] private string horseName;
        
        #region IInteractable implementation
        public string GetName()
        {
            return horseName;
        }

        public List<InteractionItem> GetInteractions()
        {
            List<InteractionItem> interactions = new List<InteractionItem>();

            interactions.Add(new InteractionItem("Flee", ButtonType.Circle, "Flee", true));
            interactions.Add(new InteractionItem("Pat", ButtonType.Square, "Pat", true));
            interactions.Add(new InteractionItem("Lead", ButtonType.Triangle, "Lead", true));
            interactions.Add(new InteractionItem("Feed", ButtonType.DPadRight, "Feed", true));
            interactions.Add(new InteractionItem("Brush", ButtonType.DPadLeft, "Brush", true));
            interactions.Add(new InteractionItem("Remove Sadle", ButtonType.DPadUp, "RemoveSadle", true));
            interactions.Add(new InteractionItem("Show Info", ButtonType.R1, "ShowInfo", true));

            return interactions;
        }

        public Transform GetTransform()
        {
            return transform;
        }
        #endregion

        public void Flee()
        {
            DialogPanel.Instance.ShowText("Run for your life!");
        }

        public void Pat()
        {
            DialogPanel.Instance.ShowText("Good girl!");
        }

        public void Lead()
        {
            DialogPanel.Instance.ShowText("Follow me.");
        }

        public void Feed()
        {
            DialogPanel.Instance.ShowText("Here, eat this.");
        }

        public void Brush()
        {
            DialogPanel.Instance.ShowText("Let me brush you.");
        }

        public void RemoveSadle()
        {
            DialogPanel.Instance.ShowText("REMOVE SADLE");
        }

        public void ShowInfo()
        {
            DialogPanel.Instance.ShowText("SHOW INFO");
        }
    }
}