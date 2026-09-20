using TMPro;
using UnityEngine;

public class CurrencyPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _countTMP;
    [SerializeField] private CurrencyType _currencyType;

    private IReadOnlyVariable<int> _currencyAmount;

    public CurrencyType CurrencyType => _currencyType;

    private void OnDestroy()
    {
        if (_currencyAmount == null)
            return;

        _currencyAmount.Changed -= UpdateAmount;
    }

    public void Initialize(IReadOnlyVariable<int> currencyAmount)
    {
        _currencyAmount = currencyAmount;
        _currencyAmount.Changed += UpdateAmount;
        ShowAmount(_currencyAmount.Value);
    }

    private void UpdateAmount(int oldValue, int newValue) => ShowAmount(newValue);

    private void ShowAmount(int value) => _countTMP.text = value.ToString();
}
