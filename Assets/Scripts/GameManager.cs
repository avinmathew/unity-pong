using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    public static bool IsGameStarted = false;
    public static int NumberOfPlayers = 1;

    public Ball Ball;
    public LeftPaddle LeftPaddle;
    public RightPaddle RightPaddle;
    public TextMeshProUGUI LeftScore;
    public TextMeshProUGUI RightScore;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Player1;
    public TextMeshProUGUI Players2;
    public TextMeshProUGUI Player1Selector;
    public TextMeshProUGUI Players2Selector;
    public AudioClip PlayerSelectClip;

    private PostProcessVolume _blurBackground;
    private AudioSource _audioSource;

    private int _leftScore = 0;
    private int _rightScore = 0;

    private void Start()
    {
        _blurBackground = Camera.main.gameObject.GetComponent<PostProcessVolume>();
        _audioSource = GetComponent<AudioSource>();

        LeftScore.enabled = false;
        RightScore.enabled = false;

        Players2Selector.enabled = false;
    }

    public void LeftPlayerScores()
    {
        _leftScore++;
        LeftScore.text = _leftScore.ToString();
        
        StartCoroutine(ResetRound());
    }
    public void RightPlayerScores()
    {
        _rightScore++;
        RightScore.text = _rightScore.ToString();

        StartCoroutine(ResetRound());
    }

    private IEnumerator ResetRound()
    {
        Ball.ResetPosition();
        // Give a bit of time before starting
        yield return new WaitForSeconds(1);
        Ball.AddStartingForce();
    }

    private void Update()
    {
        // Quit game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGameStarted)
            {
                StopGame();
            }
            else
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
                Application.Quit();
            }
        }

        if (IsGameStarted)
        {
            return;
        }
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && NumberOfPlayers == 1)
        {
            NumberOfPlayers = 2;
            Player1Selector.enabled = false;
            Players2Selector.enabled = true;
            _audioSource.PlayOneShot(PlayerSelectClip);
        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && NumberOfPlayers == 2)
        {
            NumberOfPlayers = 1;
            Player1Selector.enabled = true;
            Players2Selector.enabled = false;
            _audioSource.PlayOneShot(PlayerSelectClip);
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        Title.enabled = false;
        Player1.enabled = false;
        Players2.enabled = false;
        Player1Selector.enabled = false;
        Players2Selector.enabled = false;
        LeftScore.enabled = true;
        RightScore.enabled = true;

        _blurBackground.enabled = false;

        IsGameStarted = true;

        Ball.AddStartingForce();
    }

    private void StopGame()
    {
        IsGameStarted = false;

        Ball.ResetPosition();
        LeftPaddle.ResetPosition();
        RightPaddle.ResetPosition();
        _leftScore = 0;
        _rightScore = 0;
        LeftScore.text = "0";
        RightScore.text = "0";

        _blurBackground.enabled = true;

        Title.enabled = true;
        Player1.enabled = true;
        Players2.enabled = true;
        Player1Selector.enabled = NumberOfPlayers == 1;
        Players2Selector.enabled = NumberOfPlayers == 2;
        LeftScore.enabled = false;
        RightScore.enabled = false;
    }
}
