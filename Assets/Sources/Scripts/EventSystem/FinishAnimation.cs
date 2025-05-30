﻿using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CMS.EventSystem
{
    [Serializable]
    public class FinishAnimation
    {
        [SerializeField] private CanvasGroup _canvas;
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private float _duration;

        public WaitForSeconds Play(string text, Color imageColor, Color textColor)
        {
            return Play(text, imageColor, textColor, _duration);
        }

        public WaitForSeconds Play(string text, Color imageColor, Color textColor, float duration)
        {
            _text.text = text;
            _text.color = textColor;
            _image.color = new Color(imageColor.r, imageColor.g, imageColor.b, imageColor.a);
            _canvas.DOFade(1f, duration);

            return new WaitForSeconds(duration);
        }

        public void Stop(string text)
        {
            _text.DOFade(0, _duration).onComplete += () => Happy(text);
        }

        private void Happy(string text)
        {
            _text.text = text;
            _text.DOFade(1, _duration);
        }
    }
}