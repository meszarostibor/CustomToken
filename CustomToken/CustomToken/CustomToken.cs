using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTokenTest
{
    public class CustomToken
    {
        public Guid Token { get; private set; }
        public Guid UserId {get; private set; }
        public int Level { get; private set; }
        public string UserName {get; private set; }

        int expirationTime;
        public int ExpirationTime
        {
            get { return expirationTime; }
            set { expirationTime = value; }
        }
        public int RemainingTime {  get; private set; }

        public void ResetRemainingTime() 
        { 
            RemainingTime = ExpirationTime;            
        }

        public void DecreaseRemainingTime()
        {
            if (RemainingTime > 0)
            {
                RemainingTime--;
            }
        }
                 
        public CustomToken(Guid userId, int level, string userName, int expirationTime) {
            Token = Guid.NewGuid();
            UserId = userId;
            Level = level;
            UserName = userName;
            ExpirationTime = expirationTime;
            RemainingTime = expirationTime;
        }

        public override string ToString() { return $"{Token};{UserId};{Level};{UserName}"; }
    }
}
