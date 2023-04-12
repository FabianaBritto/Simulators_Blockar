using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerIdle : DeerStrategy
{
    // private float lastValue = 0.0f;
    public void Action(GameObject _deer){
        Animator _animator = _deer.GetComponent<Animator>();
        SetAnimation(_animator);
    }
    private void SetAnimation(Animator _animator){
        int randomNumber = Random.Range(0, 3);
        switch (randomNumber)
        {
            case 0:
                _animator.SetBool("idle_0",true);
                _animator.SetBool("idle_1",false);
                _animator.SetBool("idle_2",false);
                // _animator.SetBool("idle",true);
                // _animator.SetFloat("idle_state", Mathf.Lerp(lastValue, 0.0f, Time.deltaTime * 2.0f));
                // lastValue = 0.0f;
                _animator.SetBool("running",false);
                _animator.SetBool("scared",false);
                break;
            case 1:
                _animator.SetBool("idle_0",false);
                _animator.SetBool("idle_1",true);
                _animator.SetBool("idle_2",false);
                // _animator.SetBool("idle",true);
                // _animator.SetFloat("idle_state", Mathf.Lerp(lastValue, 1.0f, Time.deltaTime * 2.0f));
                // lastValue = 1.0f;
                _animator.SetBool("running",false);
                _animator.SetBool("scared",false);
                break;
            case 2:
                _animator.SetBool("idle_0",false);
                _animator.SetBool("idle_1",false);
                _animator.SetBool("idle_2",true);
                // _animator.SetBool("idle",true);
                // _animator.SetFloat("idle_state", Mathf.Lerp(lastValue, 2.0f, Time.deltaTime * 2.0f));
                // lastValue = 2.0f;
                _animator.SetBool("running",false);
                _animator.SetBool("scared",false);
                break;
        }
    }
}
