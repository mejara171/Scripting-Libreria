using UnityEngine;

namespace Asteroids
{
    public class Movement : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        [SerializeField]
        private float lerpTime = 4f;

        private bool lerping;
        private Vector3 goalPosition;
        private Vector3 startPosition;
        private float elapsedTime;

        private void Update()
        {
            float movement = Input.GetAxis("Vertical");
            if (!Mathf.Approximately(movement, 0))
            {
                transform.Translate(Vector3.forward * speed * movement * Time.deltaTime);
                StopLerping();
            }
            else if (Input.GetMouseButtonDown(0))
                StartLerp();

            if (lerping)
                UpdatePosition();
        }

        private void StartLerp()
        {
            lerping = true;
            startPosition = transform.position;
            elapsedTime = 0;
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = transform.position.z;
            goalPosition = mouse;
        }

        private void UpdatePosition()
        {
            elapsedTime += Time.deltaTime;
            Debug.Log(elapsedTime / lerpTime);
            transform.position = Vector3.Lerp(startPosition, goalPosition, elapsedTime / lerpTime);
            if (elapsedTime / lerpTime >= 1f)
                StopLerping();
        }

        private void StopLerping()
        {
            Debug.Log("Stop Lerping");
            lerping = false;
        }
    }
}
