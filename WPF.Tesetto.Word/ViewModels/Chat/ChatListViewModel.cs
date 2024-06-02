using System.Collections.Generic;
using Microsoft.CSharp;

namespace WPF.Tesetto.Word
{
    public class ChatListViewModel : BaseViewModel
    {
        public List<ChatListItemViewModel> Items { get; set; }
    }
}