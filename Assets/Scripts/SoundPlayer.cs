using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource _audioToSource;
    [SerializeField] private AudioSource _audioSourceSFX;

    [SerializeField] private AudioClip _jumpSound, _deathSound, _hitSound, _mallSound, _musicSound;

    public AudioClip JumpSound { get => _jumpSound; set => _jumpSound = value; }
    public AudioClip DeathSound { get => _deathSound; set => _deathSound = value; }
    public AudioClip HitSound { get => _hitSound; set => _hitSound = value; }
    public AudioClip MallSound { get => _mallSound; set => _mallSound = value; }
    public AudioClip MusicSound { get => _musicSound; set => _musicSound = value; }









}
