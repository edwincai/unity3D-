using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mygame;

namespace mygame{
	public enum State { BSTART, BSEMOVING, BESMOVING, BEND, WIN, LOSE };
	public interface IUserActions {  
		void priestSOnB();  
		void priestEOnB();  
		void devilSOnB();  
		void devilEOnB();  
		void moveBoat();  
		void offBoatL();  
		void offBoatR();  
		void restart();  
	}
	public class Singlton : System.Object , IUserActions {
		private static Singlton _instance;
		private Firstcode _firstcode;
		private GenGameObject _gen_game_obj;
		public State state = State.BSTART;
		public static Singlton getInstance(){
			if (null == _instance) {
				_instance = new Singlton ();
			}
			return _instance;
		}
		public Firstcode getFirstcode(){
			return _firstcode;
		}
		internal void setFirstcode(Firstcode fc){
			if (null == _firstcode) {
				_firstcode = fc;
			}
		}
		public GenGameObject getGenGameObject() {
			return _gen_game_obj;
		}

		internal void setGenGameObject(GenGameObject ggo) {
			if (null == _gen_game_obj) {
				_gen_game_obj = ggo;
			}
		}
		public void priestSOnB() {  
			_gen_game_obj.priestStartOnBoat();  
		}  

		public void priestEOnB() {  
			_gen_game_obj.priestEndOnBoat();  
		}  

		public void devilSOnB() {  
			_gen_game_obj.devilStartOnBoat();  
		}  

		public void devilEOnB() {  
			_gen_game_obj.devilEndOnBoat();  
		}  

		public void moveBoat() {  
			_gen_game_obj.moveBoat();  
		}  

		public void offBoatL() {  
			_gen_game_obj.getOffTheBoat(0);  
		}  

		public void offBoatR() {  
			_gen_game_obj.getOffTheBoat(1);  
		}  

		public void restart() {  
			Application.LoadLevel(Application.loadedLevelName);  
			state = State.BSTART;  
		}  
	}

}

public class Firstcode : MonoBehaviour{
	void Start(){
		Singlton my = Singlton.getInstance ();
		my.setFirstcode (this);
	}
}