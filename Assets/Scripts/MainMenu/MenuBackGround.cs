using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackGround : MonoBehaviour
{
    private Vector2 _startPos;
    [SerializeField] private int _moveModifier;
    [SerializeField] private int _minY;
    [SerializeField] private int _maxY;
    [SerializeField] private int _minX;
    [SerializeField] private int _maxX;

    private void Start()
    {
        _startPos = transform.position;
    }

    private void Update()
    {
        ParalaxBackground();
    }

    private void ParalaxBackground()
    {
        Vector2 _pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float _posX = Mathf.Lerp(transform.position.x, _startPos.x + (_pos.x * _moveModifier), 1f * Time.deltaTime);
        float _posY = Mathf.Lerp(transform.position.y, _startPos.y + (_pos.y * _moveModifier), 1f * Time.deltaTime);

        transform.position = new Vector3(_posX, _posY, 0);

        if (_posX > _maxX)
        {
            _posX = _maxX;
        }
        if (_posX < _minX)
        {
            _posX = _minX;
        }
        if (_posY > _maxY)
        {
            _posY = _maxY;
        }
        if (_posY < _minY)
        {
            _posY = _minY;
        }
    }
}
