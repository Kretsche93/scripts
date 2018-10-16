using Meta.HandInput;
using UnityEngine;

namespace Meta
{
    /// <summary>
    /// Interaction to grab the model to translate its position.
    /// </summary>



    [AddComponentMenu("Meta/Interaction/GrabInteraction")]
    public class danceAnimation : Interaction
    {
        public GameObject PatrickT;
        public Animator MyController;

        [SerializeField]

        private HandFeature _handFeature;

        private Vector3 _localOffset;
        protected override bool CanEngage(Hand handProxy)
        {
            return GrabbingHands.Count == 1;
        }


        protected override void Engage()
        {

            MyController = PatrickT.GetComponent<Animator>();
            _handFeature = GrabbingHands[0];

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
            RestoreRigidbodySettingsAfterInteraction();
            _handFeature = null;
            MyController.Play("Backflip");

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
