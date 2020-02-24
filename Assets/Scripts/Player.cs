using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _speedMultiplier = 2;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private float _laserPos = 0.8f;
    [SerializeField] private float _tripleShotTimer = 5f;
    [SerializeField] private int _lives = 3;
    [SerializeField] private int _score;
    [SerializeField] private bool _isTripleShotActive = false;
    [SerializeField] private bool _isSpeedBoostActive = false;
    [SerializeField] private bool _isShieldActive = false;
    private float _canShoot = -1f;
    private Spawner _spawnManager;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private GameObject _tripleShotPrefab;
    [SerializeField] private GameObject _shieldVisualizer;
    [SerializeField] private GameObject _rightDamageVisualizer;
    [SerializeField] private GameObject _leftDamageVisualizer;
    private UIManager _uiManager;


    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawner").GetComponent<Spawner>();
        if (_spawnManager == null)
        {
            Debug.LogError("spawn manager error");
        }

        if (_uiManager == null)
        {
            Debug.LogError("UI manager is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        LaserFiring();
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        if (_isSpeedBoostActive == true)
        {
            transform.Translate(direction * _speed * _speedMultiplier * Time.deltaTime);
        }
        else
        {
            transform.Translate(direction * _speed * Time.deltaTime);
        }

        // limit vertical player movement
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.5f, 0), 0);

        // limit horizontal player movement and loop him around
        if (transform.position.x >= 11.2f)
        {
            transform.position = new Vector3(-11.2f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.2f)
        {
            transform.position = new Vector3(11.2f, transform.position.y, 0);
        }
    }

    void LaserFiring()
    {
        // if the player presses or hold space, instantiate a laser 1 unit above the player
        if (Input.GetKey(KeyCode.Space) && Time.time > _canShoot)
        {
            _canShoot = Time.time + _fireRate;

            if (_isTripleShotActive == true)
            {
                Instantiate(_tripleShotPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefab, new Vector3(transform.position.x, transform.position.y + _laserPos, 0), Quaternion.identity);
            }
        }
    }

    public void Damage()
    {
        if (_isShieldActive == false)
        {
            _lives--;
            _uiManager.UpdateLives(_lives);
            if (_lives == 2)
            {
                _rightDamageVisualizer.SetActive(true);
            }
            else if (_lives == 1)
            {
                _leftDamageVisualizer.SetActive(true);
            }
            else if (_lives < 1)
            {
                _spawnManager.OnPlayerDeath();
                Destroy(this.gameObject);
            }
        }
    }

    public void TripleShotActive()
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDown());
    }

    IEnumerator TripleShotPowerDown()
    {
        while (_isTripleShotActive == true)
        {
            yield return new WaitForSeconds(_tripleShotTimer);
            _isTripleShotActive = false;
        }
    }

    public void SpeedBoostActive()
    {
        _isSpeedBoostActive = true;
        StartCoroutine(SpeedBoostPowerDown());
    }

    IEnumerator SpeedBoostPowerDown()
    {
        while (_isSpeedBoostActive == true)
        {
            yield return new WaitForSeconds(10);
            _isSpeedBoostActive = false;
        }
    }

    public void ShieldActive()
    {
        _isShieldActive = true;
        _shieldVisualizer.SetActive(true);
        StartCoroutine(ShieldDown());
    }

    IEnumerator ShieldDown()
    {
        while (_isShieldActive == true)
        {
            yield return new WaitForSeconds(_tripleShotTimer);
            _isShieldActive = false;
            _shieldVisualizer.SetActive(false);
        }
    }

    //method to add 10 to the score
    public void ScorePoint(int points)
    {
        _score += points;
        _uiManager.UpdateScoreOnScreen(_score);
    }
    //commincate with the UI to update score
}
