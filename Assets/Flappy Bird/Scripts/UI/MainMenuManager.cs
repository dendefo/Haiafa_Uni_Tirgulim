using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static PlayerColors selectedColor = PlayerColors.Blue;
    public const string PLAYER_SELECTED_COLOR = nameof(PLAYER_SELECTED_COLOR);
    [SerializeField] string gameSceneName = "GameScene";
    Coroutine loadingCoroutine;
    [SerializeField] List<PlayerController> playerPrefabs;
    [SerializeField] float distanceToMove = 2;
    Coroutine movingCoroutine;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(PLAYER_SELECTED_COLOR))
        {
            selectedColor = Enum.Parse<PlayerColors>(PlayerPrefs.GetString(PLAYER_SELECTED_COLOR));
        }
        var player = playerPrefabs.First(x => x.gameObject.activeSelf);
        player.gameObject.SetActive(false);

        var selected = playerPrefabs.First(x => x.PlayerColor == selectedColor);
        selected.gameObject.SetActive(true);
    }
    public void StartGame()
    {
        if (loadingCoroutine != null) return;
        loadingCoroutine = StartCoroutine(LoadGameScene());
    }
    private IEnumerator LoadGameScene()
    {
        var time = Time.time;

        AsyncOperation loadingProcess = SceneManager.LoadSceneAsync(gameSceneName);
        loadingProcess.allowSceneActivation = false;

        yield return new WaitUntil(() => loadingProcess.progress >= 0.9f);

        loadingProcess.allowSceneActivation = true;
        Debug.Log("Loading Time: " + (Time.time - time) + " seconds.");
    }
    public void MoveRight()
    {
        if (movingCoroutine != null) return;
        PlayerController turnedOnPlayer = playerPrefabs.First(playerController => playerController.gameObject.activeSelf);
        int index = playerPrefabs.IndexOf(turnedOnPlayer);

        index++;
        index %= playerPrefabs.Count;

        movingCoroutine = StartCoroutine(PlayerSelection(turnedOnPlayer, playerPrefabs[index], true));

        //turnedOnPlayer.gameObject.SetActive(false);
        //playerPrefabs[index].gameObject.SetActive(true);
    }
    public void MoveLeft()
    {
        if (movingCoroutine != null) return;
        PlayerController turnedOnPlayer = playerPrefabs.First(playerController => playerController.gameObject.activeSelf);
        int index = playerPrefabs.IndexOf(turnedOnPlayer);

        index--;
        index += playerPrefabs.Count;
        index %= playerPrefabs.Count;

        movingCoroutine = StartCoroutine(PlayerSelection(turnedOnPlayer, playerPrefabs[index], false));
        //turnedOnPlayer.gameObject.SetActive(false);
        //playerPrefabs[index].gameObject.SetActive(true);
    }
    private IEnumerator PlayerSelection(PlayerController playerToTurnOff, PlayerController playerToTurnOn, bool isRight)
    {
        Vector3 direction = (!isRight ? Vector3.right : Vector3.left) * distanceToMove;
        playerToTurnOn.gameObject.SetActive(true);
        Vector3 oppositreDirection = direction * -1;
        for (float timer = 0; timer <= 0.25f; timer += Time.deltaTime)
        {
            playerToTurnOn.transform.position = Vector3.Lerp(oppositreDirection, Vector3.zero, timer / 0.25f);
            playerToTurnOff.transform.position = Vector3.Lerp(Vector3.zero, direction, timer / 0.25f);
            yield return null;
        }
        playerToTurnOff.gameObject.SetActive(false);
        movingCoroutine = null;
        selectedColor = playerToTurnOn.PlayerColor;
        PlayerPrefs.SetString(PLAYER_SELECTED_COLOR, selectedColor.ToString());
    }
}
