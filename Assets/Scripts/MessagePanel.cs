using System;

using UnityEngine;
using UnityEngine.UI;

using Mimic;

namespace ClothesStore {

    public class MessagePanel : Singleton<MessagePanel> {
        
        [SerializeField]
        private RectTransform content;

        [SerializeField]
        private Image sourceImg;

        [SerializeField]
        private Text messageTxt;
        
        [SerializeField]
        private Button option1Btn;
        
        [SerializeField]
        private Button option2Btn;

        private Action option1Action;
        private Action option2Action;
        
        public void Show(Sprite source, string message, string option1, Action option1Action) {
            GameManager.Instance.IsPaused = true;
            content.gameObject.SetActive(true);
            sourceImg.sprite = source;
            messageTxt.text = message;
            this.option1Action = option1Action;
            option1Btn.GetComponentInChildren<Text>().text = option1;
            option2Btn.gameObject.SetActive(false);
        }
        
        public void Show(Sprite source, string message, string option1, string option2, Action option1Action, Action option2Action) {
            Show(source, message, option1, option1Action);
            this.option2Action = option2Action;
            option2Btn.GetComponentInChildren<Text>().text = option2;
            option2Btn.gameObject.SetActive(true);
        }

        public void OnOption1BtnClick() {
            Close();
            option1Action?.Invoke();
        }

        public void OnOption2BtnClick() {
            Close();
            option1Action?.Invoke();
        }

        public void Close() {
            content.gameObject.SetActive(false);
            GameManager.Instance.IsPaused = false;
        }
        
    }

}