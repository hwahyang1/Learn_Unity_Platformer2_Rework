using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/*
 * [Namespace] _20220531_Platform2Rework.GameScene.Props
 * EventProp의 상호작용을 관리합니다.
 */
namespace _20220531_Platform2Rework.GameScene.Props
{
	/*
	 * [Class] Stone
	 * 돌의 상호작용을 관리합니다.
	 */
	public class Stone : EventProp
	{
		[Header("해당 스크립트에서 takeItem/giveItem 변수는 사용되지 않습니다!!!!")]
		[SerializeField]
		private bool dummy;

		public override void OnInteract()
		{
			script.PrintScript(new string[] { "큰 돌이 길을 가로막고 있다.\n힘으로 밀릴 것 같지 않다." });
		}
	}
}
