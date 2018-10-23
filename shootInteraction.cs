// Copyright © 2018, Meta Company.  All rights reserved.
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
    /// Interaction to shoot projectiles.
    /// </summary>
    [AddComponentMenu("Meta/Interaction/ShootInteraction")]
    public class shootInteraction : Interaction
    {
        public Rigidbody projectile;
        public Transform shotPos;
        public float shotForce = 1000f;
        public float moveSpeed = 10f;
        public static bool engaged = false;

        public GameObject regler;
        public GameObject targetCube;
        public GameObject targetCube2;
        public GameObject targetCube3;
        public GameObject targetCube4;
        public GameObject targetCube5;
        public GameObject targetCube6;
        public GameObject targetCube7;
        public GameObject targetCube8;
        public GameObject targetCube9;
        private Vector3 startingPos;
        private Vector3 startingPos2;
        private Vector3 startingPos3;
        private Vector3 startingPos4;
        private Vector3 startingPos5;
        private Vector3 startingPos6;
        private Vector3 startingPos7;
        private Vector3 startingPos8;
        private Vector3 startingPos9;
        private Quaternion startingRot;
        private Quaternion startingRot2;
        private Quaternion startingRot3;
        private Quaternion startingRot4;
        private Quaternion startingRot5;
        private Quaternion startingRot6;
        private Quaternion startingRot7;
        private Quaternion startingRot8;
        private Quaternion startingRot9;
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
            startingPos = targetCube.transform.position;
            startingRot = targetCube.transform.rotation;
            startingPos2 = targetCube2.transform.position;
            startingRot2 = targetCube2.transform.rotation;
            startingPos3 = targetCube3.transform.position;
            startingRot3 = targetCube3.transform.rotation;
            startingPos4 = targetCube4.transform.position;
            startingRot4 = targetCube4.transform.rotation;
            //startingPos4.y = startingPos4.y+0.15f;
            startingPos5 = targetCube5.transform.position;
            startingRot5 = targetCube5.transform.rotation;
            //startingPos5.y = startingPos5.y + 0.15f;
            startingPos6 = targetCube6.transform.position;
            startingRot6 = targetCube6.transform.rotation;
            //startingPos6.y = startingPos6.y + 0.15f;
            startingPos7 = targetCube7.transform.position;
            startingRot7 = targetCube7.transform.rotation;
            //startingPos7.y = startingPos7.y + 0.2f;
            startingPos8 = targetCube8.transform.position;
            startingRot8 = targetCube8.transform.rotation;
            //startingPos8.y = startingPos8.y + 0.2f;
            startingPos9 = targetCube9.transform.position;
            startingRot9 = targetCube9.transform.rotation;
            //startingPos9.y = startingPos9.y + 0.2f;
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
            RespawnCubes();
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

        private void RespawnCubes()
        {
            targetCube.GetComponent<Rigidbody>().velocity = Vector3.zero;
            targetCube.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            targetCube.transform.rotation = startingRot;
            targetCube.transform.position = startingPos;            
            targetCube2.GetComponent<Rigidbody>().velocity = Vector3.zero;
            targetCube2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            targetCube2.transform.rotation = startingRot2;
            targetCube2.transform.position = startingPos2;            
            targetCube3.GetComponent<Rigidbody>().velocity = Vector3.zero;
            targetCube3.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            targetCube3.transform.rotation = startingRot3;
            targetCube3.transform.position = startingPos3;            
            targetCube4.GetComponent<Rigidbody>().velocity = Vector3.zero;
            targetCube4.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            targetCube4.transform.rotation = startingRot4;
            targetCube4.transform.position = startingPos4;
            targetCube5.GetComponent<Rigidbody>().velocity = Vector3.zero;
            targetCube5.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            targetCube5.transform.rotation = startingRot5;
            targetCube5.transform.position = startingPos5;
            targetCube6.GetComponent<Rigidbody>().velocity = Vector3.zero;
            targetCube6.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            targetCube6.transform.rotation = startingRot6;
            targetCube6.transform.position = startingPos6;
            targetCube7.GetComponent<Rigidbody>().velocity = Vector3.zero;
            targetCube7.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            targetCube7.transform.rotation = startingRot7;
            targetCube7.transform.position = startingPos7;
            targetCube8.GetComponent<Rigidbody>().velocity = Vector3.zero;
            targetCube8.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            targetCube8.transform.rotation = startingRot8;
            targetCube8.transform.position = startingPos8;
            targetCube9.GetComponent<Rigidbody>().velocity = Vector3.zero;
            targetCube9.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            targetCube9.transform.rotation = startingRot9;
            targetCube9.transform.position = startingPos9;
        }

    }
}
