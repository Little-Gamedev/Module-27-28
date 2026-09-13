using System;
using System.Collections.Generic;

public class Wallet
{
    public event Action<CurrencyType, int> ChangeCurrency;

    private readonly Dictionary<CurrencyType, int> _currencies = new Dictionary<CurrencyType, int>();

    public Wallet()
    {
        foreach (CurrencyType currencyType in Enum.GetValues(typeof(CurrencyType)))
            _currencies.Add(currencyType, 0);
    }

    public int GetCurrencyAmount(CurrencyType currencyType) => _currencies[currencyType];

    public void Add(CurrencyType currencyType, int amount)
    {
        _currencies[currencyType] += amount;

        NotifyChanged(currencyType);
    }

    public void Subtract(CurrencyType currencyType, int amount)
    {
        if (_currencies[currencyType] < amount)
            return;

        _currencies[currencyType] -= amount;

        NotifyChanged(currencyType);
    }

    private void NotifyChanged(CurrencyType currencyType)
    {
        int currencyResult = _currencies[currencyType];
        ChangeCurrency?.Invoke(currencyType, currencyResult);
    }
}
