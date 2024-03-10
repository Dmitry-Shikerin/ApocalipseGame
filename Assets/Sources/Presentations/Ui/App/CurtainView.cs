using System;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using Sources.Presentations.Views;
using UnityEngine;

namespace Sources.Presentations.Ui.App
{
    public class CurtainView : View
    {
        [Required][SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _duration = 1;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _canvasGroup.alpha = 0;
        }

        public async UniTask ShowCurtainAsync()
        {
            Show();
            await FadeAsync(0, 1);
        }

        public async UniTask HideCurtainAsync()
        {
            await FadeAsync(1, 0);
            Hide();
        }

        private async UniTask FadeAsync(float startAlpha, float endAlpha)
        {
            _canvasGroup.alpha = startAlpha;

            while (Mathf.Abs(_canvasGroup.alpha - endAlpha) > 0.01f)
            {
                _canvasGroup.alpha = Mathf.MoveTowards(
                    _canvasGroup.alpha, endAlpha, Time.deltaTime / _duration);

                await UniTask.Yield();
            }

            _canvasGroup.alpha = endAlpha;
        }
    }
}