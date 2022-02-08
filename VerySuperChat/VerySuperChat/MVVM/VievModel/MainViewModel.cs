using System;
using System.Collections.ObjectModel;
using VerySuperChat.Core;
using VerySuperChat.MVVM.Model;

namespace VerySuperChat.MVVM.VievModel
{
    class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        /* Commands */
        public RelayCommand SendCommand { get; set; }

        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set 
            { 
                _selectedContact = value;
                OnPropertyChanged();
            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }





        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false
                }
                );

                Message = "";
            }
            );
            

            Messages.Add(new MessageModel
            {
                Username = "Bro",
                UsernameColor = "#B50AFC",
                ImageSource = "C:\\Users\\User\\Desktop\\ava.jpg",
                Message = "Test",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });

            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "NotBro",
                    UsernameColor = "#B50AFC",
                    ImageSource = "C:\\Users\\User\\Desktop\\ava.jpg",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = true,
                    FirstMessage = false
                });
            }



            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Vlad",
                    UsernameColor = "#B50AFC",
                    ImageSource = "C:\\Users\\User\\Desktop\\ava.jpg",
                    Message = "qwe",
                    Time = DateTime.Now,
                    IsNativeOrigin = true
                });
            }

            Messages.Add(new MessageModel
            {
                Username = "Last",
                UsernameColor = "",
                ImageSource = "C:\\Users\\User\\Desktop\\ava.jpg",
                Message = "Last",
                Time = DateTime.Now,
                IsNativeOrigin = true
            });

            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = $"User {i}",
                    ImageSource = $"C:\\Users\\User\\Desktop\\с{i+1}.jpg",
                    Messages = Messages
                });
            }
        }
    }
}
