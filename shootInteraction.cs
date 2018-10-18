﻿// Copyright © 2018, Meta Company.  All rights reserved.
// 
// Redistribution and use of this software (the "Software") in binary form, without modification, is 
// permitted provided that the following conditions are met:
// 
// 1.      Redistributions of the unmodified Software in binary form must reproduce the above 
//         copyright notice, this list of conditions and the following disclaimer in the 
//         documentation and/or other materials provided with the distribution.
// 2.      The name of Meta Company (“Meta”) may not be used to endorse or promote products derived 
//         from this Software without specific prior written permission from Meta.
// 3.      LIMITATION TO META PLATFORM: Use of the Software is limited to use on or in connection 
//         with Meta-branded devices or Meta-branded software development kits.  For example, a bona 
//         fide recipient of the Software may incorporate an unmodified binary version of the 
//         Software into an application limited to use on or in connection with a Meta-branded 
//         device, while he or she may not incorporate an unmodified binary version of the Software 
//         into an application designed or offered for use on a non-Meta-branded device.
// 
// For the sake of clarity, the Software may not be redistributed under any circumstances in source 
// code form, or in the form of modified binary code – and nothing in this License shall be construed 
// to permit such redistribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDER "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, 
// INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
// PARTICULAR PURPOSE ARE DISCLAIMED.  IN NO EVENT SHALL META COMPANY BE LIABLE FOR ANY DIRECT, 
// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, 
// PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA OR PROFITS; OR BUSINESS 
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT 
// LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS 
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
using Meta.HandInput;
using UnityEngine;

namespace Meta
{
    /// <summary>
    /// Interaction to grab the model to translate its position.
    /// </summary>
    [AddComponentMenu("Meta/Interaction/ShootInteraction")]
    public class shootInteraction : Interaction
    {
        public Rigidbody projectile;
        public Transform shotPos;
        public float shotForce = 1000f;
        public float moveSpeed = 10f;
        private bool engaged = false;
        public GameObject regler;
        //private bool waitTimer = true;

        private HandFeature _handFeature;

        private Vector3 _localOffset;
        protected override bool CanEngage(Hand handProxy)
        {
            return GrabbingHands.Count == 1;
        }

        protected override void Engage()
        {
            _handFeature = GrabbingHands[0];

            engaged = true;
            PrepareRigidbodyForInteraction();
            

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
        }

        protected override void Manipulate()
        {
            if (engaged)
            {
                Shoot();                              
            }
            shotForce = regler.transform.localScale.x*1000;
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

        private void Shoot()
        {
            //if (waitTimer)
            //{
                //waitTimer = false;
                Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
                shot.AddForce(shotPos.forward * shotForce);
                //Debug.Log("to Wait");
                //Wait();
              //  }
        }

        private System.Collections.Generic.IEnumerable<WaitForSeconds> Wait()
        {
            Debug.Log("Wait start");
            //waitTimer = true;
            yield return new WaitForSeconds(1);
            Debug.Log("Wait end");
        }

    }
}