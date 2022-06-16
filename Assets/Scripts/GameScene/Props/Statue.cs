using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * [Namespace] _20220531_Platform2Rework.GameScene.Props
 * EventProp의 상호작용을 관리합니다.
 */
namespace _20220531_Platform2Rework.GameScene.Props
{
	/*
	 * [Class] Statue
	 * 석상의 상호작용을 관리합니다.
	 */
	public class Statue : EventProp
	{
		private Camera mainCamera;

		protected override void Start()
		{
			base.Start();

			mainCamera = Camera.main;
		}

		public override void OnInteract()
		{
			if (isUsed)
			{
				if (script.isEnd)
				{
					SceneManager.LoadScene("IntroScene");
				}
			}
			else
			{
				int res = playerInventory.TakeItem(takeItem);
				if (res == 0)
				{
					script.PrintScript(new string[] { "보석 두 개를 들고 책에 적혀있는 주문을 외웠더니 하늘에서 편지가 떨어졌다!", "편지 내용은 처음 보는 언어로 되어 있다.\n밖으로 나가게 되면 한번 조사 해 봐야 할 것 같다.", "..................여신상의 문구가 바뀌었다!\n다시 말을 걸면 탈출 할 수 있을 것 같다." });
					mainCamera.backgroundColor = new Color(1f, 1f, 1f);

					isUsed = true;
				}
				else
				{
					script.PrintScript(new string[] { "평범한 여신상이다.\n...........................자세히 보니 무언가가 써져있다!", "'이곳에서 탈출하고 싶다면 보석 두개를 가지고 특별한 주문을 외워라.'", "특별한 주문이 도대체 무엇일까?" });
				}
			}
		}
	}
}
