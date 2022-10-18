using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nissensai2022.Loadding
{
    public class LoaddingManager : MonoBehaviour
    {
        internal static LoaddingManager Instance;
        [SerializeField] private float speed = 360f;
        [SerializeField] private float minTime = 0.5f;
        private static Image _image;
        private static bool _enable;
        private static float _timer;

        public static void Show()
        {
            _timer = 0f;
            _enable = true;
            _image.enabled = true;
        }

        public static void Hide()
        {
            Instance.StartCoroutine(DelayHide());
        }

        private static IEnumerator DelayHide()
        {
            float waitTime = Instance.minTime - _timer;
            if (waitTime > 0)
                yield return new WaitForSeconds(waitTime);
            _enable = false;
            _image.enabled = false;
            //_image.transform.rotation = Quaternion.identity;
        }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }

            _image = GetComponentInChildren<Image>();
            Hide();
        }

        private void Update()
        {
            if (!_enable)
                return;
            _timer += Time.deltaTime;
            _image.transform.Rotate(0f, 0f, speed * Time.deltaTime);
        }
    }
}