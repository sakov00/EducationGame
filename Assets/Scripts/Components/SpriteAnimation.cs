using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Components
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimation : MonoBehaviour
    {
        [SerializeField] private int framerate;
        [SerializeField] private bool loop;
        [SerializeField] private Sprite[] sprites;
        [SerializeField] private UnityEvent onCompleted;

        private bool isPlaying = true;
        private int currentSpriteIndex;
        private float secondsPerFrame;
        private float nextFrameTime;
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            secondsPerFrame = 1f / framerate;
            nextFrameTime = Time.time + secondsPerFrame;
        }

        private void Update()
        {
            if (!isPlaying || nextFrameTime > Time.time)
                return;

            if (currentSpriteIndex >= sprites.Length)
            {
                if (loop)
                {
                    currentSpriteIndex = 0;
                }
                else
                {
                    isPlaying = false;
                    onCompleted.Invoke();
                }
            }


            spriteRenderer.sprite = sprites[currentSpriteIndex];
            nextFrameTime += secondsPerFrame;
            currentSpriteIndex++;
        }

    }
}
