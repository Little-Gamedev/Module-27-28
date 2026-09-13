using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyPanel : MonoBehaviour
{
    [SerializeField] private Image _currencyIcon;
    [SerializeField] private TMP_Text _countTMP;

    public void UpdateAmount(int amount)
    {
        _countTMP.text = amount.ToString();
    }
}
