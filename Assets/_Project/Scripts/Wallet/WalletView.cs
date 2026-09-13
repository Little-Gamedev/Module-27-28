using System.Collections.Generic;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private WalletHolder _walletHolder;
    [SerializeField] private CurrencyPanel _coinPanelPrefab;
    [SerializeField] private CurrencyPanel _diamondPanelPrefab;
    [SerializeField] private CurrencyPanel _rubyPanelPrefab;

    [SerializeField] private Transform _parentForCurrencys;

    private Dictionary<CurrencyType, CurrencyPanel> _panels = new Dictionary<CurrencyType, CurrencyPanel>();

    private Wallet _wallet;

    private void OnDestroy()
    {
        _wallet.ChangeCurrency -= OnCurrencyChanged;
    }

    private void Start()
    {
        Initialize();
        SpawnUI();
        _wallet.ChangeCurrency += OnCurrencyChanged;
    }

    private void SpawnUI()
    {
        _panels.Add(CurrencyType.Coin, Instantiate(_coinPanelPrefab, _parentForCurrencys));
        _panels.Add(CurrencyType.Diamond, Instantiate(_diamondPanelPrefab, _parentForCurrencys));
        _panels.Add(CurrencyType.Ruby, Instantiate(_rubyPanelPrefab, _parentForCurrencys));

        foreach (CurrencyType currencyType in _panels.Keys)
        {
            OnCurrencyChanged(currencyType, _wallet.GetCurrencyAmount(currencyType));
        }
    }

    private void OnCurrencyChanged(CurrencyType currencyType, int currencyAmount)
    {
        _panels[currencyType].UpdateAmount(currencyAmount);
    }

    private void Initialize()
    {
        _wallet = _walletHolder.Wallet;
    }
}
