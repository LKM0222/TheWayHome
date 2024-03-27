using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugScript : MonoBehaviour
{
    Database theDB;
    [SerializeField] Text infoText;

    // Start is called before the first frame update
    void Start()
    {
        theDB = FindObjectOfType<Database>();
    }

    // Update is called once per frame
    void Update()
    {
        infoText.text = "Player Speed \n" +
            "플레이어 최대 속도 : " + theDB.playerMaxSpeed + "\n" +
            "플레이어 이동 속도 : " + theDB.playerUpSpeed + "\n" +
            "맵 이동 최대 속도 : " + theDB.fixMapMovingSpeed + "\n" +
            "맵 이동 속도 : " + theDB.mapMovingSpeed + "\n\n" +
            "맵 이동 속도는 레벨 별 비율로 설정해뒀습니다. \n" +
            "따라서 사실 이동속도만 바꿔도 됩니다.\n\n" +
            "Player Energy \n" +
            "에너지 감소 : " + theDB.playerConsumeEnergy + "\n" +
            "에너지 증가 : " + theDB.playerEnergy + "\n" +
            "최대 에너지 : " + theDB.playerMaxEnergy + "\n" +
            "위험지역 탈출 시 소모에너지 : " + theDB.dangerExitEnergy + "\n" +
            "부활 시 적용될 에너지 : " + theDB.playerRevivalEnergy + "\n" +
            "중간 거점 회복량 : " + theDB.wormholeEnergy + "\n" +
            "벽 충돌 에너지 : " + theDB.wallHitEnergy + "\n" +
            "아래로 내려갔을때 피해량 : " + theDB.downConsumeEnergy + "\n\n" +
            "탈출 시 에너지는 기본적 에너지 감소량과 같게 설정하심 됩니다. \n\n" +
            "Player Money \n" +
            "플레이어가 가진 재화 : " + theDB.totalPlayerMoney + "\n" +
            "Player Score \n" +
            "시간 당 점수 증가량 : " + theDB.playerPlusScore + "\n" +
            "12궁 점수 : " + theDB.zodiacScore + "\n" +
            "작은 별 점수 : " + theDB.smallStarScore + "\n" +
            "큰 별 점수 : " + theDB.bigStarScore;
    }
}
