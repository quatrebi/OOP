using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    public struct ActionEventArgs
    {
        public object sender;
        public object destination;
        public string message;

        public ActionEventArgs(object sender, object dest, string msg)
        {
            this.sender = sender;
            destination = dest;
            message = msg;
        }
    }

    public delegate void Action(ActionEventArgs e);
    public class User
    {
        public string name;

        public event Action Upgrade;
        public event Action Work;

        public void DoUpgrade(Software obj) => Upgrade?.Invoke(new ActionEventArgs(this, obj, $"{obj} was upgraded!"));
        public void DoWork(Software obj) => Work?.Invoke(new ActionEventArgs(this, this, $"{name} starts to work in {obj}"));

        public override string ToString()
        {
            return $"[User] {name}";
        }
    }

    public class Software
    {
        public Action doUpgrade;
        public Action doWork;

        public string softName;
        public string userName = "Unknown";

        private int m_ver;
        public int Version
        {
            get { return m_ver; }
            private set { m_ver = value; }
        }

        public Software(int version)
        {
            Version = version;
            doUpgrade = m_Upgrade;
            doWork = m_Work;
        }

        public override string ToString()
        {
            return $"[User = {userName}] Software Name = {softName} v{Version}";
        }

        void m_Upgrade(ActionEventArgs e)
        {
            if (e.destination is Software)
                (e.destination as Software).Version++;
        }
        void m_Work(ActionEventArgs e)
        {
            if (e.destination is User)
                userName = (e.destination as User).name;
        }
    }
}
