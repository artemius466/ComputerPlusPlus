using GorillaNetworking;

namespace ComputerPlusPlus.Screens
{
    // The in game view is called "AutoMod"
    public class AutoMute : IScreen
    {
        public string Title => "Auto Mute";
        public string Description =>
            "Automatically mutes players when they join your " +
            "room if a lot of other people have them muted.\n" +
            "[Option 1] Agressive muting\n" +
            "[Option 2] Moderate muting\n" +
            "[Option 3] Auto mute off";

        public string GetContent() =>
            "Current auto mute level: " + GorillaComputer.instance?.autoMuteType;

        public void OnKeyPressed(GorillaKeyboardButton button)
        {
            GorillaComputer.instance.ProcessAutoMuteState(button.Binding);
        }

        public void Start() { }
    }
}
