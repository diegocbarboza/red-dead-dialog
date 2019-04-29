using System.Collections.Generic;
using UnityEngine;

namespace RedDeadInteraction.SampleNPCs
{
    public class StandardNPC : MonoBehaviour, IInteractable
    {
        [SerializeField] private string characterName;
        [SerializeField] private bool canBeRobbed;
        [SerializeField] private bool canBeGreeted;
        [SerializeField] private bool canBeDefused;
        [SerializeField] private bool canBeAntagonized;
        [SerializeField] private bool canBeAimedAt;

        private bool isAngry = false;

        #region IInteractable implementation
        public string GetName()
        {
            return characterName;
        }

        public List<InteractionItem> GetInteractions()
        {
            List<InteractionItem> interactions = new List<InteractionItem>();

            interactions.Add(new InteractionItem("Antagonize", ButtonType.Circle, "Antagonize", canBeAntagonized));
            if (!isAngry) interactions.Add(new InteractionItem("Greet", ButtonType.Square, "Greet", canBeGreeted));
            if (isAngry) interactions.Add(new InteractionItem("Defuse", ButtonType.Square, "Defuse", canBeDefused));
            interactions.Add(new InteractionItem("Rob", ButtonType.Triangle, "Rob", canBeRobbed));
            interactions.Add(new InteractionItem("Aim Weapon", ButtonType.R2, "AimWeapon", canBeAimedAt));

            return interactions;
        }

        public Transform GetTransform()
        {
            return transform;
        }
        #endregion

        private void SetAngry(bool value)
        {
            isAngry = value;
            canBeGreeted = !isAngry;
            canBeDefused = isAngry;
        }

        public void Antagonize()
        {
            DialogPanel.Instance.ShowText("Get out of my way.");
            SetAngry(true);
        }

        public void Greet()
        {
            DialogPanel.Instance.ShowText("How you doin'?!");
        }

        public void Defuse()
        {
            DialogPanel.Instance.ShowText("Relax, I'm joking...");
            SetAngry(false);
        }

        public void Rob()
        {
            DialogPanel.Instance.ShowText("Gimme your money now.");
        }

        public void AimWeapon()
        {
            DialogPanel.Instance.ShowText("AIM WEAPON");
        }
    }
}