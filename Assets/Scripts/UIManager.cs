using Action = System.Action;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Mimic;

using DG.Tweening;

namespace ClothesStore {

    public class UIManager : Singleton<UIManager> {

        [SerializeField]
        private Text moneyTxt;        

        [SerializeField]
        private float transitionDuration = 0.5f;

        [SerializeField]
        private Image transitionMask;

        private void Update() {
            moneyTxt.text = GameManager.Instance.Money.ToString("$ #");
        }

        public void DoTransition(Action onTransitionInTheMiddle) {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transitionMask.DOFade(1, transitionDuration / 2));
            sequence.AppendCallback(() => onTransitionInTheMiddle());
            sequence.Append(transitionMask.DOFade(0, transitionDuration / 2));
        }

    }
    
}