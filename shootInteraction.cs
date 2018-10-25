using Meta.HandInput;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Meta
{
    /// <summary>
    /// Interaction to shoot projectiles.
    /// </summary>
    [AddComponentMenu("Meta/Interaction/ShootInteraction")]
    public class shootInteraction : Interaction
    {
        public Rigidbody projectile;
        public Transform shotPos;
        public float shotForce = 1000f;
        public static bool engaged = false;

        //public GameObject regler;
        private Slider sliderForce;
        private Slider sliderFrequency;
        private float shotInterval;
        public GameObject targetCube;
        public GameObject targetCube2;
        public GameObject targetCube3;
        public GameObject targetCube4;
        public GameObject targetCube5;
        public GameObject targetCube6;
        public GameObject targetCube7;
        public GameObject targetCube8;
        public GameObject targetCube9;
        

        private HandFeature _handFeature;

        private Vector3 _localOffset;
        protected override bool CanEngage(Hand handProxy)
        {
            return GrabbingHands.Count == 1;
        }
        

        protected override void Engage()
        {
            _handFeature = GrabbingHands[0];
            sliderForce = GameObject.Find("SliderShotForce").GetComponent<Slider>();
            sliderFrequency = GameObject.Find("SliderShotFrequency").GetComponent<Slider>();
            engaged = true;
            PrepareRigidbodyForInteraction();
            shotForce = sliderForce.value;
            shotInterval = 1/sliderFrequency.value;
            StartCoroutine("Shoot");          

            // Store the offset of the object local to the hand feature.  This will be used to keep the object at the same distance from the hand when being moved.

            SetHandOffsets();
        }

        protected override bool CanDisengage(Hand handProxy)
        {
            if (_handFeature != null && handProxy.Palm == _handFeature)
            {
                foreach (var hand in GrabbingHands)
                {
                    if (hand != _handFeature)
                    {
                        _handFeature = hand;
                        SetHandOffsets();
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        protected override void Disengage()
        {
            Manipulate();
            engaged = false;
            RestoreRigidbodySettingsAfterInteraction();
            _handFeature = null;
            GameObject.Find("RespawnScript").GetComponent<RespawnCubes>().CallRespawn();
        }

        protected override void Manipulate()
        {
            //if (engaged)
            //{
            //    StartCoroutine("Shoot");
            //}

            Move(TransformedHandPos());
        }

        private Vector3 TransformedHandPos()
        {
            // This complements obtaining the offset - used to convert back to world space.
            Vector3 offset = _handFeature.transform.TransformDirection(_localOffset);
            Vector3 grabPosition = _handFeature.transform.position + offset;
            return grabPosition;
        }

        private void SetHandOffsets()
        {
            _localOffset = _handFeature.transform.InverseTransformDirection(TargetTransform.position - _handFeature.Position);
            SetGrabOffset(TransformedHandPos());
        }

        private IEnumerator Shoot()
        {
            while (engaged)
            {
                yield return new WaitForSeconds(shotInterval);
                if (engaged) //if disengaged while waiting
                {
                    Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
                    shot.AddForce(shotPos.forward * shotForce);
                }
            }          
            
        }

    }
}
