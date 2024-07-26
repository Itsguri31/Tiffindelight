using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tiffindelight.Services
{
    public class FirebaseAuthentication
    {
        private static FirebaseAuthentication _instance;
        public static FirebaseAuthentication Instance => _instance ??= new FirebaseAuthentication();
    }
}
