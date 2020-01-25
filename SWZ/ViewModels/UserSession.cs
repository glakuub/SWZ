using SWZ.Models;
using System.Diagnostics;

namespace SWZ.ViewModels
{




    public sealed class UserSession
    {
        private static readonly UserSession _current = new UserSession();

        private StudentModel user;
            


        private UserSession() {
                UserID = null;
            }

        public static UserSession Get { get { return _current; } }

        public bool IsSet => UserID != null;

        public int? UserID { private set;  get; }

        public void Create(int id)
        {
            
            user = StudentModel.GetById(id);
            UserID = id;

        }
            
        public void Destroy()
        {
            user = null;
            UserID = null;
        }
        public int StudentIndexNumber => _current.user.IndexNumber;
        public string StudentFirstName => _current.user.FirstName;
        public string StudentLastName => _current.user.LastName;




    }
        
   
    


}
