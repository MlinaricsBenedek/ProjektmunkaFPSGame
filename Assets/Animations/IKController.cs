using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IKController : MonoBehaviour
{
    [SerializeField] Animator gunAnim;
    [SerializeField] GameObject UpperBody;
    [SerializeField] Transform targetPosition;
    public bool isIKActive = true;
    [SerializeField] GameObject LeftArm;
    [SerializeField] GameObject RightArm;
    [SerializeField] GameObject gunPos;
    private void OnAnimatorIK(int layerIndex)
    {
        if (gunAnim)
        {// Set the look target position, if one has been assigned
            if (targetPosition != null)
            {
                gunAnim.SetLookAtWeight(1);
                gunAnim.SetLookAtPosition(targetPosition.position);
            }
            //if (UpperBody != null)
            //{
            //    gunAnim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.01f);
            //    gunAnim.SetIKRotationWeight(AvatarIKGoal.RightHand,UpperBody.transform.rotation.y);

            //    gunAnim.SetIKPosition(AvatarIKGoal.RightHand, targetPosition.transform.position);
            //    gunAnim.SetIKRotation(AvatarIKGoal.RightHand, UpperBody.transform.rotation);
            //}

            // Set the right hand target position and rotation, if one has been assigned
            if (RightArm != null)
            {
                gunAnim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.1f);
                gunAnim.SetIKRotationWeight(AvatarIKGoal.RightHand, RightArm.transform.position.x);

                gunAnim.SetIKPosition(AvatarIKGoal.RightHand, targetPosition.transform.position);
                gunAnim.SetIKRotation(AvatarIKGoal.RightHand, RightArm.transform.rotation);

            }
            if (LeftArm != null)
            {
                gunAnim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
                gunAnim.SetIKRotationWeight(AvatarIKGoal.LeftHand, LeftArm.transform.rotation.y);
                // Bal kéz pozícióját és rotációját az illeszkedéshez beállítod
                gunAnim.SetIKPosition(AvatarIKGoal.LeftHand, targetPosition.transform.position);
                gunAnim.SetIKRotation(AvatarIKGoal.LeftHand, targetPosition.transform.rotation);

            }

        }
        //if the IK is not active, set the position and rotation of the hand and head back to the original position
        else
        {
            gunAnim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            gunAnim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            gunAnim.SetLookAtWeight(0);
        }
        //if (targetPosition != null)
        //{
        //    gunPos.transform.position = targetPosition.position;
        //    gunPos.transform.rotation = targetPosition.rotation;
        //}
    }

}
