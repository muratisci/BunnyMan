using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Transform rightArmTransform;
    public Transform leftArmTransform;
    public Transform rightFootTransform;
    public Transform leftFootTransform;

    private Animator _myAnimator;

    private void Start()
    {
        _myAnimator = GetComponent<Animator>();
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
