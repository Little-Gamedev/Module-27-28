using TMPro;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyUIWorldSpace : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _textCharacteristics;

    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();

        _nameText.text = _enemy.GetType().Name;
        _textCharacteristics.text = _enemy.GetDescription();
    }
}