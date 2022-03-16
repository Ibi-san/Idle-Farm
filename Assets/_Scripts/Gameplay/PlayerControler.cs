using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerControler : MonoBehaviour
{
    private Player _playerInput;
    private CharacterController _controller;
    private Animator _animator;
    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    private float _playerSpeed;
    private Vector3 _playerOldPosition;

    [SerializeField] private float _movementSpeed;
    private float _startMovementSpeed;
    [SerializeField] private float _gravityValue = -9.81f;

    [SerializeField] private GameObject _scythe;

    private void Awake()
    {
        _playerInput = new Player();
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _startMovementSpeed = _movementSpeed;
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }


    private void Update()
    {
        _groundedPlayer = _controller.isGrounded;

        if (_groundedPlayer && _playerVelocity.y < 0)
            _playerVelocity.y = 0f;

        Vector2 movementInput = _playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, 0f, movementInput.y);
        _controller.Move(move * Time.deltaTime * _movementSpeed);

        if (move != Vector3.zero)
            gameObject.transform.forward = move;

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);

        AnimatePlayer();
    }

    private void AnimatePlayer()
    {
        _playerSpeed = Vector3.Distance(_playerOldPosition, transform.position) * 100f;
        _playerOldPosition = transform.position;
        _animator.SetFloat("Speed", _playerSpeed);

        if (_playerInput.PlayerMain.Harvest.triggered)
            _animator.SetTrigger("Harvest");
    }


    //Animation Events for start and end of animation
    public void StartHarvesting()
    {
        _movementSpeed = 0;
        _scythe.SetActive(true);
    }

    public void StopHarvesting()
    {
        _movementSpeed = _startMovementSpeed;
        _scythe.SetActive(false);
    }
}

