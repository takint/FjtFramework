﻿using System;

namespace FjtFramework.Cores
{
    public abstract class BaseViewModel
    {
        public int Id { get; set; }

        public string CreatedUser { get; set; }

        public string UpdatedUser { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool Inactivated { get; set; }

        public string RowVersion { get; set; }

        public virtual void Audit(string user)
        {
            if (Id <= 0)
            {
                CreatedUser = user;
                CreatedDate = DateTime.UtcNow;
            }

            UpdatedUser = user;
            UpdatedDate = DateTime.UtcNow;

            AuditChildren(user);
        }

        public abstract void ValidateAndThrow();

        protected virtual void AuditChildren(string user)
        {
            return;
        }
    }
}
