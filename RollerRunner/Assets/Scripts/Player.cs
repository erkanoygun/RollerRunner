using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    private int hammerSize = 0;
    private bool _isPieDedection = false;
    private int _score = 0;
    [SerializeField] private Transform _finisPointTransform;
    float finisDistance;
    private float _pointDistancePercentage;
    float _distancePercentageDif;
    [Header ("UI References")]
    [SerializeField] private GameObject _hammerDistanceUI;
    [SerializeField] private TMP_Text _hammerQuantity;
    [SerializeField] private TMP_Text _scoreText;

    private void Start()
    {
        finisDistance = GetDistance();
        _pointDistancePercentage = (2 * finisDistance) / 100;
        _distancePercentageDif = finisDistance - _pointDistancePercentage;
        _hammerQuantity.text = hammerSize.ToString();
    }

    void FixedUpdate()
    {
        transform.position += transform.forward * _speed * Time.fixedDeltaTime;
    }

    void Update()
    {
        finisDistance = GetDistance();
        if (finisDistance <= _distancePercentageDif)
        {
            _score += 5;
            _distancePercentageDif = finisDistance - _pointDistancePercentage;
            _scoreText.text = _score.ToString();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hammer"))
        {
            _hammerDistanceUI.SetActive(false);
            Destroy(collision.gameObject);
            hammerSize += 1;
            _hammerQuantity.text = hammerSize.ToString();
        }
        else if (collision.gameObject.CompareTag("Pie"))
        {
            if(hammerSize <= 0)
            {
                Debug.Log("Game Over");
            }
            else
            {
                if (!_isPieDedection)
                {
                    hammerSize -= 1;
                    collision.gameObject.GetComponent<Pie>().CollisionEnter();
                    Invoke("ChangeIsPieDedection", 0.2f);
                    _isPieDedection = true;
                    _hammerQuantity.text = hammerSize.ToString();
                }
            }
        }
    }

    private void ChangeIsPieDedection()
    {
        _isPieDedection = false;
    }

    private float GetDistance()
    {
        finisDistance = Vector3.Distance(transform.position, _finisPointTransform.transform.position);
        return finisDistance;
    }
}
