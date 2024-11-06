using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKController : MonoBehaviour
{
    [SerializeField] Animator gunAnim;
    [SerializeField] GameObject UpperBody;
    [SerializeField] Transform targetPosition;
    public bool isIKActive = true;
    [SerializeField] GameObject LeftArm;
    [SerializeField] GameObject RightArm;

    private void OnAnimatorIK(int layerIndex)
    {
        if (gunAnim)
        {// Set the look target position, if one has been assigned
            if (targetPosition != null)
            {
                gunAnim.SetLookAtWeight(1);
                gunAnim.SetLookAtPosition(targetPosition.position);
            }

            // Set the right hand target position and rotation, if one has been assigned
            if (UpperBody != null)
            {
                gunAnim.SetIKPositionWeight(AvatarIKGoal.RightHand,0.1f);
                gunAnim.SetIKRotationWeight(AvatarIKGoal.RightHand,RightArm.transform.position.x);
                
                gunAnim.SetIKPosition(AvatarIKGoal.RightHand, targetPosition.transform.position);
                gunAnim.SetIKRotation(AvatarIKGoal.RightHand, RightArm.transform.rotation);

               
                gunAnim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
                gunAnim.SetIKRotationWeight(AvatarIKGoal.LeftHand, LeftArm.transform.rotation.y);
                // Bal k�z poz�ci�j�t �s rot�ci�j�t az illeszked�shez be�ll�tod
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
    }

}