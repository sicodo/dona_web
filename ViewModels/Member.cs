using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class Member
    {
        public string id_user { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public bool is_locked { get; set; }
        public bool is_deleted { get; set; }
        public string validate_key { get; set; }

        public string GetDecryptedPassword()
        {
            return Ultilities.SecurityHelper.StringCipher.Decrypt(this.password);
        }
        public string GetEncryptedPassword()
        {
            return Ultilities.SecurityHelper.StringCipher.Encrypt(this.password);
        }
        public bool isValidPassword(string password)
        {
            return this.GetDecryptedPassword().Equals(password);
        }
    }

}
