using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    [SerializeField] private float _powerExplosion = 10;
    [SerializeField] private float _radiusExplosion = 5;
    [SerializeField] private LayerMask _layerObjects;

    [SerializeField] private float _timeToExplosion = 5;
    [SerializeField] private float _currenttimeToExplosion;
    [SerializeField] private bool _isLoop = true;


    private void Start()
    {
        _currenttimeToExplosion = _timeToExplosion;
    }

    private void Update()
    {
        if (_currenttimeToExplosion > 0)
        {
            _currenttimeToExplosion -= Time.deltaTime;
        }

        if (_currenttimeToExplosion < 0 && _currenttimeToExplosion > -1)
        {
            MyBoom();
            if (_isLoop)
            {
                _currenttimeToExplosion = _timeToExplosion;
            }
            else
            {
                _currenttimeToExplosion = -2;
            }
        }
    }

    private void MyBoom()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, _radiusExplosion, _layerObjects);

        foreach (var item in colls)
        {
            float distFloat = Vector3.Distance(transform.position, item.transform.position);
            if (distFloat < _radiusExplosion)
            {
                Vector3 dist = item.transform.position - transform.position;

                item.attachedRigidbody.AddForce(dist.normalized * _powerExplosion * (_radiusExplosion - distFloat));
            }
        }
    }
}
