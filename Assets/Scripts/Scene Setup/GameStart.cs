using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scene_Setup
{
    public class GameStart : MonoBehaviour
    {
        [SerializeField] private List<GameObject> objectsToInvokeAfterCutScene;
        [SerializeField] private List<GameObject> objectsToDivokeAfterCutScene;

        [SerializeField] private Image bg;

        private void Start()
        {
            StartFirstDialogue();
        }

        private void StartFirstDialogue()
        {
            DialogueController.instance.NewDialogueInstance("Когда-то это место было просто баней. ");
            DialogueController.instance.NewDialogueInstance(
                "Люди смеялись здесь, грели кости после долгой дороги");
            DialogueController.instance.NewDialogueInstance(
                "Но потом пришли [EXAGGERATE]Они[/EXAGGERATE] ");
            DialogueController.instance.NewDialogueInstance(
                "Те, кто смотрит из зеркал. ");
            DialogueController.instance.NewDialogueInstance("Те, чьи тени двигаются чуть медленнее, чем должны. ");
            DialogueController.instance.NewDialogueInstance(
                "Те, кто шепчет вам в темноте: [EXAGGERATE]\"Посмотри на меня...\"[/EXAGGERATE] ");
            DialogueController.instance.NewDialogueInstance("Теперь баня помнит. И ждёт. ");
            DialogueController.instance.NewDialogueInstance(
                "Здесь нет случайностей.");
            DialogueController.instance.NewDialogueInstance("Каждый ваш шаг, каждый взгляд, каждый вдох — уже часть игры. ");
            DialogueController.instance.NewDialogueInstance("Проверьте, закрыта ли дверь. ");
            DialogueController.instance.NewDialogueInstance("И никогда... ");
            DialogueController.instance.NewDialogueInstance(
                "[EXAGGERATE]никогда[/EXAGGERATE] не смотрите в зеркало....");

            DialogueController.instance.NewDialogueInstance(
                "О-о, новые гости...", "1");
            DialogueController.instance.NewDialogueInstance(
                "Садитесь, отдохните. Только не шумите — баня старая, всё скрипит.", "1");
            DialogueController.instance.NewDialogueInstance("Он медленно встаёт, поправляет печь");
            DialogueController.instance.NewDialogueInstance(
                "То труба течёт, то дверь не закрывается... Ладно, починю. Вы пока парьтесь.", "1");
            DialogueController.instance.NewDialogueInstance("Он уходит в предбанник.");

            DialogueController.instance.onDialogueFinished.AddListener(DelayBeforeFog);
        }

        private IEnumerator DelayBeforeFogCor()
        {
            DialogueController.instance.onDialogueFinished.RemoveListener(DelayBeforeFog);
            yield return new WaitForSeconds(3);

            bg.color = new Color(0, 0, 0, 255);

            DialogueController.instance.NewDialogueInstance("Внезапно свет выключается.");
            DialogueController.instance.NewDialogueInstance("Воздух густеет, становится трудно дышать");

            DialogueController.instance.NewDialogueInstance("Спите... Спите...", "2");
            DialogueController.instance.NewDialogueInstance("Ха-ха... Кажется, мы новых друзей нашли.", "3");
            
            DialogueController.instance.onDialogueFinished.AddListener(StartGame);
        }

        private void DelayBeforeFog()
        {
            StartCoroutine(DelayBeforeFogCor());
        }

        public void StartGame()
        {
            Debug.Log("game start");
            objectsToInvokeAfterCutScene.ForEach(obj => obj.SetActive(true));
            objectsToDivokeAfterCutScene.ForEach(obj => obj.SetActive(false));
        }
    }
}