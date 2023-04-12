using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerRunning : DeerStrategy
{
    Animator _animator = null;
    GameObject _player = null;
    Rigidbody _deerRigidbody = null;
    float _speed = -30.0f;
    public void Action(GameObject _deer){
        _player = _deer.GetComponent<Deer>().GetPlayer;
        if (_player != null)
        {
            _animator = _deer.GetComponent<Animator>();
            _deerRigidbody = _deer.GetComponent<Rigidbody>();
            _speed = _deer.GetComponent<Deer>().GetSpeed;
            SetAnimation(_animator);
            Run(_deer, _player, _deerRigidbody, _speed);
        }
    }
    private void SetAnimation(Animator _animator){
        _animator.SetBool("running", true);
        _animator.SetBool("idle_0",false);
        _animator.SetBool("idle_1",false);
        _animator.SetBool("idle_2",false);
        _animator.SetBool("scared", false);
    }
    public void Run(GameObject _deer, GameObject _player, Rigidbody _deerRigidbody, float _speed)
    {
        Vector3 direction = _deer.transform.position - _player.transform.position;
        _deer.transform.rotation = Quaternion.LookRotation(direction);
        _deerRigidbody.MovePosition(_deerRigidbody.position + direction.normalized * _speed * Time.deltaTime);
    }
}
