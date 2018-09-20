using UnityEngine;

namespace HellStoned.Core
{
    public class AudioStorageController : MonoBehaviour
    {
        [SerializeField]
        private AudioSource pickUp;
        public AudioSource PickUp { get { return this.pickUp; } }

        [SerializeField]
        private AudioSource jump;
        public AudioSource Jump { get { return this.jump; } }

        [SerializeField]
        private AudioSource gettingHit;
        public AudioSource GettingHit { get { return this.gettingHit; } }
    }
}
