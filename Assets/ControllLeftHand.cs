//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ControllLeftHand : MonoBehaviour
//{

//    public Transform rightHandBone;  // A jobb k�z csontja (amely mozgatja a pusk�t)
//    public Animator animator;        // Az anim�tor referencia a karakterhez

//    void OnAnimatorIK(int layerIndex)
//    {
//        if (animator)
//        {
//            // Lek�rj�k a bal k�z jelenlegi poz�ci�j�t az anim�toron kereszt�l
//            Vector3 leftHandPosition = animator.GetIKPosition(AvatarIKGoal.LeftHand);

//            // Csak az Y koordin�t�t friss�tj�k a jobb k�z csontja alapj�n
//            leftHandPosition.y = rightHandBone.position.y;

//            // Be�ll�tjuk a bal k�z IK poz�ci�j�t az �j poz�ci�val, �s s�lyt adunk neki
//            animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandPosition);
//            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);

//            // (Opcion�lis) Ha a rot�ci� is sz�ks�ges:
//             animator.SetIKRotation(AvatarIKGoal.LeftHand, rightHandBone.rotation);
//             animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
//        }
//    }
//}


