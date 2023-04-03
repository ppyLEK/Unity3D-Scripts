using System;
using UnityEngine;
namespace ppyLEK.Fps
{
    public class SimpleMouseRotator : MonoBehaviour
    {
        // Only rotates around local X and Y
        public Vector2 rotationRange = new Vector3(70, 70);
        public float rotationSpeed = 10;
        public float dampingTime = 0.2f;
        public bool autoZeroVerticalOnMobile = true;
        public bool autoZeroHorizontalOnMobile = false;
        public bool relative = true;
        
        
        private Vector3 m_TargetAngles;
        private Vector3 m_FollowAngles;
        private Vector3 m_FollowVelocity;
        private Quaternion m_OriginalRotation;


        private void Start()
        {
            m_OriginalRotation = transform.localRotation;
        }


        private void Update()
        {
            transform.localRotation = m_OriginalRotation;
            
            float inputH;
            float inputV;
            if (relative)
            {
                inputH = Input.GetAxis("Mouse X");
                inputV = Input.GetAxis("Mouse Y");

                if (m_TargetAngles.y > 180)
                {
                    m_TargetAngles.y -= 360;
                    m_FollowAngles.y -= 360;
                }
                if (m_TargetAngles.x > 180)
                {
                    m_TargetAngles.x -= 360;
                    m_FollowAngles.x -= 360;
                }
                if (m_TargetAngles.y < -180)
                {
                    m_TargetAngles.y += 360;
                    m_FollowAngles.y += 360;
                }
                if (m_TargetAngles.x < -180)
                {
                    m_TargetAngles.x += 360;
                    m_FollowAngles.x += 360;
                }

                m_TargetAngles.y = Mathf.Clamp(m_TargetAngles.y, -rotationRange.y*0.5f, rotationRange.y*0.5f);
                m_TargetAngles.x = Mathf.Clamp(m_TargetAngles.x, -rotationRange.x*0.5f, rotationRange.x*0.5f);
            }
            else
            {
                inputH = Input.mousePosition.x;
                inputV = Input.mousePosition.y;

                m_TargetAngles.y = Mathf.Lerp(-rotationRange.y*0.5f, rotationRange.y*0.5f, inputH/Screen.width);
                m_TargetAngles.x = Mathf.Lerp(-rotationRange.x*0.5f, rotationRange.x*0.5f, inputV/Screen.height);
            }

            m_FollowAngles = Vector3.SmoothDamp(m_FollowAngles, m_TargetAngles, ref m_FollowVelocity, dampingTime);

            transform.localRotation = m_OriginalRotation*Quaternion.Euler(-m_FollowAngles.x, m_FollowAngles.y, 0);
        }
    }
}
