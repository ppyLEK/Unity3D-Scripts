using UnityEngine;

namespace ppyLEK.Controller.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class TerrainStep : MonoBehaviour
    {
        [SerializeField] private AudioClip[] stoneClips;
        [SerializeField] private AudioClip[] grassClips;

        private AudioSource audioSource;

        private TerrainDetector terrainDetector;
        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            terrainDetector = new TerrainDetector();
        }

        
        public void Step() //Step event tied to animator.cs
        {
            AudioClip clip = GetRandomClip();
            audioSource.PlayOneShot(clip);
        }

        private AudioClip GetRandomClip()
        {
            int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);

            switch (terrainTextureIndex)
            {
                case 0:
                    return stoneClips.Length > 0 ? stoneClips[Random.Range(0, stoneClips.Length)] : null;
                case 1:
                default:
                    return grassClips.Length > 0 ? grassClips[Random.Range(0, grassClips.Length)] : null;
            }
        }
    }
}