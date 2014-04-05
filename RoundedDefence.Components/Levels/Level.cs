using System;
using System.Collections.Generic;

namespace RoundedDefence.Components
{
	public class Level
	{

		public List<Wave> waves= new List<Wave>();
		public List<Wave> activeWaves= new List<Wave>();
		public List<Ship> activeShip= new List<Ship>();
		public long time=0;
		public Boolean clear=false;
		public Level (){
		}

		public void Move(){
			if (time-- == 0 && waves.Count!=0) {
				Wave wav = waves [0];
				activeWaves.Add (wav);
				waves.Remove (wav);
			}
			foreach (Wave wav in activeWaves) {
				if (wav.isEmpty())
					activeWaves.Remove (wav);
				else {
					Ship ship = wav.getShip ();
					if (ship != null)
						activeShip.Add (ship);
				}
			}
			foreach (Ship ship in activeShip) {
				if (ship.getLife () <= 0)
					activeShip.Remove (ship);
				else {
					ship.move();
				}
			}
			if (waves.Count == 0 && activeWaves.Count == 0 && activeShip.Count == 0)
				clear = true;
		}
		public Boolean isClear(){
			return clear;
		}

		public Boolean hasGuerra(){return false;}
		public Boolean hasMercante(){return false;}
		public Boolean hasPasajero(){return false;}
		public Boolean hasPesquero(){return false;}
		public Boolean hasPetrolero(){return false;}
		public Boolean hasPirata(){return false;}
		public Boolean hasRompeHielo(){return false;}
		public Boolean hasSubmarino(){return false;}
		public Boolean hasVelero(){return false;}
		public Boolean hasVikingo(){return false;}
		public Boolean hasZepelin(){return false;}

		public Boolean hasCangrejos(){return false;}
		public Boolean hasMedusas(){return false;}
		public Boolean hasPulpos(){return false;}
		public Boolean hasArrecifes(){return false;}
		public Boolean hasVoladores(){return false;}
		public Boolean hasTiburones(){return false;}
		public Boolean hasKraken(){return false;}
		public Boolean hasBallenas(){return false;}
		public Boolean hasSirenas(){return false;}

	}
}
/*
torres:
	cangrejos, ataque fuerte 
	medusas, ataque venenoso 
	pulpos, ataques múltiples 
	arrecifes, alentan el camino 
	peces voladores, larga distancia 
	tiburones, ataque pasivo por el mapa 
	kraken, ataque de emergencia 
	ballenas, se tragan enemigos
*/