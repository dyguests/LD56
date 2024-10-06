using UnityEngine;

namespace Wars.Views
{
    public class VisionView : MonoBehaviour
    {
        public delegate void OnVisionEnter(Collider2D other);
        public delegate void OnVisionExit(Collider2D other);
        public OnVisionEnter onVisionEnter;
        public OnVisionExit onVisionExit;

        private void OnTriggerEnter2D(Collider2D other)
        {
            onVisionEnter?.Invoke(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            onVisionExit?.Invoke(other);
        }
    }
}