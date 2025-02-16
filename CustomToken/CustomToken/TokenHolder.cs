using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CustomTokenTest
{
    public class TokenHolder
    {
        public List<CustomToken> tokens = new List<CustomToken>();

        public static System.Timers.Timer aTimer;

        public bool AutoDecrease {  get; private set; }
        public int Interval { get; private set; }

        public void SetTimer(int interval)
        {
            aTimer = new System.Timers.Timer(interval);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            DecreaseExpirationTime();
        }

        public void DecreaseExpirationTime()
        {
            if (tokens.Count > 0)
            {
                for (int i = tokens.Count-1; i >= 0; i--)
                {
                    if (tokens[i].RemainingTime > 0)
                    {
                        tokens[i].DecreaseRemainingTime();
                    }
                    else
                    {
                        tokens.Remove(tokens[i]);
                    }
                }
            }
        }

        public void GenerateToken(Guid userId, int level, string userName, int expirationTime)
        {
            tokens.Add(new CustomToken(userId, level, userName,expirationTime));
        }

        public TokenHolder(int interval)
        {
            Interval = interval;           
            SetTimer(Interval);
        }

        public CustomToken CheckTokenValidity(Guid token) 
        {
            int index = -1;
            for (int i = 0; i < tokens.Count; i++) {
                if (tokens[i].Token == token) 
                {
                    index = i; break;
                }            
            }
            if (index != -1)
            {
                tokens[index].ResetRemainingTime(); 
                return tokens[index];
            }
            else
            {
                return new CustomToken(new Guid(), -1, "", 0);  
            }
            
        
        }



        ~TokenHolder() 
        { 
            aTimer.Close(); 
        }



    }
}
