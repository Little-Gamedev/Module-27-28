using UnityEngine;

public class TargetMarkerView : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private TargetMarker _targetMarker;

    private void Update()
    {
        if (_character.HasTarget)
        {
            _targetMarker.Show(_character.TargetPoint);
            return;
        }

        _targetMarker.Hide();
    }
}