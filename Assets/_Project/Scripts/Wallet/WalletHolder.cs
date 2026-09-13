using UnityEngine;

public class WalletHolder : MonoBehaviour
{
    private Wallet _wallet;

    public Wallet Wallet => _wallet;

    private void Awake()
    {
        _wallet = new Wallet();
    }
}
