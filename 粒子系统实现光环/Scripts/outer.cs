using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class outer : MonoBehaviour {
	public ParticleSystem _particle_system;  
	private ParticleSystem.Particle[] _particle_array;  
	private int _halo_resolution = 3000;  
	private float _min_radius = 2F;  
	private float _max_radius = 4.5F;  
	private HaloParticle[] _halo_particle;  
	// Use this for initialization
	void Start () {
		_particle_system = this.GetComponent<ParticleSystem> ();  
		_particle_array = new ParticleSystem.Particle[_halo_resolution];  
		_halo_particle = new HaloParticle[_halo_resolution];  
		_particle_system.maxParticles = _halo_resolution;  
		_particle_system.Emit (_halo_resolution);  
		_particle_system.GetParticles (_particle_array);  
		for (int i = 0; i < _halo_resolution; ++i) {  
			//粒子半径，添加一个偏移量，使粒子集中于平均半径处  
			float shiftMinRadius = Random.Range(1, ((_max_radius + _min_radius) / 2) / _min_radius);  
			float shiftMaxRadius = Random.Range(((_max_radius + _min_radius) / 2) / _max_radius, 1);  
			float radius = Random.Range (_min_radius * shiftMinRadius, _max_radius * shiftMaxRadius);  


			//粒子角度  
			float angle = Random.Range (0, Mathf.PI * 2);  


			_halo_particle [i] = new HaloParticle (radius, angle);  
			_particle_array [i].position = new Vector3 (radius * Mathf.Cos (angle), radius * Mathf.Sin (angle), 0);  
		}  

	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < _halo_resolution; ++i) {  
			_halo_particle [i].angle -= Random.Range(0, 1F / 360);  
			_particle_array [i].position = new Vector3 (_halo_particle [i].radius * Mathf.Cos (_halo_particle [i].angle), _halo_particle [i].radius * Mathf.Sin (_halo_particle [i].angle), 0);  
		}  
		_particle_system.SetParticles (_particle_array, _particle_array.Length);  
	}
}
