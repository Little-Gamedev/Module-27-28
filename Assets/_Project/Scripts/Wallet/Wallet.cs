using System;
using System.Collections.Generic;

public class Wallet
{
    private readonly Dictionary<CurrencyType, ReactiveVariable<int>> _currencies = new Dictionary<CurrencyType, ReactiveVariable<int>>();

    public Wallet()
    {
        foreach (CurrencyType currencyType in Enum.GetValues(typeof(CurrencyType)))
            _currencies.Add(currencyType, new ReactiveVariable<int>());
    }

    public IReadOnlyVariable<int> GetCurrency(CurrencyType currencyType) => _currencies[currencyType];

    public void Add(CurrencyType currencyType, int amount) => _currencies[currencyType].Value += amount;

    public void Subtract(CurrencyType currencyType, int amount)
    {
        if (_currencies[currencyType].Value < amount)
            return;

        _currencies[currencyType].Value -= amount;
    }
}
