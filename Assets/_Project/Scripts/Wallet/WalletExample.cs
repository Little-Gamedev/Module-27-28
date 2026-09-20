using System.Collections.Generic;
using UnityEngine;

public class WalletExample : MonoBehaviour
{
    [SerializeField] private List<CurrencyPanel> _currenciesPanelPrefabs;

    [SerializeField] private Transform _parentForСurrencies;

    [SerializeField] private int _testAmount = 5;

    private Wallet _wallet;

    private void Awake()
    {
        _wallet = new Wallet();

        foreach (CurrencyPanel panel in _currenciesPanelPrefabs)
        {
            CurrencyPanel newPanel = Instantiate(panel, _parentForСurrencies);
            newPanel.Initialize(_wallet.GetCurrency(panel.CurrencyType));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            AddCurrency(CurrencyType.Coin, _testAmount);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            AddCurrency(CurrencyType.Diamond, _testAmount);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            AddCurrency(CurrencyType.Ruby, _testAmount);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            SubtractCurrency(CurrencyType.Coin, _testAmount);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            SubtractCurrency(CurrencyType.Diamond, _testAmount);
        if (Input.GetKeyDown(KeyCode.Alpha6))
            SubtractCurrency(CurrencyType.Ruby, _testAmount);
    }

    private void AddCurrency(CurrencyType currencyType, int amount) => _wallet.Add(currencyType, amount);

    private void SubtractCurrency(CurrencyType currencyType, int amount) => _wallet.Subtract(currencyType, amount);
}
