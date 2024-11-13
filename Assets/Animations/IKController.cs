using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;
public class IKController : MonoBehaviour
{ 
//{
//    [SerializeField] Animator gunAnim;
//    [SerializeField] Transform righHandtargetPosition;
//    [SerializeField] Transform leftHandtargetRotation;
//    //public bool isIKActive = true;
//    //[SerializeField] Transform LeftArm;
//    //[SerializeField] Transform leftElbow;
//    //[SerializeField] Transform RightArm;
//    //[SerializeField] Transform gunPos;

//    private void OnAnimatorIK(int layerIndex)
//    {
//        if (gunAnim)
//        {// Set the look target position, if one has been assigned


//            // Set the right hand target position and rotation, if one has been assigned
//            if (righHandtargetPosition != null)
//            {
//                //ezzel beállítjuk, a reagálás mértékét. 
//                gunAnim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
//                gunAnim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);


//                gunAnim.SetIKPosition(AvatarIKGoal.RightHand, righHandtargetPosition.position);
//                gunAnim.SetIKRotation(AvatarIKGoal.RightHand, righHandtargetPosition.rotation);
//            }
//            if (leftHandtargetRotation != null)
//            {
//                gunAnim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
//                gunAnim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);

//                gunAnim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandtargetRotation.position);

//                gunAnim.SetIKRotation(AvatarIKGoal.LeftHand, leftHandtargetRotation.rotation);

//                //gunAnim.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, 1f);
//                //gunAnim.SetIKHintPosition(AvatarIKHint.LeftElbow, -(leftHandtargetRotation.position+ RightArm.position+LeftArm.position));

//            }

//        }
//        //if the IK is not active, set the position and rotation of the hand and head back to the original position
//        else
//        {
//            gunAnim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
//            gunAnim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
//            gunAnim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
//            gunAnim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
//            gunAnim.SetLookAtWeight(0);
//        }
//        //if (targetPosition != null)
//        //{
//        //    Quaternion gunrotate = targetPosition.rotation;
//        //    gunrotate.y = 0f;

//        //    //x tengelyen adjuk át a gunpos-nak.
//        //    //y tengelyen ne adjuk át 
//        //    gunPos.transform.rotation = gunrotate;


//        //    //}
//        }

    }
