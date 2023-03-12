using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    [SerializeField] Transform _finishPointTransform;

    private Image _progressBarImage;

    private Vector3 finshPointPosition;

    private float fullDistance;

    void Start()
    {
        finshPointPosition = _finishPointTransform.position;
        fullDistance = GetDistance();
        _progressBarImage = GetComponent<Image>();
    }

    
    void Update()
    {
        if (_playerTransform.position.z <= finshPointPosition.z)
        {
            float newDistance = GetDistance();
            float progressValue = Mathf.InverseLerp(fullDistance, 0f, newDistance);
            _progressBarImage.fillAmount = progressValue;
        }
    }

    float GetDistance()
    {
        return Vector3.Distance(_playerTransform.position, finshPointPosition);
    }
}
