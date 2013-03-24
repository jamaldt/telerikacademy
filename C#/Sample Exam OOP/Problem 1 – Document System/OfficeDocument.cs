using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1___Document_System
{
    public abstract class OfficeDocument : Binary, IEncryptable
    {

        private string version;

        public string Version
        {
            get { return version; }
            set { version = value; }
        }

        protected OfficeDocument(String name) : base(name) { }

        protected bool isEncrypted;

        public bool IsEncrypted
        {
            get { return isEncrypted; }
        }

        public virtual void Encrypt()
        {
            isEncrypted = true;
        }

        public virtual void Decrypt()
        {
            isEncrypted = false;
        }
    }
}
