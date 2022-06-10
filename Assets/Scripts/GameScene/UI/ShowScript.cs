using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using NaughtyAttributes;

/*
 * [Namespace] _20220531_Platform2Rework.GameScene.UI
 * UI와 관련한 내용들을 정의합니다.
 */
namespace _20220531_Platform2Rework.GameScene.UI
{
	/*
	 * [Class] ShowScript
	 * 대사 노출을 관리합니다.
	 */
	public class ShowScript : MonoBehaviour
	{
		private Image continueButton;
		private Text textArea;

		[ShowNonSerializedField]
		private bool isScriptPrinting = false;
		[ShowNonSerializedField]
		private bool isWaitForInput = false; // 스크립트 출력 완료 후 대기 여부
		public bool isEnd // 대사가 모두 출력되고 대사창이 종료되었는지 여부. 다른 스크립트에서 이걸로 대사 출력 여부를 결정 가능
		{
			get
			{
				return !(isScriptPrinting || isWaitForInput);
			}
		}

		[SerializeField, Range(0f, 1f)]
		private float printSpeed = 0.3f;
		[SerializeField, Range(0f, 1f)]
		private float blinkSpeed = 0.25f;

		private string[] scripts;
		private int stack = 0;

		private void Start()
		{
			textArea = gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
			continueButton = gameObject.transform.GetChild(1).gameObject.GetComponent<Image>();

			continueButton.enabled = false;
			gameObject.SetActive(false);
			continueButton.gameObject.SetActive(false);
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
			{
				if (!isEnd)
				{
					if (isScriptPrinting)
					{
						isScriptPrinting = false;
						isWaitForInput = true;

						textArea.text = scripts[stack];
					}
					else
					{
						if (stack == scripts.Length - 1) // 출력할 대사가 더 남은 경우
						{
							isWaitForInput = false;
							isScriptPrinting = true;
							StartCoroutine(PrintCharacter(scripts[stack]));
						}
						else
						{
							//isScriptPrinting = false;
							isWaitForInput = false;
							gameObject.SetActive(false);
						}
					}
				}
			}
		}

		/*
		 * [Method] PrintScript(string[] scripts, bool isAvailableSkip = false): int
		 * 대사창에 대사를 출력합니다.
		 * 
		 * <string[] scripts>
		 * 출력을 원하는 대사를 입력합니다.
		 * 
		 * <RETURN: int>
		 * 오류 여부를 반환합니다.
		 * 0: 출력 성공. 성공적으로 대사 창을 띄운 경우 반환됩니다.
		 * 1: 출력 실패. 이미 대사가 출력 중인 경우 반환됩니다.
		 */
		public int PrintScript(string[] scripts)
		{
			if (!isEnd)
			{
				return 1;
			}

			if (!gameObject.activeInHierarchy)
			{
				gameObject.SetActive(true);
			}

			this.scripts = scripts;
			isScriptPrinting = true;
			stack = 0;
			StartCoroutine(PrintCharacter(scripts[stack]));

			return 0;
		}

		private IEnumerator PrintCharacter(string script)
		{
			textArea.text = "";

			for (int i = 0; i < script.Length; i++)
			{
				if (!isScriptPrinting) break;

				if (script[i] == ' ')
				{
					textArea.text += script[i];
					i++;
				}

				textArea.text += script[i];
				yield return new WaitForSeconds(printSpeed);
			}

			isScriptPrinting = false;
			isWaitForInput = true;
			stack++;

			StartCoroutine("WaitForInput");
		}

		private IEnumerator WaitForInput()
		{
			continueButton.gameObject.SetActive(true);

			while (isWaitForInput)
			{
				continueButton.enabled = !continueButton.enabled;
				yield return new WaitForSeconds(blinkSpeed);
			}

			continueButton.gameObject.SetActive(false);
		}
	}
}
