using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{

    public Transform rightArmTransform;
    public Transform leftArmTransform;
    public Transform rightFootTransform;
    public Transform leftFootTransform;

    public float speedMultiplier;
    
    private Animator _myAnimator;
    private Transform _parent;
    private float _direction;

    private void Start()
    {
        _myAnimator = GetComponent<Animator>();
        _parent = transform.parent;
    }

    private void Update()
    {
        TurnInputs();
        Movement();
        IKInputs();
    }

    private void Movement()
    {
        _parent.root.Translate(Vector3.forward * _direction * speedMultiplier * Time.deltaTime);
    }
    private void TurnInputs()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _parent.Rotate(Vector3.right * 360f * Time.deltaTime);
            _direction = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _parent.Rotate(Vector3.right * -360f * Time.deltaTime);
            _direction = -1;
        }
        else
        {
            _direction = 0;
        }
    }
    private void IKInputs()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //  DOTween.Kill(rightFootTransform);
            // DOTween.Kill(leftFootTransform);
            rightFootTransform.DOLocalMoveY(-1, 0.12f);
            leftFootTransform.DOLocalMoveY(-1f, 0.12f);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            //DOTween.Kill(rightFootTransform);
            //DOTween.Kill(leftFootTransform);
            rightFootTransform.DOLocalMoveY(-0.5f, 0.12f);
            leftFootTransform.DOLocalMoveY(-0.5f, 0.12f);
        }
    }
    private void OnAnimatorIK(int layerIndex)
    {
        _myAnimator.SetIKPosition(AvatarIKGoal.RightHand, rightArmTransform.position);
        _myAnimator.SetIKRotation(AvatarIKGoal.RightHand, rightArmTransform.rotation);
        _myAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        _myAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
        
        _myAnimator.SetIKPosition(AvatarIKGoal.LeftHand, leftArmTransform.position);
        _myAnimator.SetIKRotation(AvatarIKGoal.LeftHand, leftArmTransform.rotation);
        _myAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        _myAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
        
        _myAnimator.SetIKPosition(AvatarIKGoal.RightFoot, rightFootTransform.position);
        _myAnimator.SetIKRotation(AvatarIKGoal.RightFoot, rightFootTransform.rotation);
        _myAnimator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
        _myAnimator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
        
        _myAnimator.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootTransform.position);
        _myAnimator.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootTransform.rotation);
        _myAnimator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
        _myAnimator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
        
    }
}
