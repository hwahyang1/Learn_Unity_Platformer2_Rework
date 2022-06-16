using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * [Namespace] _20220531_Platform2Rework.IntroScene
 * IntroScene의 스크립트를 관리합니다.
 */
namespace _20220531_Platform2Rework.IntroScene
{
	/*
	 * [Class] ButtonInteraction
	 * 버튼과의 상호작용을 관리합니다.
	 */
	public class ButtonInteraction : MonoBehaviour
	{
		/*
		 * [Method] OnGameStartButtonClicked(): void
		 * 게임 시작 버튼이 눌렸을 때의 상호작용을 처리합니다.
		 */
		public void OnGameStartButtonClicked()
		{
			SceneManager.LoadScene("GameScene");
		}

		/*
		 * [Method] OnGameExitButtonClicked(): void
		 * 게임 종료 버튼이 눌렸을 때의 상호작용을 처리합니다.
		 */
		public void OnGameExitButtonClicked()
		{
			#if UNITY_EDITOR
				EditorApplication.ExecuteMenuItem("Edit/Play");
			#else
				Application.Quit();
			#endif
		}
	}
}
