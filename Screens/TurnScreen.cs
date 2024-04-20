using ComputerPlusPlus.Tools;
using GorillaNetworking;
using HarmonyLib;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ComputerPlusPlus.Screens
{
    public class TurnScreen : IScreen
    {
        public string Title => "Turning";

        public string Description =>
            "Press [Option 1] for Snap Turning.\n" +
            "Press [Option 2] for Smooth Turning.\n" +
            "Press [Option 3] for No Turning.\n" +
            "Press a number to change the turn speed.";

        public string Template =
            "    Turn type: {0}\n" +
            "    Turn speed: {1}\n";

        public string GetContent()
        {
            string speed = GorillaComputer.instance.turnValue.ToString();
            string type = GorillaComputer.instance.turnType;
            return string.Format(
                Template,
                type,
                speed
            );
        }

        public void OnKeyPressed(GorillaKeyboardButton button)
        {
            GorillaComputer.instance.ProcessTurnState(button.Binding);
        }

        public void Start()
        {

        }
    }
}
