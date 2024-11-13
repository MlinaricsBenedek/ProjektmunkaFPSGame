//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ControllLeftHand : MonoBehaviour
//{

//    public Transform rightHandBone;  // A jobb kéz csontja (amely mozgatja a puskát)
//    public Animator animator;        // Az animátor referencia a karakterhez

//    void OnAnimatorIK(int layerIndex)
//    {
//        if (animator)
//        {
//            // Lekérjük a bal kéz jelenlegi pozícióját az animátoron keresztül
//            Vector3 leftHandPosition = animator.GetIKPosition(AvatarIKGoal.LeftHand);

//            // Csak az Y koordinátát frissítjük a jobb kéz csontja alapján
//            leftHandPosition.y = rightHandBone.position.y;

//            // Beállítjuk a bal kéz IK pozícióját az új pozícióval, és súlyt adunk neki
//            animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandPosition);
//            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);

//            // (Opcionális) Ha a rotáció is szükséges:
//             animator.SetIKRotation(AvatarIKGoal.LeftHand, rightHandBone.rotation);
//             animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
//        }
//    }
//}


