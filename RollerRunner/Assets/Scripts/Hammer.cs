using UnityEngine;
using TMPro;

public class Hammer : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    public float _distance;
    [SerializeField] private TMP_Text _hammerDistance;
    void Start()
    {
        _distance = GetDistance();
    }

    
    void Update()
    {
        if(_distance >= 0)
        {
            _distance = GetDistance();
            _distance = ((int)_distance);
            _hammerDistance.text = _distance.ToString() + " m";
        }
    }

   private float GetDistance()
    {
        return Vector3.Distance(transform.position, _player.transform.position);
    }
}
