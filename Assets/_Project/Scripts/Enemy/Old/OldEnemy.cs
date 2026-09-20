using UnityEngine;

public class OldEnemy : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    public bool IsDead { get; private set; }

    public void SetColor(Color color) => _renderer.material.color = color;

    public void Die() => IsDead = true;

}