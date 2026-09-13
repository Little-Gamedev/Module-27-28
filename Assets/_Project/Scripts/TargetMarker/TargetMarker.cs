using UnityEngine;

public class TargetMarker : MonoBehaviour
{
    [SerializeField] private GameObject _markerPrefab;

    private GameObject _currentMarker;

    public void Show(Vector3 position)
    {
        if (_currentMarker == null)
            _currentMarker = Instantiate(_markerPrefab, position, Quaternion.identity, transform);
        else
            _currentMarker.transform.position = position;

        _currentMarker.SetActive(true);
    }

    public void Hide()
    {
        if (_currentMarker != null)
            _currentMarker.SetActive(false);
    }
}