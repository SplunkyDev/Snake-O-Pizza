using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;

namespace GameUtility.Base
{


    public interface ISingletonCreatedListener
    {
        void OnInstanceCreated();
    }

    public interface IEventBase
    {

    }

    public interface IInputEvent : IEventBase
    {

    }

    public interface IEventListener
    {
        void RegisterForEvents();
        void DeRegisterForEvents();
    }


	public enum eGameState
	{
		None = 0,
		Initialize = 1,
		LevelSelection = 2,
		InGame = 3,
		GameComplete = 4,
		Menu = 6,
		WaitingForOpponent = 7,
		ErrorInConnection =8
	}

	public enum eGameUIState
	{
		None = 0,
		InitializeUI = 1,
		MenuUI = 2,
		InGameUI = 3,
		GameComplete = 4,
		ErrorInConnection =5,
		WaitingForPlayers =6

	}

	public enum eUITweenMoveState
	{
		None = 0,
		Horizontal_Left = 1,
		Horizontal_Right = 2,
		Vertical_Up = 3,
		vertical_Down = 4
	}

	public enum eMessageType
	{
		None = 0,
		PlayerTurn = 1,
		StartAcknowledgement = 2,
		GameEnded =3,
		PlayerDiceRoll =4,
		PlayerTokenSelected =5,
		GameStart =6
	}
}

