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
    [SerializeField] Transform leftHandTarget; // Új célpont objektum a bal kézhez
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
            //    gunAnim.SetIKRotationWeight(AvatarIKGoal.RightHand, UpperBody.transform.rotation.y);

            //    gunAnim.SetIKPosition(AvatarIKGoal.RightHand, targetPosition.transform.position);
            //    gunAnim.SetIKRotation(AvatarIKGoal.RightHand, UpperBody.transform.rotation);
            //}

            // Set the right hand target position and rotation, if one has been assigned
            if (RightArm != null)
            {
                gunAnim.SetIKPositionWeight(AvatarIKGoal.RightHand,0.3f);
                gunAnim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.01f);
                //Vector3 rightHandOffset = new Vector3(1f, 0, 0); // 0.1f �rt�k az X tengelyen val� eltol�s m�rt�ke
                //Vector3 rightHandTargetPosition = targetPosition.transform.position + rightHandOffset;

                gunAnim.SetIKPosition(AvatarIKGoal.RightHand, targetPosition.position);
                gunAnim.SetIKRotation(AvatarIKGoal.RightHand, targetPosition.rotation);

            }
            if (LeftArm != null)
            {
                gunAnim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 3f);
                gunAnim.SetIKRotationWeight(AvatarIKGoal.LeftHand,0.1f);

                // Bal k�z poz�ci�j�t �s rot�ci�j�t az illeszked�shez be�ll�tod
                //Vector3 leftHandOffset = new Vector3(1f, RightArm.transform.position.y, 0); // 0.1f �rt�k az X tengelyen val� eltol�s m�rt�ke
                //Vector3 leftHandTargetPosition = targetPosition.transform.position - leftHandOffset;

                gunAnim.SetIKPosition(AvatarIKGoal.LeftHand, targetPosition.position);
                gunAnim.SetIKRotation(AvatarIKGoal.LeftHand, targetPosition.rotation);

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
