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

        public void SetTimer(int interval,bool autoDecrease)
        {
            aTimer = new System.Timers.Timer(interval);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = autoDecrease;
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            DecValidityPeriod();
        }

        public void DecValidityPeriod()
        {
            if (tokens.Count > 0)
            {
                for (int i = tokens.Count-1; i >= 0; i--)
                {
                    if (tokens[i].ExpirationTime > 0)
                    {
                        tokens[i].ExpirationTime--;
                    }
                    else
                    {
                        tokens.Remove(tokens[i]);
                    }
                }
            }
        }

        public void GenerateToken(Guid userId, int level, string userName)
        {
            tokens.Add(new CustomToken(userId, level, userName,20));
        }

        public TokenHolder(int interval,bool autoDecrease)
        {
            this.Interval = interval;
            this.AutoDecrease = autoDecrease;
            SetTimer(Interval,AutoDecrease);
        }





    }
}
