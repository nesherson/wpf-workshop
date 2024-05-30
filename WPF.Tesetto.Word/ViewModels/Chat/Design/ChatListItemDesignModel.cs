namespace WPF.Tesetto.Word
{
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        public static ChatListItemDesignModel Instance => new();

        public ChatListItemDesignModel()
        {
            Name = "Luke";
            Message = "This new chat app is awesome! I bet it will be fast too";
            Initials = "LM";
            ProfilePictureRGB = "ff0000";
        }
    }
}