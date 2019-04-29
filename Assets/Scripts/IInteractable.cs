using System.Collections.Generic;
using UnityEngine;

namespace RedDeadInteraction
{
    public interface IInteractable
    {
        string GetName();
        List<InteractionItem> GetInteractions();
        Transform GetTransform();
    }
}