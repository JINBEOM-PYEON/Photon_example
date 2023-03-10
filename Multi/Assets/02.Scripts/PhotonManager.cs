using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    private readonly string gameVersion = "v1.0";
    private string userId = "0jui";

    private void Awake()
    {
        //게임 버전 지정
        PhotonNetwork.GameVersion = gameVersion;
        //게임 서버 접속
        PhotonNetwork.ConnectUsingSettings();
    }

    void Start()
    {
        Debug.Log("00. 포톤 매니저 시작");
        PhotonNetwork.NickName = userId;
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("01. 포톤 서버 접속");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("02. 랜덤 룸 접속 실패");

        //룸 속성 설정
        RoomOptions ro = new RoomOptions();
        ro.IsOpen = true;
        ro.IsVisible = true;
        ro.MaxPlayers = 30;

        // 룸 생성 > 자동 입장
        PhotonNetwork.CreateRoom("room_1", ro);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("03. 방 생성 완료");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("04. 방 입장 완료");
        GameManager.instance.isConnect = true;
    }

}