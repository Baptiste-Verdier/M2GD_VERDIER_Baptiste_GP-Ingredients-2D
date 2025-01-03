using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private Image lifeUI;
    [SerializeField] private int maxLife = 5;
    private int _life;
    private Animator _animator;
    private SoundPlayer _audioPlayer;
    public static int currentScene; 

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioPlayer = GetComponent<SoundPlayer>();
        _life = maxLife;
    }

    private void Update()
    {
        if (_life <= 0)
        {
            SceneManager.LoadScene(currentScene);
           
        }
    }

    public void Hurt(int damage)
    {
        _life -= damage;
        _animator.SetTrigger("Hurt");
        _audioPlayer.PlayAudio(SoundFX.Hurt);
        UpdateUI();
    }

    public void Heal(int heal)
    {
        _life += heal;
        UpdateUI();
    }

    private void UpdateUI()
    {
        lifeUI.fillAmount = (float)_life / maxLife;
    }
}
