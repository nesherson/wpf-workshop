namespace WPF.Tesetto.Word.Core
{
    public class ChatListDesignModel : ChatListViewModel
    {
        public static ChatListDesignModel Instance => new();

        public ChatListDesignModel()
        {
            Items = new()
            {
                new ChatListItemViewModel
                {
                    Name = "Luke",
                    Message = "Test message 123",
                    Initials = "LM",
                    ProfilePictureRGB = "3099c5",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Name = "Jessie",
                    Message = "Test message 1234456",
                    Initials = "LM",
                    ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Name = "Andrew",
                    Message = "Test message 123822wjwj",
                    Initials = "AH",
                    ProfilePictureRGB = "00d405"
                },
                 new ChatListItemViewModel
                {
                    Name = "Luke",
                    Message = "Test message 123",
                    Initials = "LM",
                    ProfilePictureRGB = "3099c5",
                    IsSelected = true
                },
                new ChatListItemViewModel
                {
                    Name = "Jessie",
                    Message = "Test message 1234456",
                    Initials = "LM",
                    ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Name = "Andrew",
                    Message = "Test message 123822wjwj",
                    Initials = "AH",
                    ProfilePictureRGB = "00d405"
                },
                 new ChatListItemViewModel
                {
                    Name = "Luke",
                    Message = "Test message 123",
                    Initials = "LM",
                    ProfilePictureRGB = "3099c5"
                },
                new ChatListItemViewModel
                {
                    Name = "Jessie",
                    Message = "Test message 1234456",
                    Initials = "LM",
                    ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Name = "Andrew",
                    Message = "Test message 123822wjwj",
                    Initials = "AH",
                    ProfilePictureRGB = "00d405"
                }
            };
        }
    }
}