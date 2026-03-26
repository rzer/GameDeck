using DefaultNamespace;
using UnityEngine;

public abstract class BaseController:MonoBehaviour
{
    public Card card => Card.instance;
    public CardData data => card.data;
    public VisualSettings settings => VisualSettings.Instance;

    public abstract void Render();
}
