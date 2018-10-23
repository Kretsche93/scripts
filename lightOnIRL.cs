using Meta.HandInput;

using UnityEngine;
using UnityEngine.Networking;

namespace Meta
{
    /// <summary>
    /// Interaction to grab the model to translate its position.
    /// </summary>



    [AddComponentMenu("Meta/Interaction/lightOnIRLInteraction")]
    public class lightOnIRL : Interaction
    {

        //string url4 = "http://192.168.25.105/api/1LvlwLpMQlOd4tFNn1pniLoImIcEx8aiv0YOZcLM/lights/12/state";
        string url = "http://192.168.25.105/api/1LvlwLpMQlOd4tFNn1pniLoImIcEx8aiv0YOZcLM/groups/6/action";
        string lightsOn = "{\"on\":true}";
        [SerializeField]

        private HandFeature _handFeature;

        private Vector3 _localOffset;
        protected override bool CanEngage(Hand handProxy)
        {
            return GrabbingHands.Count == 1;
        }


        protected override void Engage()
        {
            _handFeature = GrabbingHands[0];

            PrepareRigidbodyForInteraction();

            // Store the offset of the object local to the hand feature.  This will be used to keep the object at the same distance from the hand when being moved.
            SetHandOffsets();
            UnityWebRequest www = UnityWebRequest.Put(url, lightsOn);
            //UnityWebRequest www2 = UnityWebRequest.Put(url5, lightsOn);
            //UnityWebRequest www3 = UnityWebRequest.Put(url6, lightsOn);
            www.SendWebRequest();
            //www2.SendWebRequest();
            //www3.SendWebRequest();
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
            //Manipulate();
            RestoreRigidbodySettingsAfterInteraction();
            _handFeature = null;

        }

        protected override void Manipulate()
        {

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
    }
}
