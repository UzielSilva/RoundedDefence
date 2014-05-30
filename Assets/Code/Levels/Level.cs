using System;
using System.Collections.Generic;
using UnityEngine;
using RoundedDefence.Components.Ships;

namespace RoundedDefence.Components.Levels
{
	public abstract class Level
	{

		public List<Wave> waves= new List<Wave>();
		private List<Wave> activeWaves= new List<Wave>();
		private List<IShip> activeShip= new List<IShip>();
		private byte[,] valueMap= new byte[25,64];
		private int score = 0;
		private int scoreMultiplier=0;
		private long time=0;
		private Boolean clear=false;

		public Level (){
		}
		public void fastFoward(){
			time = 0;
			getWaves (15);
		}
		private void getWaves(int sc){
			if (time-- == 0 && waves.Count!=0) {
				Wave wav = waves [0];
				scoreMultiplier = sc;
				time = wav.getTime ();
				activeWaves.Add (wav);
				waves.Remove (wav);
			}
		}
		private void getShips(){
			foreach (Wave wav in activeWaves) {
				if (wav.isEmpty())
					activeWaves.Remove (wav);
				else {
					Ship ship = wav.getShip ();
					if (ship != null)
						activeShip.Add (ship);
				}
			}
		}
		public Boolean isClear(){
			return clear;
		}

		
		public  int getAllStar(){return PlayerPrefs.GetInt("LvlAllStar"+getLvlNumb(),0);}
		public  int getScore(){return PlayerPrefs.GetInt("LvlScore"+getLvlNumb(),0);}

		public abstract int getOneStar ();
		public abstract int getTwoStar ();
		public abstract int getThreeStar ();
		public abstract int getLvlNumb ();
		public abstract int getMinStars ();
		public abstract Boolean hasGuerra ();
		public abstract Boolean hasMercante ();
		public abstract Boolean hasPasajero ();
		public abstract Boolean hasPesquero ();
		public abstract Boolean hasPetrolero ();
		public abstract Boolean hasPirata ();
		public abstract Boolean hasRompeHielo ();
		public abstract Boolean hasSubmarino ();
		public abstract Boolean hasVelero ();
		public abstract Boolean hasVikingo ();
		public abstract Boolean hasZepelin ();

		public  abstract Boolean hasCangrejos ();
		public  abstract Boolean hasMedusas ();
		public  abstract Boolean hasPulpos ();
		public  abstract Boolean hasArrecifes ();
		public abstract Boolean hasVoladores ();
		public abstract Boolean hasTiburones ();
		public abstract Boolean hasKraken ();
		public abstract Boolean hasBallenas ();
		public abstract Boolean hasSirenas ();

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
	sirenas,
	erizos de mar
	estrellas.
	torbellino. especie de teletransportador;
	
*/