using UnityEngine;

public class TestWalletAddRemove : MonoBehaviour
{
    [SerializeField] private WalletHolder _walletHolder;
    [SerializeField] private int _testAmount = 5;

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

    private void AddCurrency(CurrencyType currencyType, int amount) => _walletHolder.Wallet.Add(currencyType, amount);

    private void SubtractCurrency(CurrencyType currencyType, int amount) => _walletHolder.Wallet.Subtract(currencyType, amount);
}
